namespace Modeling.UI.Forms.Light
{
    partial class ChangeLightSourceLocationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangeLightSourceLocationForm));
            this.btnOk = new System.Windows.Forms.Button();
            this.lblX = new System.Windows.Forms.Label();
            this.tbX = new System.Windows.Forms.TextBox();
            this.lblY = new System.Windows.Forms.Label();
            this.tbY = new System.Windows.Forms.TextBox();
            this.lblZ = new System.Windows.Forms.Label();
            this.tbZ = new System.Windows.Forms.TextBox();
            this.lblHelp = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(101, 81);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(121, 23);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "Move light source";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.On_moveLightSource_Click);
            // 
            // lblX
            // 
            this.lblX.AutoSize = true;
            this.lblX.Location = new System.Drawing.Point(13, 48);
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(20, 13);
            this.lblX.TabIndex = 1;
            this.lblX.Text = "X :";
            // 
            // tbX
            // 
            this.tbX.Location = new System.Drawing.Point(39, 44);
            this.tbX.Name = "tbX";
            this.tbX.Size = new System.Drawing.Size(33, 20);
            this.tbX.TabIndex = 2;
            this.tbX.Text = "-1000";
            // 
            // lblY
            // 
            this.lblY.AutoSize = true;
            this.lblY.Location = new System.Drawing.Point(78, 48);
            this.lblY.Name = "lblY";
            this.lblY.Size = new System.Drawing.Size(20, 13);
            this.lblY.TabIndex = 3;
            this.lblY.Text = "Y :";
            // 
            // tbY
            // 
            this.tbY.Location = new System.Drawing.Point(104, 44);
            this.tbY.Name = "tbY";
            this.tbY.Size = new System.Drawing.Size(35, 20);
            this.tbY.TabIndex = 4;
            this.tbY.Text = "0";
            // 
            // lblZ
            // 
            this.lblZ.AutoSize = true;
            this.lblZ.Location = new System.Drawing.Point(145, 48);
            this.lblZ.Name = "lblZ";
            this.lblZ.Size = new System.Drawing.Size(20, 13);
            this.lblZ.TabIndex = 5;
            this.lblZ.Text = "Z :";
            // 
            // tbZ
            // 
            this.tbZ.Location = new System.Drawing.Point(171, 44);
            this.tbZ.Name = "tbZ";
            this.tbZ.Size = new System.Drawing.Size(34, 20);
            this.tbZ.TabIndex = 6;
            this.tbZ.Text = "0";
            // 
            // lblHelp
            // 
            this.lblHelp.AutoSize = true;
            this.lblHelp.Location = new System.Drawing.Point(16, 13);
            this.lblHelp.Name = "lblHelp";
            this.lblHelp.Size = new System.Drawing.Size(167, 13);
            this.lblHelp.TabIndex = 7;
            this.lblHelp.Text = "Enter new location for light source";
            // 
            // ChangeLightSourceLocationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 116);
            this.Controls.Add(this.lblHelp);
            this.Controls.Add(this.tbZ);
            this.Controls.Add(this.lblZ);
            this.Controls.Add(this.tbY);
            this.Controls.Add(this.lblY);
            this.Controls.Add(this.tbX);
            this.Controls.Add(this.lblX);
            this.Controls.Add(this.btnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChangeLightSourceLocationForm";
            this.Text = "Change light source location";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label lblX;
        public System.Windows.Forms.TextBox tbX;
        private System.Windows.Forms.Label lblY;
        public System.Windows.Forms.TextBox tbY;
        private System.Windows.Forms.Label lblZ;
        public System.Windows.Forms.TextBox tbZ;
        private System.Windows.Forms.Label lblHelp;
    }
}