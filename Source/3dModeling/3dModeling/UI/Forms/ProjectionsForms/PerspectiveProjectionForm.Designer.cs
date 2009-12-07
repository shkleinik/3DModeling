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
            this.lblTetta = new System.Windows.Forms.Label();
            this.tbTetta = new System.Windows.Forms.TextBox();
            this.lblPhi = new System.Windows.Forms.Label();
            this.tbPhi = new System.Windows.Forms.TextBox();
            this.lblR = new System.Windows.Forms.Label();
            this.tbR = new System.Windows.Forms.TextBox();
            this.lblD = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblPerspectiveProjectionInfo
            // 
            this.lblPerspectiveProjectionInfo.AutoSize = true;
            this.lblPerspectiveProjectionInfo.Location = new System.Drawing.Point(13, 13);
            this.lblPerspectiveProjectionInfo.Name = "lblPerspectiveProjectionInfo";
            this.lblPerspectiveProjectionInfo.Size = new System.Drawing.Size(200, 13);
            this.lblPerspectiveProjectionInfo.TabIndex = 0;
            this.lblPerspectiveProjectionInfo.Text = "Enter perspective projection parameters :";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(18, 173);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(156, 23);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "Draw perspective projection";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.On_btnOk_Click);
            // 
            // tbD
            // 
            this.tbD.Location = new System.Drawing.Point(59, 126);
            this.tbD.Name = "tbD";
            this.tbD.Size = new System.Drawing.Size(100, 20);
            this.tbD.TabIndex = 0;
            this.tbD.Text = "1000";
            // 
            // lblTetta
            // 
            this.lblTetta.AutoSize = true;
            this.lblTetta.Location = new System.Drawing.Point(15, 36);
            this.lblTetta.Name = "lblTetta";
            this.lblTetta.Size = new System.Drawing.Size(38, 13);
            this.lblTetta.TabIndex = 2;
            this.lblTetta.Text = "Tetta :";
            // 
            // tbTetta
            // 
            this.tbTetta.Location = new System.Drawing.Point(59, 36);
            this.tbTetta.Name = "tbTetta";
            this.tbTetta.Size = new System.Drawing.Size(100, 20);
            this.tbTetta.TabIndex = 3;
            this.tbTetta.Text = "0";
            // 
            // lblPhi
            // 
            this.lblPhi.AutoSize = true;
            this.lblPhi.Location = new System.Drawing.Point(15, 68);
            this.lblPhi.Name = "lblPhi";
            this.lblPhi.Size = new System.Drawing.Size(28, 13);
            this.lblPhi.TabIndex = 4;
            this.lblPhi.Text = "Phi :";
            // 
            // tbPhi
            // 
            this.tbPhi.Location = new System.Drawing.Point(59, 66);
            this.tbPhi.Name = "tbPhi";
            this.tbPhi.Size = new System.Drawing.Size(100, 20);
            this.tbPhi.TabIndex = 5;
            this.tbPhi.Text = "10";
            // 
            // lblR
            // 
            this.lblR.AutoSize = true;
            this.lblR.Location = new System.Drawing.Point(15, 100);
            this.lblR.Name = "lblR";
            this.lblR.Size = new System.Drawing.Size(21, 13);
            this.lblR.TabIndex = 6;
            this.lblR.Text = "R :";
            // 
            // tbR
            // 
            this.tbR.Location = new System.Drawing.Point(59, 96);
            this.tbR.Name = "tbR";
            this.tbR.Size = new System.Drawing.Size(100, 20);
            this.tbR.TabIndex = 7;
            this.tbR.Text = "700";
            // 
            // lblD
            // 
            this.lblD.AutoSize = true;
            this.lblD.Location = new System.Drawing.Point(15, 132);
            this.lblD.Name = "lblD";
            this.lblD.Size = new System.Drawing.Size(21, 13);
            this.lblD.TabIndex = 8;
            this.lblD.Text = "D :";
            // 
            // PerspectiveProjectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(203, 208);
            this.Controls.Add(this.lblD);
            this.Controls.Add(this.tbR);
            this.Controls.Add(this.lblR);
            this.Controls.Add(this.tbPhi);
            this.Controls.Add(this.lblPhi);
            this.Controls.Add(this.tbTetta);
            this.Controls.Add(this.lblTetta);
            this.Controls.Add(this.tbD);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.lblPerspectiveProjectionInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PerspectiveProjectionForm";
            this.Text = "Perspective projection parameters";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPerspectiveProjectionInfo;
        private System.Windows.Forms.Button btnOk;
        public System.Windows.Forms.TextBox tbD;
        private System.Windows.Forms.Label lblTetta;
        public System.Windows.Forms.TextBox tbTetta;
        private System.Windows.Forms.Label lblPhi;
        public System.Windows.Forms.TextBox tbPhi;
        private System.Windows.Forms.Label lblR;
        public System.Windows.Forms.TextBox tbR;
        private System.Windows.Forms.Label lblD;
    }
}