using System;
using System.Windows.Forms;
using Modeling.Core.Shapes;
using System.Collections.Generic;
using System.ComponentModel;

namespace Modeling.UI.Controls
{
    public partial class ObjectsTree : UserControl
    {
        #region Constatnts
        private const string OBJECT_REMOVE_CONFIRMATION_MESSAGE = "You are about removing 3D objectd from you scene. Do you want to continue?";
        private const string CONFIRMATION_WINDOW_CAPTION = "Walash Software : Confirmation";
        #endregion

        private List<BaseShape> objects3D;

        public ObjectsTree(List<BaseShape> objects3D)
        {
            InitializeComponent();

            this.objects3D = objects3D;
        }

        private static string GetShapeType(BaseShape shape)
        {
            var subNameSpaces = shape.ToString().Split('.');
            var indxLast = subNameSpaces.Length - 1;
            return subNameSpaces[indxLast];
        }

        public void On_ObjectsTree_Load(object sender, EventArgs e)
        {
            trObjects.KeyDown += On_trObjects_KeyPress;
            PopulateTree();
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
        }

        public void UpdateTree(List<BaseShape> objects3D)
        {
            this.objects3D = objects3D;
            trObjects.Nodes.Clear();
            PopulateTree();
        }

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

                    break;
            }
        }
    }
}
