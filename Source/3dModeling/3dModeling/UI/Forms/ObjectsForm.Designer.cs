//using System.Drawing;
//using System.Windows.Forms;

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
            this.miAddPyramid = new System.Windows.Forms.ToolStripMenuItem();
            this.miAddCone = new System.Windows.Forms.ToolStripMenuItem();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                                                                                  this.miAddPyramid,
                                                                                  this.miAddCone});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(450, 25);
            this.menu.TabIndex = 0;
            this.menu.Text = "Actions with shapes menu";
            // 
            // miAddPyramid
            // 
            this.miAddPyramid.Name = "miAddPyramid";
            this.miAddPyramid.Size = new System.Drawing.Size(90, 20);
            this.miAddPyramid.Text = "Add pyramid";
            this.miAddPyramid.Click += new System.EventHandler(this.On_miAddPyramid_Click);
            // 
            // miAddCone
            // 
            this.miAddCone.Name = "miAddCone";
            this.miAddCone.Size = new System.Drawing.Size(70, 20);
            this.miAddCone.Text = "Add cone";
            this.miAddCone.Click += new System.EventHandler(this.On_miAddCone_Click);
            // 
            // ObjectsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 346);
            this.Controls.Add(this.menu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menu;
            this.Name = "ObjectsForm";
            this.Text = "Constructor tree";
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem miAddPyramid;
        private System.Windows.Forms.ToolStripMenuItem miAddCone;
        
    }
}