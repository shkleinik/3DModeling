namespace Modeling.UI.Forms.CreateForms
{
    partial class CreateConeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateConeForm));
            this.lblRadius = new System.Windows.Forms.Label();
            this.tbRadius = new System.Windows.Forms.TextBox();
            this.lblHeight = new System.Windows.Forms.Label();
            this.tbHeight = new System.Windows.Forms.TextBox();
            this.lblBasePoint = new System.Windows.Forms.Label();
            this.lblX = new System.Windows.Forms.Label();
            this.tbX = new System.Windows.Forms.TextBox();
            this.lblY = new System.Windows.Forms.Label();
            this.tbY = new System.Windows.Forms.TextBox();
            this.lblZ = new System.Windows.Forms.Label();
            this.tbZ = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblRadius
            // 
            this.lblRadius.AutoSize = true;
            this.lblRadius.Location = new System.Drawing.Point(13, 13);
            this.lblRadius.Name = "lblRadius";
            this.lblRadius.Size = new System.Drawing.Size(43, 13);
            this.lblRadius.TabIndex = 0;
            this.lblRadius.Text = "Radius:";
            // 
            // tbRadius
            // 
            this.tbRadius.Location = new System.Drawing.Point(74, 13);
            this.tbRadius.Name = "tbRadius";
            this.tbRadius.Size = new System.Drawing.Size(100, 20);
            this.tbRadius.TabIndex = 1;
            // 
            // lblHeight
            // 
            this.lblHeight.AutoSize = true;
            this.lblHeight.Location = new System.Drawing.Point(13, 42);
            this.lblHeight.Name = "lblHeight";
            this.lblHeight.Size = new System.Drawing.Size(41, 13);
            this.lblHeight.TabIndex = 2;
            this.lblHeight.Text = "Height:";
            // 
            // tbHeight
            // 
            this.tbHeight.Location = new System.Drawing.Point(74, 39);
            this.tbHeight.Name = "tbHeight";
            this.tbHeight.Size = new System.Drawing.Size(100, 20);
            this.tbHeight.TabIndex = 2;
            // 
            // lblBasePoint
            // 
            this.lblBasePoint.AutoSize = true;
            this.lblBasePoint.Location = new System.Drawing.Point(16, 73);
            this.lblBasePoint.Name = "lblBasePoint";
            this.lblBasePoint.Size = new System.Drawing.Size(58, 13);
            this.lblBasePoint.TabIndex = 4;
            this.lblBasePoint.Text = "BasePoint:";
            // 
            // lblX
            // 
            this.lblX.AutoSize = true;
            this.lblX.Location = new System.Drawing.Point(74, 73);
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(17, 13);
            this.lblX.TabIndex = 5;
            this.lblX.Text = "X:";
            // 
            // tbX
            // 
            this.tbX.Location = new System.Drawing.Point(97, 73);
            this.tbX.Name = "tbX";
            this.tbX.Size = new System.Drawing.Size(30, 20);
            this.tbX.TabIndex = 3;
            this.tbX.Text = "0";
            // 
            // lblY
            // 
            this.lblY.AutoSize = true;
            this.lblY.Location = new System.Drawing.Point(133, 76);
            this.lblY.Name = "lblY";
            this.lblY.Size = new System.Drawing.Size(17, 13);
            this.lblY.TabIndex = 7;
            this.lblY.Text = "Y:";
            // 
            // tbY
            // 
            this.tbY.Location = new System.Drawing.Point(156, 73);
            this.tbY.Name = "tbY";
            this.tbY.Size = new System.Drawing.Size(30, 20);
            this.tbY.TabIndex = 4;
            this.tbY.Text = "0";
            // 
            // lblZ
            // 
            this.lblZ.AutoSize = true;
            this.lblZ.Location = new System.Drawing.Point(192, 76);
            this.lblZ.Name = "lblZ";
            this.lblZ.Size = new System.Drawing.Size(17, 13);
            this.lblZ.TabIndex = 9;
            this.lblZ.Text = "Z:";
            // 
            // tbZ
            // 
            this.tbZ.Location = new System.Drawing.Point(215, 76);
            this.tbZ.Name = "tbZ";
            this.tbZ.Size = new System.Drawing.Size(30, 20);
            this.tbZ.TabIndex = 5;
            this.tbZ.Text = "0";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(197, 137);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 11;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.On_btnAdd_Click);
            // 
            // CreateConeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 172);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.tbZ);
            this.Controls.Add(this.lblZ);
            this.Controls.Add(this.tbY);
            this.Controls.Add(this.lblY);
            this.Controls.Add(this.tbX);
            this.Controls.Add(this.lblX);
            this.Controls.Add(this.lblBasePoint);
            this.Controls.Add(this.tbHeight);
            this.Controls.Add(this.lblHeight);
            this.Controls.Add(this.tbRadius);
            this.Controls.Add(this.lblRadius);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CreateConeForm";
            this.Text = "Create Cone";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRadius;
        private System.Windows.Forms.TextBox tbRadius;
        private System.Windows.Forms.Label lblHeight;
        private System.Windows.Forms.TextBox tbHeight;
        private System.Windows.Forms.Label lblBasePoint;
        private System.Windows.Forms.Label lblX;
        private System.Windows.Forms.TextBox tbX;
        private System.Windows.Forms.Label lblY;
        private System.Windows.Forms.TextBox tbY;
        private System.Windows.Forms.Label lblZ;
        private System.Windows.Forms.TextBox tbZ;
        private System.Windows.Forms.Button btnAdd;
    }
}