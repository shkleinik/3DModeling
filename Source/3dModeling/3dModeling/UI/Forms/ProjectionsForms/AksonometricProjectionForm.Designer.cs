namespace Modeling.UI.Forms.ProjectionsForms
{
    partial class AksonometricProjectionForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AksonometricProjectionForm));
            this.lblPsi = new System.Windows.Forms.Label();
            this.lblPhi = new System.Windows.Forms.Label();
            this.tbPsi = new System.Windows.Forms.TextBox();
            this.tbPhi = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblPsi
            // 
            this.lblPsi.AutoSize = true;
            this.lblPsi.Location = new System.Drawing.Point(13, 29);
            this.lblPsi.Name = "lblPsi";
            this.lblPsi.Size = new System.Drawing.Size(54, 13);
            this.lblPsi.TabIndex = 0;
            this.lblPsi.Text = "Enter psi :";
            // 
            // lblPhi
            // 
            this.lblPhi.AutoSize = true;
            this.lblPhi.Location = new System.Drawing.Point(12, 62);
            this.lblPhi.Name = "lblPhi";
            this.lblPhi.Size = new System.Drawing.Size(55, 13);
            this.lblPhi.TabIndex = 1;
            this.lblPhi.Text = "Enter phi :";
            // 
            // tbPsi
            // 
            this.tbPsi.Location = new System.Drawing.Point(67, 29);
            this.tbPsi.Name = "tbPsi";
            this.tbPsi.Size = new System.Drawing.Size(139, 20);
            this.tbPsi.TabIndex = 2;
            // 
            // tbPhi
            // 
            this.tbPhi.Location = new System.Drawing.Point(67, 59);
            this.tbPhi.Name = "tbPhi";
            this.tbPhi.Size = new System.Drawing.Size(139, 20);
            this.tbPhi.TabIndex = 3;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(12, 99);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(210, 23);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "Push me to build aksonometric projection";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.On_btnOk_Click);
            // 
            // AksonometricProjectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 134);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.tbPhi);
            this.Controls.Add(this.tbPsi);
            this.Controls.Add(this.lblPhi);
            this.Controls.Add(this.lblPsi);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AksonometricProjectionForm";
            this.Text = "AksonometricProjectionForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPsi;
        private System.Windows.Forms.Label lblPhi;
        public System.Windows.Forms.TextBox tbPsi;
        public System.Windows.Forms.TextBox tbPhi;
        private System.Windows.Forms.Button btnOk;
    }
}