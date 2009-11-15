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
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.miObjectsToRender = new System.Windows.Forms.ToolStripMenuItem();
            this.miProjections = new System.Windows.Forms.ToolStripMenuItem();
            this.miXY = new System.Windows.Forms.ToolStripMenuItem();
            this.miYZ = new System.Windows.Forms.ToolStripMenuItem();
            this.miXZ = new System.Windows.Forms.ToolStripMenuItem();
            this.miXYintel = new System.Windows.Forms.ToolStripMenuItem();
            this.miYZintel = new System.Windows.Forms.ToolStripMenuItem();
            this.miXZintel = new System.Windows.Forms.ToolStripMenuItem();
            this.miSave = new System.Windows.Forms.ToolStripMenuItem();
            this.miReload = new System.Windows.Forms.ToolStripMenuItem();
            this.cbUseDirectX = new System.Windows.Forms.CheckBox();
            this.mainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miObjectsToRender,
            this.miProjections,
            this.miSave,
            this.miReload});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(818, 24);
            this.mainMenu.TabIndex = 0;
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
            this.miXZ,
            this.miXYintel,
            this.miYZintel,
            this.miXZintel});
            this.miProjections.Name = "miProjections";
            this.miProjections.Size = new System.Drawing.Size(78, 20);
            this.miProjections.Text = "Projections";
            // 
            // miXY
            // 
            this.miXY.Name = "miXY";
            this.miXY.Size = new System.Drawing.Size(119, 22);
            this.miXY.Text = "XY";
            this.miXY.Click += new System.EventHandler(this.On_miXY_Click);
            // 
            // miYZ
            // 
            this.miYZ.Name = "miYZ";
            this.miYZ.Size = new System.Drawing.Size(119, 22);
            this.miYZ.Text = "YZ";
            this.miYZ.Click += new System.EventHandler(this.On_miYZ_Click);
            // 
            // miXZ
            // 
            this.miXZ.Name = "miXZ";
            this.miXZ.Size = new System.Drawing.Size(119, 22);
            this.miXZ.Text = "XZ";
            this.miXZ.Click += new System.EventHandler(this.On_miXZ_Click);
            // 
            // miXYintel
            // 
            this.miXYintel.Name = "miXYintel";
            this.miXYintel.Size = new System.Drawing.Size(119, 22);
            this.miXYintel.Text = "XY(intel)";
            this.miXYintel.Click += new System.EventHandler(this.On_miXYintel_Click);
            // 
            // miYZintel
            // 
            this.miYZintel.Name = "miYZintel";
            this.miYZintel.Size = new System.Drawing.Size(119, 22);
            this.miYZintel.Text = "YZ(intel)";
            this.miYZintel.Click += new System.EventHandler(this.On_miYZintel_Click);
            // 
            // miXZintel
            // 
            this.miXZintel.Name = "miXZintel";
            this.miXZintel.Size = new System.Drawing.Size(119, 22);
            this.miXZintel.Text = "XZ(intel)";
            this.miXZintel.Click += new System.EventHandler(this.On_miXZintel_Click);
            // 
            // miSave
            // 
            this.miSave.Name = "miSave";
            this.miSave.Size = new System.Drawing.Size(71, 20);
            this.miSave.Text = "Save state";
            this.miSave.Click += new System.EventHandler(this.On_miSave_Click);
            // 
            // miReload
            // 
            this.miReload.Name = "miReload";
            this.miReload.Size = new System.Drawing.Size(55, 20);
            this.miReload.Text = "Reload";
            this.miReload.Click += new System.EventHandler(this.On_miReload_Click);
            // 
            // cbUseDirectX
            // 
            this.cbUseDirectX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbUseDirectX.AutoSize = true;
            this.cbUseDirectX.Checked = true;
            this.cbUseDirectX.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbUseDirectX.Location = new System.Drawing.Point(723, 27);
            this.cbUseDirectX.Name = "cbUseDirectX";
            this.cbUseDirectX.Size = new System.Drawing.Size(83, 17);
            this.cbUseDirectX.TabIndex = 1;
            this.cbUseDirectX.Text = "Use DirectX";
            this.cbUseDirectX.UseVisualStyleBackColor = true;
            this.cbUseDirectX.CheckedChanged += new System.EventHandler(this.On_cbUseDirectX_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(818, 540);
            this.Controls.Add(this.cbUseDirectX);
            this.Controls.Add(this.mainMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mainMenu;
            this.MinimumSize = new System.Drawing.Size(640, 480);
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
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem miObjectsToRender;
        private System.Windows.Forms.ToolStripMenuItem miProjections;
        private System.Windows.Forms.ToolStripMenuItem miXY;
        private System.Windows.Forms.ToolStripMenuItem miYZ;
        private System.Windows.Forms.ToolStripMenuItem miXZ;
        private System.Windows.Forms.ToolStripMenuItem miSave;
        private System.Windows.Forms.CheckBox cbUseDirectX;
        private System.Windows.Forms.ToolStripMenuItem miReload;
        private System.Windows.Forms.ToolStripMenuItem miXYintel;
        private System.Windows.Forms.ToolStripMenuItem miYZintel;
        private System.Windows.Forms.ToolStripMenuItem miXZintel;
    }
}