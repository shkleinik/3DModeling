namespace Modeling.UI.Forms.ProjectionsForms
{
    partial class PerspectiveProjectionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PerspectiveProjectionForm));
            this.lblPerspectiveProjectionInfo = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.tbD = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblPerspectiveProjectionInfo
            // 
            this.lblPerspectiveProjectionInfo.AutoSize = true;
            this.lblPerspectiveProjectionInfo.Location = new System.Drawing.Point(13, 13);
            this.lblPerspectiveProjectionInfo.Name = "lblPerspectiveProjectionInfo";
            this.lblPerspectiveProjectionInfo.Size = new System.Drawing.Size(132, 13);
            this.lblPerspectiveProjectionInfo.TabIndex = 0;
            this.lblPerspectiveProjectionInfo.Text = "Perspective projection info";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(126, 77);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(156, 23);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "Draw perspective projection";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.On_btnOk_Click);
            // 
            // tbD
            // 
            this.tbD.Location = new System.Drawing.Point(16, 46);
            this.tbD.Name = "tbD";
            this.tbD.Size = new System.Drawing.Size(140, 20);
            this.tbD.TabIndex = 0;
            // 
            // PerspectiveProjectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 112);
            this.Controls.Add(this.tbD);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.lblPerspectiveProjectionInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PerspectiveProjectionForm";
            this.Text = "PerspectiveProjectionForm";
            this.Load += new System.EventHandler(this.On_PerspectiveProjectionForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPerspectiveProjectionInfo;
        private System.Windows.Forms.Button btnOk;
        public System.Windows.Forms.TextBox tbD;
    }
}