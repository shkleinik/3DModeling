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

        private void On_PerspectiveProjectionForm_Load(object sender, EventArgs e)
        {
            lblPerspectiveProjectionInfo.Text =
                "The entered value would be use in the following formula:\n      [X / (Z / d)  Y / (Z / d)  d]\n";
        }

        private void On_btnOk_Click(object sender, EventArgs e)
        {
            float d;
            if (!Single.TryParse(tbD.Text, out d))
            {
                MessageBox.Show("Input string has incorrect format, please correct", "Argument exception");
                return;
            }
            DialogResult = DialogResult.OK;
        }
    }
}
