using System;
using System.Windows.Forms;

namespace Modeling.UI.Forms.ProjectionsForms
{
    public partial class AksonometricProjectionForm : Form
    {
        public AksonometricProjectionForm()
        {
            InitializeComponent();
        }

        private void On_btnOk_Click(object sender, EventArgs e)
        {
            if(tbPsi.Text == string.Empty)
                return;
            if(tbPhi.Text == string.Empty)
                return;

            DialogResult = DialogResult.OK;
        }
    }
}
