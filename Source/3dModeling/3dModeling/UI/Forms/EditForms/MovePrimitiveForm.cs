using System;
using System.Collections.Generic;
using System.Windows.Forms;
using C = Modeling.UI.Constants;

namespace Modeling.UI.Forms.EditForms
{
    public partial class MovePrimitiveForm : Form
    {
        private readonly List<float> displacements;

        public MovePrimitiveForm()
        {
            InitializeComponent();
        }

        public MovePrimitiveForm(out List<float> displacements)
        {
            InitializeComponent();
            displacements = new List<float>();
            this.displacements = displacements;
        }

        private void On_btnMove_Click(object sender, System.EventArgs e)
        {
            try
            {
                displacements.Add(Convert.ToSingle(tbdX.Text));
                displacements.Add(Convert.ToSingle(tbdY.Text));
                displacements.Add(Convert.ToSingle(tbdZ.Text));
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message, C.ERROR_MESSAGEBOX_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Close();
        }

        private void On_btnCancel_Click(object sender, System.EventArgs e)
        {
            Close();
        }
    }
}
