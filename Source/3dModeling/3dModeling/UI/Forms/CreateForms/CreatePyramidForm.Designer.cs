namespace Modeling.UI.Forms.CreateForms
{
    partial class CreatePyramidForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreatePyramidForm));
            this.lblRadius = new System.Windows.Forms.Label();
            this.lblHeight = new System.Windows.Forms.Label();
            this.lblBasePoint = new System.Windows.Forms.Label();
            this.tbRadius = new System.Windows.Forms.TextBox();
            this.tbHeight = new System.Windows.Forms.TextBox();
            this.tbX = new System.Windows.Forms.TextBox();
            this.tbY = new System.Windows.Forms.TextBox();
            this.tbZ = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblX = new System.Windows.Forms.Label();
            this.lblY = new System.Windows.Forms.Label();
            this.lblZ = new System.Windows.Forms.Label();
            this.lblSidesNumber = new System.Windows.Forms.Label();
            this.tbSidesNumber = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblRadius
            // 
            this.lblRadius.AutoSize = true;
            this.lblRadius.Location = new System.Drawing.Point(12, 15);
            this.lblRadius.Name = "lblRadius";
            this.lblRadius.Size = new System.Drawing.Size(43, 13);
            this.lblRadius.TabIndex = 0;
            this.lblRadius.Text = "Raduis:";
            // 
            // lblHeight
            // 
            this.lblHeight.AutoSize = true;
            this.lblHeight.Location = new System.Drawing.Point(12, 41);
            this.lblHeight.Name = "lblHeight";
            this.lblHeight.Size = new System.Drawing.Size(41, 13);
            this.lblHeight.TabIndex = 1;
            this.lblHeight.Text = "Height:";
            // 
            // lblBasePoint
            // 
            this.lblBasePoint.AutoSize = true;
            this.lblBasePoint.Location = new System.Drawing.Point(12, 93);
            this.lblBasePoint.Name = "lblBasePoint";
            this.lblBasePoint.Size = new System.Drawing.Size(57, 13);
            this.lblBasePoint.TabIndex = 2;
            this.lblBasePoint.Text = "Basepoint:";
            // 
            // tbRadius
            // 
            this.tbRadius.Location = new System.Drawing.Point(85, 12);
            this.tbRadius.Name = "tbRadius";
            this.tbRadius.Size = new System.Drawing.Size(100, 20);
            this.tbRadius.TabIndex = 1;
            // 
            // tbHeight
            // 
            this.tbHeight.Location = new System.Drawing.Point(85, 38);
            this.tbHeight.Name = "tbHeight";
            this.tbHeight.Size = new System.Drawing.Size(100, 20);
            this.tbHeight.TabIndex = 2;
            // 
            // tbX
            // 
            this.tbX.Location = new System.Drawing.Point(105, 90);
            this.tbX.Name = "tbX";
            this.tbX.Size = new System.Drawing.Size(30, 20);
            this.tbX.TabIndex = 4;
            this.tbX.Text = "0";
            // 
            // tbY
            // 
            this.tbY.Location = new System.Drawing.Point(164, 90);
            this.tbY.Name = "tbY";
            this.tbY.Size = new System.Drawing.Size(30, 20);
            this.tbY.TabIndex = 5;
            this.tbY.Text = "0";
            // 
            // tbZ
            // 
            this.tbZ.Location = new System.Drawing.Point(223, 90);
            this.tbZ.Name = "tbZ";
            this.tbZ.Size = new System.Drawing.Size(30, 20);
            this.tbZ.TabIndex = 6;
            this.tbZ.Text = "0";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(211, 120);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.On_btnAdd_Click);
            // 
            // lblX
            // 
            this.lblX.AutoSize = true;
            this.lblX.Location = new System.Drawing.Point(82, 93);
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(17, 13);
            this.lblX.TabIndex = 9;
            this.lblX.Text = "X:";
            // 
            // lblY
            // 
            this.lblY.AutoSize = true;
            this.lblY.Location = new System.Drawing.Point(141, 93);
            this.lblY.Name = "lblY";
            this.lblY.Size = new System.Drawing.Size(17, 13);
            this.lblY.TabIndex = 10;
            this.lblY.Text = "Y:";
            // 
            // lblZ
            // 
            this.lblZ.AutoSize = true;
            this.lblZ.Location = new System.Drawing.Point(200, 93);
            this.lblZ.Name = "lblZ";
            this.lblZ.Size = new System.Drawing.Size(17, 13);
            this.lblZ.TabIndex = 11;
            this.lblZ.Text = "Z:";
            // 
            // lblSidesNumber
            // 
            this.lblSidesNumber.AutoSize = true;
            this.lblSidesNumber.Location = new System.Drawing.Point(12, 67);
            this.lblSidesNumber.Name = "lblSidesNumber";
            this.lblSidesNumber.Size = new System.Drawing.Size(74, 13);
            this.lblSidesNumber.TabIndex = 12;
            this.lblSidesNumber.Text = "Sides number:";
            // 
            // tbSidesNumber
            // 
            this.tbSidesNumber.Location = new System.Drawing.Point(85, 64);
            this.tbSidesNumber.Name = "tbSidesNumber";
            this.tbSidesNumber.Size = new System.Drawing.Size(100, 20);
            this.tbSidesNumber.TabIndex = 3;
            // 
            // CreatePyramidForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 152);
            this.Controls.Add(this.tbSidesNumber);
            this.Controls.Add(this.lblSidesNumber);
            this.Controls.Add(this.lblZ);
            this.Controls.Add(this.lblY);
            this.Controls.Add(this.lblX);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.tbZ);
            this.Controls.Add(this.tbY);
            this.Controls.Add(this.tbX);
            this.Controls.Add(this.tbHeight);
            this.Controls.Add(this.tbRadius);
            this.Controls.Add(this.lblBasePoint);
            this.Controls.Add(this.lblHeight);
            this.Controls.Add(this.lblRadius);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CreatePyramidForm";
            this.Text = "Create Pyramid";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRadius;
        private System.Windows.Forms.Label lblHeight;
        private System.Windows.Forms.Label lblBasePoint;
        private System.Windows.Forms.TextBox tbRadius;
        private System.Windows.Forms.TextBox tbHeight;
        private System.Windows.Forms.TextBox tbX;
        private System.Windows.Forms.TextBox tbY;
        private System.Windows.Forms.TextBox tbZ;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lblX;
        private System.Windows.Forms.Label lblY;
        private System.Windows.Forms.Label lblZ;
        private System.Windows.Forms.Label lblSidesNumber;
        private System.Windows.Forms.TextBox tbSidesNumber;
    }
}