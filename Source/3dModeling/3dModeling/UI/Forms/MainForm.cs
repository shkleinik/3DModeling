//-----------------------------------------------------------------------
// <copyright file="MainForm.cs" company="Walash Ltd.">
//     Copyright (c) Walash Ltd. All rights reserved.
// </copyright>
// <author>Pavel Shkleinik</author>
//-----------------------------------------------------------------------

namespace Modeling.UI.Forms
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;
    using Core.Elements;
    using Core.Shapes;
    using Light;
    using Microsoft.DirectX.Direct3D;
    using ProjectionsForms;
    using S = Core.Helpers.Serializator;
    using T = Core.Transformations;

    public partial class MainForm : Form
    {
        #region Constants
        private const int DEFAULT_GRID_STEP = 30;
        private const int MIN_GRID_STEP = -100;
        private const int MAX_GRID_STEP = 500;
        private const int SCALE_STEP = 2;
        private const string PATHTO_SERIALIZED_STATE = "Walash.3Dscene";
        private static readonly Color COLOR_TO_DRAW = Color.Red;
        #endregion

        #region Fields

        private Device device;

        private List<BaseShape> objectsToDraw;
        private BaseShape polyShape;
        private Vertex basePoint;
        private Vertex lightSource;
        private PointF moveStartPoint;
        private double rotateStartAngle;

        private int gridStep = DEFAULT_GRID_STEP;
        private bool allowScale = true;
        private bool isControlPressed;
        #endregion

        #region Properties
        public int GridStep
        {
            get
            {
                return gridStep;
            }
            set
            {
                if (value > MIN_GRID_STEP && value < MAX_GRID_STEP)
                {
                    gridStep = value;
                    allowScale = true;
                }
                else
                    allowScale = false;
            }
        }
        #endregion

        #region Constructors
        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes DirectX Graphics.
        /// </summary>
        public void InitializeDirectX()
        {
            try
            {
                SetStyle(ControlStyles.Opaque | ControlStyles.AllPaintingInWmPaint, true);
                UpdateStyles();
                var presentParams = new PresentParameters();
                presentParams.Windowed = true;
                presentParams.SwapEffect = SwapEffect.Discard;

                device = new Device(0, DeviceType.Hardware, this, CreateFlags.SoftwareVertexProcessing, presentParams);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region Handling Form Events
        private void On_MainForm_Load(object sender, EventArgs e)
        {
            InitializeDirectX();

            basePoint = new Vertex((float)Width / 2, (float)Height / 2);
            polyShape = new BaseShape();
            moveStartPoint = basePoint;
            lightSource = new Vertex(-1000, 0, 0);

            // var cube = new Cube(new Vertex(basePoint.X - 300, basePoint.Y + 100, basePoint.Z), 200);
            //var cube = new Cube(basePoint, 200);
            //var pyramid = new Pyramid(basePoint, 4, 150, 300);
            var cone = new Cone(basePoint, 150, -300);
            //var pyramidReverse = new Pyramid(new Vertex(basePoint.X - 100, basePoint.Y, basePoint.Z + 300), 9, 50, -100);
            //var axises = new CoordinateAxises(basePoint);
            //var cylinder = new Cylinder(basePoint, 100, 200);
            //var cylinderReverse = new Cylinder(new Vertex(basePoint.X - 100, basePoint.Y, basePoint.Z), 100, -200);
            //var prizm = new Prizm(basePoint, 3, (float)(200 / Math.Sqrt(2.0F)), -200);

            objectsToDraw = S.DeserializeShapes(PATHTO_SERIALIZED_STATE) ?? new List<BaseShape> { new CoordinateAxises(basePoint) };
            //objectsToDraw.Add(pyramid);
            objectsToDraw.Add(cone);
            //objectsToDraw.Add(prizm);
            //objectsToDraw.Add(pyramidReverse);
            //objectsToDraw.Add(cylinder);
            //objectsToDraw.Add(cylinderReverse);
            //objectsToDraw.Add(cube);

            SaveObjectsState(objectsToDraw);
            On_MainForm_Paint(null, null);

        }

        private void On_MainForm_Closing(object sender, FormClosingEventArgs e)
        {

        }

        private void On_MainForm_Paint(object sender, PaintEventArgs e)
        {
            if (cbUseDirectX.Checked)
            {
                if (cbHideEdges.Checked)
                {
                    DrawObjectsWithDXWithoutHiddenEdges(objectsToDraw);
                }
                else
                {
                    DrawObjectsWithDX(objectsToDraw);
                }
            }
            else
            {
                if (cbHideEdges.Checked)
                {
                    polyShape.Erase(CreateGraphics());
                    DrawObjectsWithoutHiddenEdges();
                }
                else
                {
                    EraseObjects(objectsToDraw);
                    DrawObjects(objectsToDraw);
                }
            }
            // CreateGraphics().DrawEllipse(Pens.Red, basePoint.X, basePoint.Y, 3F, 3F);
        }

        private void On_MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.ControlKey:
                    isControlPressed = true;
                    break;
                case Keys.Escape:
                    On_MainForm_Load(null, null);
                    On_MainForm_Paint(null, null);
                    break;
                default:
                    break;
            }
        }

        private void On_MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            isControlPressed = false;
        }

        private void On_MainForm_MouseClick(object sender, MouseEventArgs e)
        {
            if (!isControlPressed)
                return;
            switch (e.Button)
            {
                case MouseButtons.Left:
                    break;
                case MouseButtons.Right:
                    //basePoint = new Point3D(e.Location);
                    break;
                default:
                    break;
            }
            On_MainForm_Paint(null, null);
        }

        private void On_MainForm_MouseWheel(object sender, MouseEventArgs e)
        {
            basePoint = ((CoordinateAxises)objectsToDraw[0]).BasePoint;
            if (e.Delta > 0)
            {
                GridStep += SCALE_STEP * 10;
                if (allowScale)
                    ScaleObjects(objectsToDraw, SCALE_STEP);
            }
            else
            {
                GridStep -= SCALE_STEP * 10;
                if (allowScale)
                    ScaleObjects(objectsToDraw, (float)1 / SCALE_STEP);
            }
            On_MainForm_Paint(null, null);

        }

        private void On_MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            Select();
            SaveObjectsState(objectsToDraw);
            moveStartPoint.X = e.X;
            moveStartPoint.Y = e.Y;
            basePoint = ((CoordinateAxises)objectsToDraw[0]).BasePoint;
            switch (e.Button)
            {
                case MouseButtons.Left:
                    rotateStartAngle = GetZRotateAngle(basePoint, e.Location);
                    Cursor = new Cursor(GetType(), "RotateCursor.cur");
                    break;
                case MouseButtons.Right:
                    Cursor = Cursors.SizeAll;
                    break;
                default:
                    break;
            }
        }

        private void On_MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    var rotAngleX = (moveStartPoint.Y - e.Y) * Math.PI / 180;
                    var rotAngleY = (e.X - moveStartPoint.X) * Math.PI / 180;
                    var dynamicAngle = GetZRotateAngle(basePoint, e.Location);
                    var rotAngleZ = dynamicAngle - rotateStartAngle;
                    // Console.WriteLine("angleToRotate = {0:F2}, dynamicAngle  = {1:F2},rotateStartAngle = {2:F2} ", angleToRotate * 180 / Math.PI, dynamicAngle * 180 / Math.PI, rotateStartAngle * 180 / Math.PI);
                    RotateObjects(objectsToDraw, 0, rotAngleX, rotAngleY);//rotAngleX rotAngleY, 0);// rotAngleZ);
                    On_MainForm_Paint(null, null);
                    break;
                case MouseButtons.Right:
                    var dX = e.X - moveStartPoint.X;
                    var dY = moveStartPoint.Y - e.Y;
                    MoveObjects(objectsToDraw, dX, dY, 0);
                    On_MainForm_Paint(null, null);
                    break;
                default:
                    break;
            }
        }

        private void On_MainForm_MouseUp(object sender, MouseEventArgs e)
        {
            SaveObjectsState(objectsToDraw);
            Cursor = Cursors.Default;
        }
        #endregion

        #region Handling Menu Events
        private void On_miObjectsToRender_Click(object sender, EventArgs e)
        {
            (new ObjectsForm(objectsToDraw)).ShowDialog(this);
        }

        private void On_miXY_Click(object sender, EventArgs e)
        {
            foreach (var shape in objectsToDraw)
            {
                shape.XYProjection();
            }

            MoveSceneToScreensCenter();
            On_MainForm_Paint(null, null);
        }

        private void On_miYZ_Click(object sender, EventArgs e)
        {
            foreach (var shape in objectsToDraw)
            {
                shape.YZProjection();
            }
            MoveSceneToScreensCenter();
            On_MainForm_Paint(null, null);
        }

        private void On_miXZ_Click(object sender, EventArgs e)
        {
            foreach (var shape in objectsToDraw)
            {
                shape.XZProjection();
            }
            MoveSceneToScreensCenter();
            On_MainForm_Paint(null, null);
        }

        private void On_miAksonometricProjection_Click(object sender, EventArgs e)
        {
            var aksonometricProjectionForm = new AksonometricProjectionForm();
            if (DialogResult.OK != aksonometricProjectionForm.ShowDialog(this))
                return;
            var psi = Convert.ToDouble(aksonometricProjectionForm.tbPsi.Text) * Math.PI / 180;
            var phi = Convert.ToDouble(aksonometricProjectionForm.tbPhi.Text) * Math.PI / 180;

            foreach (var shape in objectsToDraw)
            {
                shape.AksonometricProjection(psi, phi);
            }

            MoveSceneToScreensCenter();
            On_MainForm_Paint(null, null);
        }

        private void On_miBevelProjection_Click(object sender, EventArgs e)
        {
            var bevelProjectionForm = new BevelProjectionForm();

            if (DialogResult.OK != bevelProjectionForm.ShowDialog(this))
                return;
            var L = Convert.ToDouble(bevelProjectionForm.tbL.Text);
            var alpha = Convert.ToDouble(bevelProjectionForm.tbAlpha.Text) * Math.PI / 180;


            foreach (var shape in objectsToDraw)
            {
                shape.BevelProjection(L, alpha);
            }

            MoveSceneToScreensCenter();
            On_MainForm_Paint(null, null);
        }

        private void On_miPerspectiveProjection_Click(object sender, EventArgs e)
        {
            var perspectiveProjectionForm = new PerspectiveProjectionForm();
            if (DialogResult.OK != perspectiveProjectionForm.ShowDialog(this))
                return;

            double tetta;
            double phi;
            double r;
            double d;

            if (Double.TryParse(perspectiveProjectionForm.tbTetta.Text, out tetta) && Double.TryParse(perspectiveProjectionForm.tbPhi.Text, out phi) && Double.TryParse(perspectiveProjectionForm.tbR.Text, out r) && Double.TryParse(perspectiveProjectionForm.tbD.Text, out d))
            {
                //ReInitPolyShape();
                //polyShape.SaveState();
                //polyShape.PerspectiveProjection(tetta, phi, r, d);
                //DrawObjectsWithoutHiddenEdges();
                foreach (var shape in objectsToDraw)
                {
                    shape.PerspectiveProjection(tetta, phi, r, d);
                }

                MoveSceneToScreensCenter();
                On_MainForm_Paint(null, null);

            }
            else
                MessageBox.Show("Input string has incorrect format, please correct", "Argument exception");
        }

        private void On_miChangeLightSourceLocation_Click(object sender, EventArgs e)
        {
            var changeLightSourceLocationClick = new ChangeLightSourceLocationForm(lightSource);


            if (DialogResult.OK != changeLightSourceLocationClick.ShowDialog(this))
                return;

            lightSource = new Vertex(Single.Parse(changeLightSourceLocationClick.tbX.Text),
                                     Single.Parse(changeLightSourceLocationClick.tbY.Text),
                                     Single.Parse(changeLightSourceLocationClick.tbZ.Text));
            On_MainForm_Paint(null, null);
        }

        private void On_miSave_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            S.SerializeShapes(PATHTO_SERIALIZED_STATE, objectsToDraw);
            Cursor.Current = Cursors.Default;
        }

        private void On_miReload_Click(object sender, EventArgs e)
        {
            objectsToDraw = S.DeserializeShapes(PATHTO_SERIALIZED_STATE);
            On_MainForm_Paint(null, null);
        }

        private void On_cbUseDirectX_CheckedChanged(object sender, EventArgs e)
        {
            On_MainForm_Paint(null, null);
        }

        private void On_cbHideEdges_CheckedChanged(object sender, EventArgs e)
        {
            ReInitPolyShape();
        }

        private void On_cbFill_CheckedChanged(object sender, EventArgs e)
        {
            On_MainForm_Paint(null, null);
        }

        private void On_cbDrawEdges_CheckedChanged(object sender, EventArgs e)
        {
            On_MainForm_Paint(null, null);
        }
        #endregion

        #region Actions with objects

        private void DrawObjects(IEnumerable<BaseShape> objsToDraw)
        {
            foreach (var obj in objsToDraw)
            {
                obj.Draw(CreateGraphics(), lightSource, COLOR_TO_DRAW, cbFill.Checked, cbDrawEdges.Checked);
            }
        }

        private void DrawObjectsWithoutHiddenEdges()
        {
            ReInitPolyShape();
            polyShape.Draw(CreateGraphics(), lightSource, COLOR_TO_DRAW, cbFill.Checked, cbDrawEdges.Checked);
        }

        public void DrawObjectsWithDX(IEnumerable<BaseShape> objsToDraw)
        {
            device.Clear(ClearFlags.Target, Color.White, 1.0f, 0);
            device.BeginScene();

            foreach (var obj in objsToDraw)
            {
                obj.Draw(device, lightSource, COLOR_TO_DRAW, cbFill.Checked, cbDrawEdges.Checked);
            }
            device.EndScene();
            device.Present();
        }

        public void DrawObjectsWithDXWithoutHiddenEdges(List<BaseShape> objsToDraw)
        {
            //ReInitPolyShape();

            //device.Clear(ClearFlags.Target, Color.White, 1.0f, 0);
            //device.BeginScene();
            //polyShape.SaveState();
            //polyShape.Draw(device, lightSource, COLOR_TO_DRAW, cbFill.Checked, cbDrawEdges.Checked);
            //objsToDraw[0].Draw(device, lightSource, COLOR_TO_DRAW, cbFill.Checked, cbDrawEdges.Checked);

            //device.EndScene();
            //device.Present();

            // do not work for projections
            var coordinateAxes = objsToDraw[0];
            objsToDraw.Sort(CompareShapesByDepth);
            objsToDraw.Remove(coordinateAxes);
            objsToDraw.Insert(0, coordinateAxes);
            DrawObjectsWithDX(objsToDraw);
        }

        private void EraseObjects(IEnumerable<BaseShape> objsToDraw)
        {
            foreach (var obj in objsToDraw)
            {
                obj.Erase(CreateGraphics());
            }
        }

        private void RotateObjects(IEnumerable<BaseShape> objsToDraw, double rotAngleX, double rotAngleY, double rotAngleZ)
        {
            foreach (var obj in objsToDraw)
            {
                obj.Rotate(basePoint, rotAngleX, rotAngleY, rotAngleZ);
                // obj.Rotate(new Point3D((float)Width / 2, (float)Height / 2, 0), rotAngleX, rotAngleY, rotAngleZ);
            }
        }

        private void ScaleObjects(IEnumerable<BaseShape> objsToDraw, float scale)
        {
            foreach (var obj in objsToDraw)
            {
                obj.Scale(basePoint, scale);
            }
        }

        private static void MoveObjects(IEnumerable<BaseShape> objsToDraw, float dX, float dY, float dZ)
        {
            foreach (var obj in objsToDraw)
            {
                obj.Move(dX, dY, dZ);
            }
        }

        private static void SaveObjectsState(IEnumerable<BaseShape> objsToDraw)
        {
            foreach (var obj in objsToDraw)
            {
                obj.SaveState();
            }
        }

        private void MoveSceneToScreensCenter()
        {
            var curBasePoint = ((CoordinateAxises)objectsToDraw[0]).BasePoint;

            var dx = (float)Width / 2 - curBasePoint.X;
            var dy = (float)Height / 2 - curBasePoint.Y;

            SaveObjectsState(objectsToDraw);
            MoveObjects(objectsToDraw, dx, -dy, 0);
        }
        #endregion

        private static double GetZRotateAngle(PointF basePoint, PointF aimPoint)
        {
            var dX = aimPoint.X - basePoint.X;
            var dY = basePoint.Y - aimPoint.Y;
            if (dY == 0 && dX > 0)
                return 0;
            if (dY == 0 && dX < 0)
                return Math.PI;

            var dySign = dY / Math.Abs(dY);

            if (dySign < 0)
                return Math.PI + Math.Acos(dX * dySign / Math.Sqrt(dY * dY + dX * dX));

            return Math.Acos(dX * dySign / Math.Sqrt(dY * dY + dX * dX));
        }

        private void ReInitPolyShape()
        {

            var allSides = new List<Polygon>();

            for (var i = 1; i < objectsToDraw.Count; i++)
            {
                allSides.AddRange(objectsToDraw[i].sides);
            }

            allSides.Sort(ComparePolygonsByDepth);

            polyShape = new BaseShape { sides = allSides };
        }

        private static int ComparePolygonsByDepth(Polygon one, Polygon two)
        {
            if (one == null)
            {
                if (two == null)
                {
                    // If one is null and two is null, they're
                    // equal. 
                    return 0;
                }
                else
                {
                    // If one is null and two is not null, two
                    // is greater. 
                    return -1;
                }
            }
            else
            {
                // If one is not null...
                //
                if (two == null)
                // ...and two is null, one is greater.
                {
                    return 1;
                }
                else
                {
                    // ...and two is not null, compare the 
                    // lengths of the two strings.
                    //
                    return one.Depth.CompareTo(two.Depth);
                }
            }
        }

        private static int CompareShapesByDepth(BaseShape one, BaseShape two)
        {
            if (one == null)
            {
                if (two == null)
                {
                    return 0;
                }
                return -1;
            }
            return two == null ? 1 : one.Depth.CompareTo(two.Depth);
            // return one.NearestVertex.CompareTo(two.NearestVertex);
        }
    }
}
