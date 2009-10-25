namespace Modeling.UI.Controls
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using Core.Shapes;
    using System.Collections.Generic;
    using System.ComponentModel;
    using Core.Elements;

    public partial class ObjectsTree : UserControl
    {
        #region Constatnts
        private const string OBJECT_REMOVE_CONFIRMATION_MESSAGE = "You are about removing 3D objectd from you scene. Do you want to continue?";
        private const string CONFIRMATION_WINDOW_CAPTION = "Walash Software : Confirmation";
        #endregion

        #region Fields
        private List<BaseShape> objects3D;
        #endregion

        #region Events
        public event MethodInvoker ObjectDeleted;
        #endregion

        #region Constructors
        public ObjectsTree(List<BaseShape> objects3D)
        {
            InitializeComponent();

            this.objects3D = objects3D;
        }
        #endregion

        #region Internal Implementation
        private static string GetShapeType(BaseShape shape)
        {
            var subNameSpaces = shape.ToString().Split('.');
            var indxLast = subNameSpaces.Length - 1;
            return subNameSpaces[indxLast];
        }

        private void PopulateTree()
        {
            foreach (var shape in objects3D)
            {
                var newNode = new TreeNode(GetShapeType(shape));
                PropertyDescriptorCollection shapeProperties = TypeDescriptor.GetProperties(shape);

                foreach (PropertyDescriptor property in shapeProperties)
                {
                    var nodeText = string.Format("{0} = {1}", property.DisplayName, property.GetValue(shape));
                    newNode.Nodes.Add(new TreeNode(nodeText));
                }
                trObjects.Nodes.Add(newNode);
            }
            trObjects.Nodes[0].BackColor = Color.LightGray;
        }

        public void UpdateTree(List<BaseShape> objects3D)
        {
            this.objects3D = objects3D;
            trObjects.Nodes.Clear();
            PopulateTree();
        }

        public void RotateSelectedObject(Point3D bp, float angleX, float angleY, float angleZ)
        {
            if (IsCoordinateAxesSelected())
                return;
            var nodeIndex = trObjects.SelectedNode.Index;
            objects3D[nodeIndex].Rotate(bp, angleX, angleY, angleZ);

        }

        public void ScaleSelectedObject(Point3D bp, float scaleX, float scaleY, float scaleZ)
        {
            if (IsCoordinateAxesSelected())
                return;

            var nodeIndex = trObjects.SelectedNode.Index;
            objects3D[nodeIndex].Scale(bp, scaleX, scaleY, scaleZ);
        }

        public void MoveSelectedObject(float dX, float dY, float dZ)
        {
            if (IsCoordinateAxesSelected())
                return;

            var nodeIndex = trObjects.SelectedNode.Index;
            objects3D[nodeIndex].Move(dX, dY, dZ);

        }
        #endregion

        #region Event handling
        private void On_trObjects_KeyPress(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Delete:
                    if (trObjects.SelectedNode.Level != 0)
                        return;
                    if (trObjects.SelectedNode.Index == 0)
                        return;
                    if (MessageBox.Show(OBJECT_REMOVE_CONFIRMATION_MESSAGE,
                                    CONFIRMATION_WINDOW_CAPTION,
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question,
                                    MessageBoxDefaultButton.Button1
                                    ) != DialogResult.Yes)
                        return;

                    var nodeIndex = trObjects.SelectedNode.Index;
                    trObjects.SelectedNode.Remove();
                    objects3D.RemoveAt(nodeIndex);
                    ObjectDeleted();
                    break;
            }
        }

        public void On_ObjectsTree_Load(object sender, EventArgs e)
        {
            trObjects.KeyDown += On_trObjects_KeyPress;
            PopulateTree();
        }
        #endregion

        #region Auxiliary methods
        public bool IsCoordinateAxesSelected()
        {
            return trObjects.SelectedNode.Level != 0 && trObjects.SelectedNode.Index == 0;

        }
        #endregion
    }
}
