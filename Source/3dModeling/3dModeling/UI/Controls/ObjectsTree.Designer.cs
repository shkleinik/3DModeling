namespace Modeling.UI.Controls
{
    partial class ObjectsTree
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.trObjects = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // trObjects
            // 
            this.trObjects.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.trObjects.Location = new System.Drawing.Point(4, 4);
            this.trObjects.Name = "trObjects";
            this.trObjects.Size = new System.Drawing.Size(444, 376);
            this.trObjects.TabIndex = 0;
            // 
            // ObjectsTree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.trObjects);
            this.Name = "ObjectsTree";
            this.Size = new System.Drawing.Size(451, 383);
            this.ResumeLayout(false);

            //
            // ObjectsTree Events
            //
            this.Load += new System.EventHandler(this.On_ObjectsTree_Load);
        }

        #endregion

        private System.Windows.Forms.TreeView trObjects;
    }
}
