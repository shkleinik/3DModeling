using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Xml.Serialization;
using Modeling.Core.Elements;
using Modeling.Core.Shapes;
using T = Modeling.Core.Transformations;

namespace Modeling.UI.Forms
{
    public partial class MainForm : Form
    {
        #region Constants
        private const int DEFAULT_GRID_STEP = 30;
        private const int MIN_GRID_STEP = 5;
        private const int MAX_GRID_STEP = 100;
        private const int SCALE_STEP = 2;
        private const string PATHTO_ROTATE_CURSOR = "RotateCursor.cur";//"..\\..\\Icons\\RotateCursor.cur";
        private const string PATHTO_SERIALIZED_STATE = "Walash.3Dscene";
        #endregion

        #region Fields
        private readonly List<Type> extraTypes = new List<Type> { typeof(Cone), typeof(Cube), typeof(Pyramid), typeof(CoordinateAxises) };
        private readonly Point gridStartPoint = new Point(10, 10);
        private readonly List<PointF> listOfVertexes = new List<PointF>();
        private List<BaseShape> objectsToDraw;
        private Point3D basePoint;
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
        #endregion

        #region Private Methods
        /// <summary>
        /// This method draws big red point at specified coordinates
        /// </summary>
        /// <param name="BasePoint"></param>
        private void DrawBasePoint(PointF BasePoint)
        {
            Graphics g = CreateGraphics();
            g.FillEllipse(Brushes.Red, BasePoint.X - 5, BasePoint.Y - 5, 10, 10);
            g.FillEllipse(Brushes.Green, moveStartPoint.X - 5, moveStartPoint.Y - 5, 10, 10);
        }
        #endregion

        #region Handling Form Events
        private void On_MainForm_Load(object sender, EventArgs e)
        {
            basePoint = new Point3D((float)Width / 2, (float)Height / 2);
            moveStartPoint = basePoint;

            var cube = new Cube(new Point3D(basePoint.X - 80, basePoint.Y, basePoint.Z), 50);
            var pyramid = new Pyramid(basePoint, 3, 50, 100);
            var cone = new Cone(basePoint, 25, -50);
            var axises = new CoordinateAxises(basePoint);

            //objectsToDraw = new List<BaseShape> { axises, pyramid, cone, cube };
            objectsToDraw = DeserializeShapes(PATHTO_SERIALIZED_STATE);
            SaveObjectsState(objectsToDraw);
        }

        private void On_MainForm_Closing(object sender, FormClosingEventArgs e)
        {

        }

        private void On_MainForm_Paint(object sender, PaintEventArgs e)
        {
            EraseObjects(objectsToDraw);
            DrawObjects(objectsToDraw);
            //DrawBasePoint(basePoint);
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
                    //listOfVertexes.Add(e.Location);
                    break;
                case MouseButtons.Right:
                    basePoint = new Point3D(e.Location);
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
                    //Console.WriteLine("angleToRotate = {0:F2}, dynamicAngle  = {1:F2},rotateStartAngle = {2:F2} ", angleToRotate * 180 / Math.PI, dynamicAngle * 180 / Math.PI, rotateStartAngle * 180 / Math.PI);
                    RotateObjects(objectsToDraw, 0, -rotAngleX, rotAngleY);//rotAngleX rotAngleY, 0);// rotAngleZ);
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
                    Cursor = new Cursor(PATHTO_ROTATE_CURSOR);
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
        }

        private void On_miYZ_Click(object sender, EventArgs e)
        {
            foreach (var shape in objectsToDraw)
            {
                shape.YZProjection();
            }
        }

        private void On_miXZ_Click(object sender, EventArgs e)
        {
            foreach (var shape in objectsToDraw)
            {
                shape.XZProjection();
            }

        }

        private void On_miSave_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            SerializeShapes(PATHTO_SERIALIZED_STATE, objectsToDraw);
            Cursor.Current = Cursors.Default;
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

        #region Serializtion
        private void SerializeShapes(string path, List<BaseShape> shapes)
        {
            Stream writer = new FileStream(path, FileMode.Create);
            try
            {
                var serializer = new XmlSerializer(typeof(List<BaseShape>), extraTypes.ToArray());
                serializer.Serialize(writer, shapes);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                writer.Close();
            }
        }

        private List<BaseShape> DeserializeShapes(string path)
        {
            Stream reader = new FileStream(PATHTO_SERIALIZED_STATE, FileMode.Open, FileAccess.Read);
            try
            {
                var serializer = new XmlSerializer(typeof(List<BaseShape>), extraTypes.ToArray());
                return (List<BaseShape>)serializer.Deserialize(reader);
            }
            catch (Exception)
            {
                return new List<BaseShape>();
            }
            finally
            {
                reader.Close();
            }
        }
        #endregion
    }
}