namespace Modeling.UI.Forms
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.miObjectsToRender = new System.Windows.Forms.ToolStripMenuItem();
            this.miProjections = new System.Windows.Forms.ToolStripMenuItem();
            this.miXY = new System.Windows.Forms.ToolStripMenuItem();
            this.miYZ = new System.Windows.Forms.ToolStripMenuItem();
            this.miXZ = new System.Windows.Forms.ToolStripMenuItem();
            this.miSave = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miObjectsToRender,
            this.miProjections,
            this.miSave});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(818, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "mainMenu";
            // 
            // miObjectsToRender
            // 
            this.miObjectsToRender.Name = "miObjectsToRender";
            this.miObjectsToRender.Size = new System.Drawing.Size(110, 20);
            this.miObjectsToRender.Text = "Objects to render";
            this.miObjectsToRender.Click += new System.EventHandler(this.On_miObjectsToRender_Click);
            // 
            // miProjections
            // 
            this.miProjections.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miXY,
            this.miYZ,
            this.miXZ});
            this.miProjections.Name = "miProjections";
            this.miProjections.Size = new System.Drawing.Size(78, 20);
            this.miProjections.Text = "Projections";
            // 
            // miXY
            // 
            this.miXY.Name = "miXY";
            this.miXY.Size = new System.Drawing.Size(88, 22);
            this.miXY.Text = "XY";
            this.miXY.Click += new System.EventHandler(this.On_miXY_Click);
            // 
            // miYZ
            // 
            this.miYZ.Name = "miYZ";
            this.miYZ.Size = new System.Drawing.Size(88, 22);
            this.miYZ.Text = "YZ";
            this.miYZ.Click += new System.EventHandler(this.On_miYZ_Click);
            // 
            // miXZ
            // 
            this.miXZ.Name = "miXZ";
            this.miXZ.Size = new System.Drawing.Size(88, 22);
            this.miXZ.Text = "XZ";
            this.miXZ.Click += new System.EventHandler(this.On_miXZ_Click);
            // 
            // miSave
            // 
            this.miSave.Name = "miSave";
            this.miSave.Size = new System.Drawing.Size(71, 20);
            this.miSave.Text = "Save state";
            this.miSave.Click += new System.EventHandler(this.On_miSave_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(818, 540);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Walash SoftWare";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.On_MainForm_Load);
            this.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.On_MainForm_MouseWheel);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.On_MainForm_MouseUp);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.On_MainForm_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.On_MainForm_MouseClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.On_MainForm_MouseDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.On_MainForm_KeyUp);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.On_MainForm_Closing);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.On_MainForm_MouseMove);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.On_MainForm_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem miObjectsToRender;
        private System.Windows.Forms.ToolStripMenuItem miProjections;
        private System.Windows.Forms.ToolStripMenuItem miXY;
        private System.Windows.Forms.ToolStripMenuItem miYZ;
        private System.Windows.Forms.ToolStripMenuItem miXZ;
        private System.Windows.Forms.ToolStripMenuItem miSave;
    }
}