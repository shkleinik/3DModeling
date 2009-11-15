namespace Modeling.UI.Forms.EditForms
{
    partial class RotatePrimitiveForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RotatePrimitiveForm));
            this.btnRotate = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblTip = new System.Windows.Forms.Label();
            this.lblAngleX = new System.Windows.Forms.Label();
            this.lblBeta = new System.Windows.Forms.Label();
            this.lblGama = new System.Windows.Forms.Label();
            this.tbAlpha = new System.Windows.Forms.TextBox();
            this.tbBeta = new System.Windows.Forms.TextBox();
            this.tbGama = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnRotate
            // 
            this.btnRotate.Location = new System.Drawing.Point(146, 79);
            this.btnRotate.Name = "btnRotate";
            this.btnRotate.Size = new System.Drawing.Size(75, 23);
            this.btnRotate.TabIndex = 3;
            this.btnRotate.Text = "Rotate";
            this.btnRotate.UseVisualStyleBackColor = true;
            this.btnRotate.Click += new System.EventHandler(this.On_btnRotate_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(227, 79);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.On_btnCancel_Click);
            // 
            // lblTip
            // 
            this.lblTip.AutoSize = true;
            this.lblTip.Location = new System.Drawing.Point(13, 13);
            this.lblTip.Name = "lblTip";
            this.lblTip.Size = new System.Drawing.Size(227, 13);
            this.lblTip.TabIndex = 2;
            this.lblTip.Text = "Enter angle for all three axes to ratate primitive:";
            // 
            // lblAngleX
            // 
            this.lblAngleX.AutoSize = true;
            this.lblAngleX.Location = new System.Drawing.Point(12, 38);
            this.lblAngleX.Name = "lblAngleX";
            this.lblAngleX.Size = new System.Drawing.Size(37, 13);
            this.lblAngleX.TabIndex = 3;
            this.lblAngleX.Text = "Alpha:";
            // 
            // lblBeta
            // 
            this.lblBeta.AutoSize = true;
            this.lblBeta.Location = new System.Drawing.Point(110, 38);
            this.lblBeta.Name = "lblBeta";
            this.lblBeta.Size = new System.Drawing.Size(32, 13);
            this.lblBeta.TabIndex = 4;
            this.lblBeta.Text = "Beta:";
            // 
            // lblGama
            // 
            this.lblGama.AutoSize = true;
            this.lblGama.Location = new System.Drawing.Point(194, 38);
            this.lblGama.Name = "lblGama";
            this.lblGama.Size = new System.Drawing.Size(38, 13);
            this.lblGama.TabIndex = 5;
            this.lblGama.Text = "Gamma:";
            // 
            // tbAlpha
            // 
            this.tbAlpha.Location = new System.Drawing.Point(55, 35);
            this.tbAlpha.Name = "tbAlpha";
            this.tbAlpha.Size = new System.Drawing.Size(34, 20);
            this.tbAlpha.TabIndex = 0;
            this.tbAlpha.Text = "0";
            // 
            // tbBeta
            // 
            this.tbBeta.Location = new System.Drawing.Point(148, 35);
            this.tbBeta.Name = "tbBeta";
            this.tbBeta.Size = new System.Drawing.Size(34, 20);
            this.tbBeta.TabIndex = 1;
            this.tbBeta.Text = "0";
            // 
            // tbGama
            // 
            this.tbGama.Location = new System.Drawing.Point(238, 35);
            this.tbGama.Name = "tbGama";
            this.tbGama.Size = new System.Drawing.Size(34, 20);
            this.tbGama.TabIndex = 2;
            this.tbGama.Text = "0";
            // 
            // RotatePrimitiveForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 114);
            this.Controls.Add(this.tbGama);
            this.Controls.Add(this.tbBeta);
            this.Controls.Add(this.tbAlpha);
            this.Controls.Add(this.lblGama);
            this.Controls.Add(this.lblBeta);
            this.Controls.Add(this.lblAngleX);
            this.Controls.Add(this.lblTip);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnRotate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RotatePrimitiveForm";
            this.Text = "Rotate Primitive";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRotate;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblTip;
        private System.Windows.Forms.Label lblAngleX;
        private System.Windows.Forms.Label lblBeta;
        private System.Windows.Forms.Label lblGama;
        private System.Windows.Forms.TextBox tbAlpha;
        private System.Windows.Forms.TextBox tbBeta;
        private System.Windows.Forms.TextBox tbGama;
    }
}