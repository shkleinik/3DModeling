using System.Collections.Generic;
using System.Windows.Forms;
using Modeling.Core.Shapes;
using Modeling.UI.Controls;

namespace Modeling.UI.Forms
{
    public partial class ObjectsForm : Form
    {
        private readonly List<BaseShape> objects3D;
        private ObjectsTree objsTree;

        public ObjectsForm(List<BaseShape> objects3D)
        {
            this.objects3D = objects3D;
            InitializeComponent();
            InitTreeControl();
        }

        private void On_miAddPyramid_Click(object sender, System.EventArgs e)
        {
            (new CreatePyramidForm(objects3D)).ShowDialog();
            objsTree.UpdateTree(objects3D);
        }

        private void On_miAddCone_Click(object sender, System.EventArgs e)
        {
            (new CreateConeForm(objects3D)).ShowDialog();
            objsTree.UpdateTree(objects3D);
        }

        public void InitTreeControl()
        {
            objsTree = new ObjectsTree(objects3D);
            objsTree.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            objsTree.Location = new System.Drawing.Point(0, 25);
            Controls.Add(objsTree);
        }
    }
}