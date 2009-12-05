using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Modeling.Core.Elements;
using Modeling.Core.Shapes;
using C=Modeling.UI.Constants;

namespace Modeling.UI.Forms.CreateForms
{
    public partial class CreateConeForm : Form
    {
        private readonly List<BaseShape> objects3D;

        public CreateConeForm()
        {
            InitializeComponent();
        }

        public CreateConeForm(List<BaseShape> objects3D)
        {
            InitializeComponent();
            this.objects3D = objects3D;
        }

        private void On_btnAdd_Click(object sender, EventArgs e)
        {
            var bP = GetBasePoint();
            try
            {
                var xDisplacement = Convert.ToSingle((string) tbX.Text);
                var yDisplacement = Convert.ToSingle((string) tbY.Text);
                var zDisplacement = Convert.ToSingle((string) tbZ.Text);

                var newBasePoint = new Vertex(bP.X + xDisplacement, bP.Y + yDisplacement, bP.Z + zDisplacement);

                
                var radius = Convert.ToUInt32((string) tbRadius.Text);
                var height = Convert.ToSingle((string) tbHeight.Text);
                var cone = new Cone(newBasePoint,  radius, height);
                objects3D.Add(cone);
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message, C.ERROR_MESSAGEBOX_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Close();
        }

        public Vertex GetBasePoint()
        {
            return ((CoordinateAxises)objects3D[0]).BasePoint;
        }
    }
}