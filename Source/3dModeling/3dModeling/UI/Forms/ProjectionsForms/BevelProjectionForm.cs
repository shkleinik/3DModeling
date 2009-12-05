using System;
using System.Windows.Forms;

namespace Modeling.UI.Forms.ProjectionsForms
{
    public partial class BevelProjectionForm : Form
    {
        public BevelProjectionForm()
        {
            InitializeComponent();
        }

        private void On_btnOk_Click(object sender, EventArgs e)
        {
            if(tbL.Text == string.Empty)
                return;
            if(lblAlfha.Text == string.Empty)
                return;

            DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
