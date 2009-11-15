namespace Modeling.UI.Controls
{
    partial class AnglesTracker
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblAlpha = new System.Windows.Forms.Label();
            this.lblBeta = new System.Windows.Forms.Label();
            this.lblGamma = new System.Windows.Forms.Label();
            this.lblAlphaValue = new System.Windows.Forms.Label();
            this.lblBetaValue = new System.Windows.Forms.Label();
            this.lblGammaValue = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblAlpha
            // 
            this.lblAlpha.AutoSize = true;
            this.lblAlpha.Location = new System.Drawing.Point(7, 18);
            this.lblAlpha.Name = "lblAlpha";
            this.lblAlpha.Size = new System.Drawing.Size(49, 13);
            this.lblAlpha.TabIndex = 0;
            this.lblAlpha.Text = "Alpha   : ";
            // 
            // lblBeta
            // 
            this.lblBeta.AutoSize = true;
            this.lblBeta.Location = new System.Drawing.Point(7, 41);
            this.lblBeta.Name = "lblBeta";
            this.lblBeta.Size = new System.Drawing.Size(47, 13);
            this.lblBeta.TabIndex = 1;
            this.lblBeta.Text = "Beta     :";
            // 
            // lblGamma
            // 
            this.lblGamma.AutoSize = true;
            this.lblGamma.Location = new System.Drawing.Point(7, 64);
            this.lblGamma.Name = "lblGamma";
            this.lblGamma.Size = new System.Drawing.Size(49, 13);
            this.lblGamma.TabIndex = 2;
            this.lblGamma.Text = "Gamma :";
            // 
            // lblAlphaValue
            // 
            this.lblAlphaValue.AutoSize = true;
            this.lblAlphaValue.Location = new System.Drawing.Point(56, 18);
            this.lblAlphaValue.Name = "lblAlphaValue";
            this.lblAlphaValue.Size = new System.Drawing.Size(13, 13);
            this.lblAlphaValue.TabIndex = 3;
            this.lblAlphaValue.Text = "0";
            // 
            // lblBetaValue
            // 
            this.lblBetaValue.AutoSize = true;
            this.lblBetaValue.Location = new System.Drawing.Point(56, 41);
            this.lblBetaValue.Name = "lblBetaValue";
            this.lblBetaValue.Size = new System.Drawing.Size(13, 13);
            this.lblBetaValue.TabIndex = 4;
            this.lblBetaValue.Text = "0";
            // 
            // lblGammaValue
            // 
            this.lblGammaValue.AutoSize = true;
            this.lblGammaValue.Location = new System.Drawing.Point(56, 64);
            this.lblGammaValue.Name = "lblGammaValue";
            this.lblGammaValue.Size = new System.Drawing.Size(13, 13);
            this.lblGammaValue.TabIndex = 5;
            this.lblGammaValue.Text = "0";
            // 
            // AnglesTracker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.lblGammaValue);
            this.Controls.Add(this.lblBetaValue);
            this.Controls.Add(this.lblAlphaValue);
            this.Controls.Add(this.lblGamma);
            this.Controls.Add(this.lblBeta);
            this.Controls.Add(this.lblAlpha);
            this.Name = "AnglesTracker";
            this.Size = new System.Drawing.Size(115, 90);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAlpha;
        private System.Windows.Forms.Label lblBeta;
        private System.Windows.Forms.Label lblGamma;
        private System.Windows.Forms.Label lblAlphaValue;
        private System.Windows.Forms.Label lblBetaValue;
        private System.Windows.Forms.Label lblGammaValue;
    }
}
