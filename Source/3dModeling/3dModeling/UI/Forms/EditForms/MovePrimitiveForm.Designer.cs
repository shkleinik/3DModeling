namespace Modeling.UI.Forms.EditForms
{
    partial class MovePrimitiveForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MovePrimitiveForm));
            this.btnMove = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tbdX = new System.Windows.Forms.TextBox();
            this.tbdZ = new System.Windows.Forms.TextBox();
            this.tbdY = new System.Windows.Forms.TextBox();
            this.lblX = new System.Windows.Forms.Label();
            this.lblY = new System.Windows.Forms.Label();
            this.lblZ = new System.Windows.Forms.Label();
            this.lblTip = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnMove
            // 
            this.btnMove.Location = new System.Drawing.Point(149, 81);
            this.btnMove.Name = "btnMove";
            this.btnMove.Size = new System.Drawing.Size(75, 23);
            this.btnMove.TabIndex = 4;
            this.btnMove.Text = "Move";
            this.btnMove.UseVisualStyleBackColor = true;
            this.btnMove.Click += new System.EventHandler(this.On_btnMove_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(230, 81);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.On_btnCancel_Click);
            // 
            // tbdX
            // 
            this.tbdX.Location = new System.Drawing.Point(48, 38);
            this.tbdX.Name = "tbdX";
            this.tbdX.Size = new System.Drawing.Size(37, 20);
            this.tbdX.TabIndex = 1;
            this.tbdX.Text = "0";
            // 
            // tbdZ
            // 
            this.tbdZ.Location = new System.Drawing.Point(198, 38);
            this.tbdZ.Name = "tbdZ";
            this.tbdZ.Size = new System.Drawing.Size(37, 20);
            this.tbdZ.TabIndex = 3;
            this.tbdZ.Text = "0";
            // 
            // tbdY
            // 
            this.tbdY.Location = new System.Drawing.Point(123, 38);
            this.tbdY.Name = "tbdY";
            this.tbdY.Size = new System.Drawing.Size(37, 20);
            this.tbdY.TabIndex = 2;
            this.tbdY.Text = "0";
            // 
            // lblX
            // 
            this.lblX.AutoSize = true;
            this.lblX.Location = new System.Drawing.Point(16, 41);
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(26, 13);
            this.lblX.TabIndex = 5;
            this.lblX.Text = "dX :";
            // 
            // lblY
            // 
            this.lblY.AutoSize = true;
            this.lblY.Location = new System.Drawing.Point(91, 41);
            this.lblY.Name = "lblY";
            this.lblY.Size = new System.Drawing.Size(26, 13);
            this.lblY.TabIndex = 6;
            this.lblY.Text = "dY :";
            // 
            // lblZ
            // 
            this.lblZ.AutoSize = true;
            this.lblZ.Location = new System.Drawing.Point(166, 41);
            this.lblZ.Name = "lblZ";
            this.lblZ.Size = new System.Drawing.Size(26, 13);
            this.lblZ.TabIndex = 7;
            this.lblZ.Text = "dZ :";
            // 
            // lblTip
            // 
            this.lblTip.AutoSize = true;
            this.lblTip.Location = new System.Drawing.Point(13, 13);
            this.lblTip.Name = "lblTip";
            this.lblTip.Size = new System.Drawing.Size(266, 13);
            this.lblTip.TabIndex = 9;
            this.lblTip.Text = "Enter X, Y, Z displacements to move selected primitive:";
            // 
            // MovePrimitiveForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 114);
            this.Controls.Add(this.lblTip);
            this.Controls.Add(this.lblZ);
            this.Controls.Add(this.lblY);
            this.Controls.Add(this.lblX);
            this.Controls.Add(this.tbdY);
            this.Controls.Add(this.tbdZ);
            this.Controls.Add(this.tbdX);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnMove);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MovePrimitiveForm";
            this.Text = "Move Primitive";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnMove;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox tbdX;
        private System.Windows.Forms.TextBox tbdZ;
        private System.Windows.Forms.TextBox tbdY;
        private System.Windows.Forms.Label lblX;
        private System.Windows.Forms.Label lblY;
        private System.Windows.Forms.Label lblZ;
        private System.Windows.Forms.Label lblTip;
    }
}