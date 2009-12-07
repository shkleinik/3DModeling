

using Modeling.Core.Elements;

namespace Modeling.UI.Forms.Light
{
    using System;
    using System.Windows.Forms;

    public partial class ChangeLightSourceLocationForm : Form
    {
        public ChangeLightSourceLocationForm(Vertex lightSource)
        {
            InitializeComponent();
            tbX.Text = lightSource.X.ToString();
            tbY.Text = lightSource.Y.ToString();
            tbZ.Text = lightSource.Z.ToString();
        }

        private void On_moveLightSource_Click(object sender, EventArgs e)
        {
            float X;
            float Y;
            float Z;

            if (Single.TryParse(tbX.Text, out X) && Single.TryParse(tbY.Text, out Y) && Single.TryParse(tbZ.Text, out Z))
            {
                DialogResult = DialogResult.OK;
                return;
            }

            MessageBox.Show("Input string has incorrect format, please correct", "Argument exception");
        }
    }
}
