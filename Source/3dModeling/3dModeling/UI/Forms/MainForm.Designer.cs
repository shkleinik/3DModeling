﻿namespace Modeling.UI.Forms
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
            this.miAksonometricProjection = new System.Windows.Forms.ToolStripMenuItem();
            this.miBevelProjection = new System.Windows.Forms.ToolStripMenuItem();
            this.perspectiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miChangeLightSourceLocation = new System.Windows.Forms.ToolStripMenuItem();
            this.miSave = new System.Windows.Forms.ToolStripMenuItem();
            this.miReload = new System.Windows.Forms.ToolStripMenuItem();
            this.cbUseDirectX = new System.Windows.Forms.CheckBox();
            this.cbHideEdges = new System.Windows.Forms.CheckBox();
            this.cbFill = new System.Windows.Forms.CheckBox();
            this.cbDrawEdges = new System.Windows.Forms.CheckBox();
            this.mainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miObjectsToRender,
            this.miProjections,
            this.miChangeLightSourceLocation,
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
            this.miAksonometricProjection,
            this.miBevelProjection,
            this.perspectiveToolStripMenuItem});
            this.miProjections.Name = "miProjections";
            this.miProjections.Size = new System.Drawing.Size(78, 20);
            this.miProjections.Text = "Projections";
            // 
            // miXY
            // 
            this.miXY.Name = "miXY";
            this.miXY.Size = new System.Drawing.Size(148, 22);
            this.miXY.Text = "XY";
            this.miXY.Click += new System.EventHandler(this.On_miXY_Click);
            // 
            // miYZ
            // 
            this.miYZ.Name = "miYZ";
            this.miYZ.Size = new System.Drawing.Size(148, 22);
            this.miYZ.Text = "YZ";
            this.miYZ.Click += new System.EventHandler(this.On_miYZ_Click);
            // 
            // miXZ
            // 
            this.miXZ.Name = "miXZ";
            this.miXZ.Size = new System.Drawing.Size(148, 22);
            this.miXZ.Text = "XZ";
            this.miXZ.Click += new System.EventHandler(this.On_miXZ_Click);
            // 
            // miAksonometricProjection
            // 
            this.miAksonometricProjection.Name = "miAksonometricProjection";
            this.miAksonometricProjection.Size = new System.Drawing.Size(148, 22);
            this.miAksonometricProjection.Text = "Aksonometric";
            this.miAksonometricProjection.Click += new System.EventHandler(this.On_miAksonometricProjection_Click);
            // 
            // miBevelProjection
            // 
            this.miBevelProjection.Name = "miBevelProjection";
            this.miBevelProjection.Size = new System.Drawing.Size(148, 22);
            this.miBevelProjection.Text = "Bevel";
            this.miBevelProjection.Click += new System.EventHandler(this.On_miBevelProjection_Click);
            // 
            // perspectiveToolStripMenuItem
            // 
            this.perspectiveToolStripMenuItem.Name = "perspectiveToolStripMenuItem";
            this.perspectiveToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.perspectiveToolStripMenuItem.Text = "Perspective";
            this.perspectiveToolStripMenuItem.Click += new System.EventHandler(this.On_miPerspectiveProjection_Click);
            // 
            // miChangeLightSourceLocation
            // 
            this.miChangeLightSourceLocation.Name = "miChangeLightSourceLocation";
            this.miChangeLightSourceLocation.Size = new System.Drawing.Size(171, 20);
            this.miChangeLightSourceLocation.Text = "Change light source location";
            this.miChangeLightSourceLocation.Click += new System.EventHandler(this.On_miChangeLightSourceLocation_Click);
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
            // cbHideEdges
            // 
            this.cbHideEdges.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbHideEdges.AutoSize = true;
            this.cbHideEdges.Checked = true;
            this.cbHideEdges.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbHideEdges.Location = new System.Drawing.Point(723, 51);
            this.cbHideEdges.Name = "cbHideEdges";
            this.cbHideEdges.Size = new System.Drawing.Size(80, 17);
            this.cbHideEdges.TabIndex = 2;
            this.cbHideEdges.Text = "Hide edges";
            this.cbHideEdges.UseVisualStyleBackColor = true;
            this.cbHideEdges.CheckedChanged += new System.EventHandler(this.On_cbHideEdges_CheckedChanged);
            // 
            // cbFill
            // 
            this.cbFill.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbFill.AutoSize = true;
            this.cbFill.Checked = true;
            this.cbFill.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbFill.Location = new System.Drawing.Point(723, 75);
            this.cbFill.Name = "cbFill";
            this.cbFill.Size = new System.Drawing.Size(83, 17);
            this.cbFill.TabIndex = 4;
            this.cbFill.Text = "Fill polygons";
            this.cbFill.UseVisualStyleBackColor = true;
            this.cbFill.CheckedChanged += new System.EventHandler(this.On_cbFill_CheckedChanged);
            // 
            // cbDrawEdges
            // 
            this.cbDrawEdges.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbDrawEdges.AutoSize = true;
            this.cbDrawEdges.Checked = true;
            this.cbDrawEdges.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbDrawEdges.Location = new System.Drawing.Point(723, 99);
            this.cbDrawEdges.Name = "cbDrawEdges";
            this.cbDrawEdges.Size = new System.Drawing.Size(83, 17);
            this.cbDrawEdges.TabIndex = 5;
            this.cbDrawEdges.Text = "Draw edges";
            this.cbDrawEdges.UseVisualStyleBackColor = true;
            this.cbDrawEdges.CheckedChanged += new System.EventHandler(this.On_cbDrawEdges_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(818, 540);
            this.Controls.Add(this.cbDrawEdges);
            this.Controls.Add(this.cbFill);
            this.Controls.Add(this.cbHideEdges);
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
        private System.Windows.Forms.CheckBox cbHideEdges;
        private System.Windows.Forms.ToolStripMenuItem perspectiveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem miAksonometricProjection;
        private System.Windows.Forms.ToolStripMenuItem miBevelProjection;
        private System.Windows.Forms.ToolStripMenuItem miChangeLightSourceLocation;
        private System.Windows.Forms.CheckBox cbFill;
        private System.Windows.Forms.CheckBox cbDrawEdges;
    }
}