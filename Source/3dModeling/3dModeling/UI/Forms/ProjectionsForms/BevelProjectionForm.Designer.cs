namespace Modeling.UI.Forms.ProjectionsForms
{
    partial class BevelProjectionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BevelProjectionForm));
            this.lblL = new System.Windows.Forms.Label();
            this.lblAlfha = new System.Windows.Forms.Label();
            this.tbL = new System.Windows.Forms.TextBox();
            this.tbAlpha = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblL
            // 
            this.lblL.AutoSize = true;
            this.lblL.Location = new System.Drawing.Point(13, 35);
            this.lblL.Name = "lblL";
            this.lblL.Size = new System.Drawing.Size(47, 13);
            this.lblL.TabIndex = 0;
            this.lblL.Text = "Enter L :";
            // 
            // lblAlfha
            // 
            this.lblAlfha.AutoSize = true;
            this.lblAlfha.Location = new System.Drawing.Point(13, 65);
            this.lblAlfha.Name = "lblAlfha";
            this.lblAlfha.Size = new System.Drawing.Size(67, 13);
            this.lblAlfha.TabIndex = 1;
            this.lblAlfha.Text = "Enter alpha :";
            // 
            // tbL
            // 
            this.tbL.Location = new System.Drawing.Point(95, 32);
            this.tbL.Name = "tbL";
            this.tbL.Size = new System.Drawing.Size(100, 20);
            this.tbL.TabIndex = 2;
            this.tbL.Text = "0,5";
            // 
            // tbAlpha
            // 
            this.tbAlpha.Location = new System.Drawing.Point(95, 62);
            this.tbAlpha.Name = "tbAlpha";
            this.tbAlpha.Size = new System.Drawing.Size(100, 20);
            this.tbAlpha.TabIndex = 3;
            this.tbAlpha.Text = "63";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(13, 119);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(225, 23);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "Push me to build bevel projection";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.On_btnOk_Click);
            // 
            // BevelProjectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(264, 157);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.tbAlpha);
            this.Controls.Add(this.tbL);
            this.Controls.Add(this.lblAlfha);
            this.Controls.Add(this.lblL);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BevelProjectionForm";
            this.Text = "BevelProjectionForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblL;
        private System.Windows.Forms.Label lblAlfha;
        public System.Windows.Forms.TextBox tbL;
        public System.Windows.Forms.TextBox tbAlpha;
        private System.Windows.Forms.Button btnOk;
    }
}