using System;
using System.Collections.Generic;
using System.Windows.Forms;
using C = Modeling.UI.Constants;

namespace Modeling.UI.Forms.EditForms
{
    public partial class ScalePrimitiveForm : Form
    {
        private readonly List<float> scales;

        public ScalePrimitiveForm()
        {
            InitializeComponent();
        }

        public ScalePrimitiveForm(out List<float> scales)
        {
            InitializeComponent();
            scales = new List<float>();
            this.scales = scales;
        }


        private void On_btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void On_btnScale_Click(object sender, EventArgs e)
        {
            try
            {
                scales.Add(Convert.ToSingle(tbX.Text));
                scales.Add(Convert.ToSingle(tbY.Text));
                scales.Add(Convert.ToSingle(tbZ.Text));
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message, C.ERROR_MESSAGEBOX_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Close();
        }
    }
}
