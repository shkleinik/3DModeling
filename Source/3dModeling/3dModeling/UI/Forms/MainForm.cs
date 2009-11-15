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
    using Controls;
    using Core.Elements;
    using Core.Shapes;
    using Microsoft.DirectX.Direct3D;
    using S = Core.Helpers.Serializator;
    using T = Core.Transformations;
    using Microsoft.DirectX.PrivateImplementationDetails;

    public partial class MainForm : Form
    {
        #region Constants
        private const int DEFAULT_GRID_STEP = 30;
        private const int MIN_GRID_STEP = -100;
        private const int MAX_GRID_STEP = 500;
        private const int SCALE_STEP = 2;
        private const string PATHTO_SERIALIZED_STATE = "Walash.3Dscene";
        #endregion

        #region Fields

        private Device device;

        private List<BaseShape> objectsToDraw;
        private Point3D basePoint;
        private PointF moveStartPoint;
        private double rotateStartAngle;

        private int gridStep = DEFAULT_GRID_STEP;
        private bool allowScale = true;
        private bool isControlPressed;
        private AnglesTracker at;

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

            basePoint = new Point3D((float)Width / 2, (float)Height / 2);
            moveStartPoint = basePoint;

            var cube = new Cube(new Point3D(basePoint.X, basePoint.Y, basePoint.Z), 200);
            // var pyramid = new Pyramid(basePoint, 3, 50, 100);
            // var cone = new Cone(basePoint, 25, -50);
            // var axises = new CoordinateAxises(basePoint);
            var cylinder = new Cylinder(basePoint, 100, -200);
            //var prizm = new Prizm(basePoint, 4, (float) (200 / Math.Sqrt(2.0F)), -200);

            objectsToDraw = S.DeserializeShapes(PATHTO_SERIALIZED_STATE) ?? new List<BaseShape> { new CoordinateAxises(basePoint) };
            // objectsToDraw.Add(pyramid);
            // objectsToDraw.Add(cone);
            objectsToDraw.Add(cylinder);
            objectsToDraw.Add(cube);

            SaveObjectsState(objectsToDraw);

            at = new AnglesTracker
                     {
                         Anchor = (AnchorStyles.Bottom | AnchorStyles.Left)
                     };
            at.Location = new Point(0, Height - at.Height - 30);
            Controls.Add(at);
        }

        private void On_MainForm_Closing(object sender, FormClosingEventArgs e)
        {

        }

        private void On_MainForm_Paint(object sender, PaintEventArgs e)
        {
            if (cbUseDirectX.Checked)
            {
                DrawObjectsWithDX(objectsToDraw);
            }
            else
            {
                EraseObjects(objectsToDraw);
                DrawObjects(objectsToDraw);
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

        private void On_MainForm_MouseUp(object sender, MouseEventArgs e)
        {
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
            On_MainForm_Paint(null, null);
        }

        private void On_miYZ_Click(object sender, EventArgs e)
        {
            foreach (var shape in objectsToDraw)
            {
                shape.YZProjection();
            }
            On_MainForm_Paint(null, null);
        }

        private void On_miXZ_Click(object sender, EventArgs e)
        {
            foreach (var shape in objectsToDraw)
            {
                shape.XZProjection();
            }
            On_MainForm_Paint(null, null);
        }

        private void On_miXYintel_Click(object sender, EventArgs e)
        {
            //RotateObjects(objectsToDraw, 0, -((CoordinateAxises)objectsToDraw[0]).Alpha, -((CoordinateAxises)objectsToDraw[0]).Beta);
            //RotateObjects(objectsToDraw, 0, -((CoordinateAxises)objectsToDraw[0]).Alpha + Math.PI / 2, -((CoordinateAxises)objectsToDraw[0]).Beta);
            RotateObjects(objectsToDraw, 0, Math.PI / 2, 0);
            On_MainForm_Paint(null, null);
        }

        private void On_miYZintel_Click(object sender, EventArgs e)
        {
            //RotateObjects(objectsToDraw, 0, -((CoordinateAxises)objectsToDraw[0]).Alpha, -((CoordinateAxises)objectsToDraw[0]).Beta);
            //RotateObjects(objectsToDraw, 0, -((CoordinateAxises)objectsToDraw[0]).Alpha, -((CoordinateAxises)objectsToDraw[0]).Beta + Math.PI / 2);
            RotateObjects(objectsToDraw, 0, 0, Math.PI / 2);
            On_MainForm_Paint(null, null);
        }

        private void On_miXZintel_Click(object sender, EventArgs e)
        {
            basePoint = ((CoordinateAxises)objectsToDraw[0]).BasePoint;
            SaveObjectsState(objectsToDraw);
            // RotateObjects(objectsToDraw, 0, -((CoordinateAxises)objectsToDraw[0]).Alpha, -((CoordinateAxises)objectsToDraw[0]).Beta);
            RotateObjects(objectsToDraw, 0, -((CoordinateAxises)objectsToDraw[0]).Alpha, -((CoordinateAxises)objectsToDraw[0]).Beta);
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
        #endregion

        #region Actions with objects
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

        private void DrawObjects(IEnumerable<BaseShape> objsToDraw)
        {
            foreach (var obj in objsToDraw)
            {
                obj.Draw(CreateGraphics());
            }
        }

        public void DrawObjectsWithDX(IEnumerable<BaseShape> objsToDraw)
        {
            device.Clear(ClearFlags.Target, Color.White, 1.0f, 0);
            device.BeginScene();

            foreach (var obj in objsToDraw)
            {
                obj.Draw(device);
            }
            device.EndScene();
            device.Present();
        }

        private void EraseObjects(IEnumerable<BaseShape> objsToDraw)
        {
            foreach (var obj in objsToDraw)
            {
                obj.Erase(CreateGraphics());
            }
        }

        private void RotateObjects(IList<BaseShape> objsToDraw, double rotAngleX, double rotAngleY, double rotAngleZ)
        {
            var g = CreateGraphics();
            g.DrawString(String.Format("Alpha   : {0}", ((CoordinateAxises)objectsToDraw[0]).Alpha), Font, Brushes.White, 10, Height - 100);
            g.DrawString(String.Format("Beta    : {0}", ((CoordinateAxises)objectsToDraw[0]).Beta), Font, Brushes.White, 10, Height - 90);

            ((CoordinateAxises)objsToDraw[0]).Alpha += rotAngleY;
            ((CoordinateAxises)objsToDraw[0]).Beta += rotAngleZ;

            at.Alpha = ((CoordinateAxises)objsToDraw[0]).Alpha.ToString();
            at.Beta = ((CoordinateAxises)objsToDraw[0]).Beta.ToString();


            g.DrawString(String.Format("Alpha   : {0}", ((CoordinateAxises)objectsToDraw[0]).Alpha), Font, Brushes.Black, 10, Height - 100);
            g.DrawString(String.Format("Beta    : {0}", ((CoordinateAxises)objectsToDraw[0]).Beta), Font, Brushes.Black, 10, Height - 90);

            foreach (var obj in objsToDraw)
            {
                obj.Rotate(basePoint, rotAngleX, rotAngleY, rotAngleZ);
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
        #endregion
    }
}
