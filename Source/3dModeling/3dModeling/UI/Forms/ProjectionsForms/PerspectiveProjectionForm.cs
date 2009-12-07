namespace Modeling.UI.Forms.ProjectionsForms
{
    using System;
    using System.Windows.Forms;

    public partial class PerspectiveProjectionForm : Form
    {
        public PerspectiveProjectionForm()
        {
            InitializeComponent();
        }

        private void On_btnOk_Click(object sender, EventArgs e)
        {
            double tetta;
            double phi;
            double r;
            double d;

            if (Double.TryParse(tbTetta.Text, out tetta) && Double.TryParse(tbPhi.Text, out phi) && Double.TryParse(tbR.Text, out r) && Double.TryParse(tbD.Text, out d))
            {
                DialogResult = DialogResult.OK;
                return;
            }

            MessageBox.Show("Input string has incorrect format, please correct", "Argument exception");
        }
    }
}
