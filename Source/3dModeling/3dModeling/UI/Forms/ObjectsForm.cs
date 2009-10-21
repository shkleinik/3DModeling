namespace Modeling.UI.Forms
{
    using System.Collections.Generic;
    using System.Windows.Forms;
    using Core.Shapes;
    using Controls;
    using CreateForms;

    public partial class ObjectsForm : Form
    {
        #region Fields
        private readonly List<BaseShape> objects3D;
        private ObjectsTree objsTree;
        #endregion

        #region Constructors
        public ObjectsForm(List<BaseShape> objects3D)
        {
            this.objects3D = objects3D;
            InitializeComponent();
            InitTreeControl();
        }

        public void InitTreeControl()
        {
            objsTree = new ObjectsTree(objects3D);
            objsTree.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            objsTree.Location = new System.Drawing.Point(0, 25);
            objsTree.ObjectDeleted += On_objsTree_ObjectDeleted;
            Controls.Add(objsTree);
        }
        #endregion

        #region Create actions
        private void On_miAddPyramid_Click(object sender, System.EventArgs e)
        {
            (new CreatePyramidForm(objects3D)).ShowDialog();
            objsTree.UpdateTree(objects3D);
            Owner.Invalidate();
        }

        private void On_miAddCone_Click(object sender, System.EventArgs e)
        {
            (new CreateConeForm(objects3D)).ShowDialog();
            objsTree.UpdateTree(objects3D);
            Owner.Invalidate();
        }
        #endregion

        #region Edit actions
        private void On_miMove_Click(object sender, System.EventArgs e)
        {
            if (objsTree.IsCoordinateAxesSelected())
                return;
            List<float> displacements;
            (new EditForms.MovePrimitiveForm(out displacements)).ShowDialog();
            if (displacements.Count == 0)
                return;

            objsTree.MoveSelectedObject(displacements[0], displacements[1], displacements[2]);
            Owner.Invalidate();
        }

        private void On_miScale_Click(object sender, System.EventArgs e)
        {
            if (objsTree.IsCoordinateAxesSelected())
                return;

            List<float> scales;
            (new EditForms.ScalePrimitiveForm(out scales)).ShowDialog();
            if (scales == null)
                return;
            if(scales.Count == 0)
                return;

            CoordinateAxises coorAxises = objects3D[0] as CoordinateAxises;
            objsTree.ScaleSelectedObject(coorAxises.BasePoint, scales[0], scales[1], scales[2]);
            Owner.Invalidate();
        }

        private void On_miRotate_Click(object sender, System.EventArgs e)
        {
            if (objsTree.IsCoordinateAxesSelected())
                return;

            List<float> angles;
            (new EditForms.RotatePrimitiveForm(out angles)).ShowDialog();
            if (angles.Count == 0)
                return;

            CoordinateAxises coorAxises = objects3D[0] as CoordinateAxises;
            objsTree.RotateSelectedObject(coorAxises.BasePoint, angles[0], angles[1], angles[2]);
            Owner.Invalidate();
        }
        #endregion

        #region Events Handling
        private void On_objsTree_ObjectDeleted()
        {
            Owner.Invalidate();
        }
        #endregion
    }
}