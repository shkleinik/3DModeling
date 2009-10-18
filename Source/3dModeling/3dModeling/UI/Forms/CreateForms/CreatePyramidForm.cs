using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Modeling.Core.Elements;
using Modeling.Core.Shapes;

namespace Modeling.UI.Forms.CreateForms
{
    public partial class CreatePyramidForm : Form
    {
        private const string ERROR_MESSAGEBOX_TITLE = "Walash Software : Error";

        private readonly List<BaseShape> objects3D;

        public CreatePyramidForm()
        {
            InitializeComponent();
        }

        public CreatePyramidForm(List<BaseShape> objects3D)
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

                var newBasePoint = new Point3D(bP.X + xDisplacement, bP.Y + yDisplacement, bP.Z + zDisplacement);

                var sidesNumber = Convert.ToInt32((string) tbSidesNumber.Text);
                var radius = Convert.ToUInt32((string) tbRadius.Text);
                var height = Convert.ToSingle((string) tbHeight.Text);
                var pyramid = new Pyramid(newBasePoint, sidesNumber, radius, height);
                objects3D.Add(pyramid);
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message, ERROR_MESSAGEBOX_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Close();
        }

        public Point3D GetBasePoint()
        {
            return ((CoordinateAxises)objects3D[0]).BasePoint;
        }
    }
}