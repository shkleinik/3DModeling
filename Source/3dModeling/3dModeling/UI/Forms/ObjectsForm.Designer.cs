namespace Modeling.UI.Forms
{
    partial class ObjectsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ObjectsForm));
            this.menu = new System.Windows.Forms.MenuStrip();
            this.miAddPrimitives = new System.Windows.Forms.ToolStripMenuItem();
            this.miAddPyramid = new System.Windows.Forms.ToolStripMenuItem();
            this.miAddCone = new System.Windows.Forms.ToolStripMenuItem();
            this.miEditPrimitives = new System.Windows.Forms.ToolStripMenuItem();
            this.miRotate = new System.Windows.Forms.ToolStripMenuItem();
            this.miScale = new System.Windows.Forms.ToolStripMenuItem();
            this.miMove = new System.Windows.Forms.ToolStripMenuItem();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miAddPrimitives,
            this.miEditPrimitives});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(500, 24);
            this.menu.TabIndex = 0;
            this.menu.Text = "Actions with shapes menu";
            // 
            // miAddPrimitives
            // 
            this.miAddPrimitives.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miAddPyramid,
            this.miAddCone});
            this.miAddPrimitives.Name = "miAddPrimitives";
            this.miAddPrimitives.Size = new System.Drawing.Size(96, 20);
            this.miAddPrimitives.Text = "Add primitives";
            // 
            // miAddPyramid
            // 
            this.miAddPyramid.Name = "miAddPyramid";
            this.miAddPyramid.Size = new System.Drawing.Size(118, 22);
            this.miAddPyramid.Text = "Pyramid";
            this.miAddPyramid.Click += new System.EventHandler(this.On_miAddPyramid_Click);
            // 
            // miAddCone
            // 
            this.miAddCone.Name = "miAddCone";
            this.miAddCone.Size = new System.Drawing.Size(118, 22);
            this.miAddCone.Text = "Cone";
            this.miAddCone.Click += new System.EventHandler(this.On_miAddCone_Click);
            // 
            // miEditPrimitives
            // 
            this.miEditPrimitives.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miRotate,
            this.miScale,
            this.miMove});
            this.miEditPrimitives.Name = "miEditPrimitives";
            this.miEditPrimitives.Size = new System.Drawing.Size(94, 20);
            this.miEditPrimitives.Text = "Edit primitives";
            // 
            // miRotate
            // 
            this.miRotate.Name = "miRotate";
            this.miRotate.Size = new System.Drawing.Size(108, 22);
            this.miRotate.Text = "Rotate";
            this.miRotate.Click += new System.EventHandler(this.On_miRotate_Click);
            // 
            // miScale
            // 
            this.miScale.Name = "miScale";
            this.miScale.Size = new System.Drawing.Size(108, 22);
            this.miScale.Text = "Scale";
            this.miScale.Click += new System.EventHandler(this.On_miScale_Click);
            // 
            // miMove
            // 
            this.miMove.Name = "miMove";
            this.miMove.Size = new System.Drawing.Size(108, 22);
            this.miMove.Text = "Move";
            this.miMove.Click += new System.EventHandler(this.On_miMove_Click);
            // 
            // ObjectsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.menu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menu;
            // Incorrect layout using this properties.
            this.MinimumSize = new System.Drawing.Size(500, 350);
            this.ClientSize = new System.Drawing.Size(500, 350);
            this.Name = "ObjectsForm";
            this.Text = "Constructor tree";
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem miAddPrimitives;
        private System.Windows.Forms.ToolStripMenuItem miEditPrimitives;
        private System.Windows.Forms.ToolStripMenuItem miAddPyramid;
        private System.Windows.Forms.ToolStripMenuItem miAddCone;
        private System.Windows.Forms.ToolStripMenuItem miRotate;
        private System.Windows.Forms.ToolStripMenuItem miScale;
        private System.Windows.Forms.ToolStripMenuItem miMove;
        
    }
}