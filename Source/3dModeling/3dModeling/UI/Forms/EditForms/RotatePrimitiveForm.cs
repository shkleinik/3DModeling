using System;
using System.Collections.Generic;
using System.Windows.Forms;
using C = Modeling.UI.Constants;

namespace Modeling.UI.Forms.EditForms
{
    public partial class RotatePrimitiveForm : Form
    {
        private readonly List<float> angles;

        public RotatePrimitiveForm()
        {
            InitializeComponent();
        }

        public RotatePrimitiveForm(out List<float>  angles)
        {
            InitializeComponent();
            angles = new List<float>();
            this.angles = angles;
        }

        private void On_btnRotate_Click(object sender, EventArgs e)
        {
            try
            {
                angles.Add(Convert.ToSingle(tbAlpha.Text));
                angles.Add(Convert.ToSingle(tbBeta.Text));
                angles.Add(Convert.ToSingle(tbGama.Text));
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message, C.ERROR_MESSAGEBOX_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Close();
        }

        private void On_btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
