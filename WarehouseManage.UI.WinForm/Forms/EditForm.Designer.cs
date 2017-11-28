namespace WarehouseManage.UI.WinForm.Forms
{
    partial class EditForm
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
            this.controlBar = new System.Windows.Forms.ToolStrip();
            this.btnCreate = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnUndo = new System.Windows.Forms.ToolStripButton();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSetting = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExport = new System.Windows.Forms.ToolStripButton();
            this.groupBoxContent = new System.Windows.Forms.GroupBox();
            this.pnlContainer = new System.Windows.Forms.Panel();
            this.pnlTitle = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.statusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.controlBar.SuspendLayout();
            this.groupBoxContent.SuspendLayout();
            this.pnlTitle.SuspendLayout();
            this.statusBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // controlBar
            // 
            this.controlBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCreate,
            this.btnDelete,
            this.toolStripSeparator1,
            this.btnSave,
            this.btnUndo,
            this.btnClose,
            this.toolStripSeparator3,
            this.btnSetting,
            this.toolStripSeparator2,
            this.btnExport});
            this.controlBar.Location = new System.Drawing.Point(0, 0);
            this.controlBar.Name = "controlBar";
            this.controlBar.Size = new System.Drawing.Size(632, 25);
            this.controlBar.TabIndex = 0;
            // 
            // btnCreate
            // 
            this.btnCreate.Image = global::WarehouseManage.UI.WinForm.Properties.Resources.add;
            this.btnCreate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(60, 22);
            this.btnCreate.Text = "Create";
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Image = global::WarehouseManage.UI.WinForm.Properties.Resources.delete;
            this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(58, 22);
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnSave
            // 
            this.btnSave.Image = global::WarehouseManage.UI.WinForm.Properties.Resources.disk;
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(51, 22);
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnUndo
            // 
            this.btnUndo.Image = global::WarehouseManage.UI.WinForm.Properties.Resources.arrow_undo;
            this.btnUndo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(52, 22);
            this.btnUndo.Text = "Undo";
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // btnClose
            // 
            this.btnClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnClose.Image = global::WarehouseManage.UI.WinForm.Properties.Resources.door_out;
            this.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(53, 22);
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // btnSetting
            // 
            this.btnSetting.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnSetting.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSetting.Image = global::WarehouseManage.UI.WinForm.Properties.Resources.cog;
            this.btnSetting.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Size = new System.Drawing.Size(23, 22);
            this.btnSetting.Text = "Setting";
            this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnExport
            // 
            this.btnExport.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnExport.Image = global::WarehouseManage.UI.WinForm.Properties.Resources.table_go;
            this.btnExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(59, 22);
            this.btnExport.Text = "Export";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // groupBoxContent
            // 
            this.groupBoxContent.Controls.Add(this.pnlContainer);
            this.groupBoxContent.Controls.Add(this.pnlTitle);
            this.groupBoxContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxContent.Location = new System.Drawing.Point(0, 25);
            this.groupBoxContent.Name = "groupBoxContent";
            this.groupBoxContent.Size = new System.Drawing.Size(632, 406);
            this.groupBoxContent.TabIndex = 1;
            this.groupBoxContent.TabStop = false;
            // 
            // pnlContainer
            // 
            this.pnlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContainer.Location = new System.Drawing.Point(3, 49);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(626, 354);
            this.pnlContainer.TabIndex = 1;
            // 
            // pnlTitle
            // 
            this.pnlTitle.Controls.Add(this.lblTitle);
            this.pnlTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitle.Location = new System.Drawing.Point(3, 16);
            this.pnlTitle.Name = "pnlTitle";
            this.pnlTitle.Size = new System.Drawing.Size(626, 33);
            this.pnlTitle.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(4, 4);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(53, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Title";
            // 
            // statusBar
            // 
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel1});
            this.statusBar.Location = new System.Drawing.Point(0, 431);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(632, 22);
            this.statusBar.TabIndex = 2;
            // 
            // statusLabel1
            // 
            this.statusLabel1.Name = "statusLabel1";
            this.statusLabel1.Size = new System.Drawing.Size(0, 17);
            this.statusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // EditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 453);
            this.Controls.Add(this.groupBoxContent);
            this.Controls.Add(this.controlBar);
            this.Controls.Add(this.statusBar);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "EditForm";
            this.Text = "EditForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EditForm_FormClosing);
            this.Load += new System.EventHandler(this.EditForm_Load);
            this.Shown += new System.EventHandler(this.EditForm_Shown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.EditForm_KeyPress);
            this.controlBar.ResumeLayout(false);
            this.controlBar.PerformLayout();
            this.groupBoxContent.ResumeLayout(false);
            this.pnlTitle.ResumeLayout(false);
            this.pnlTitle.PerformLayout();
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip controlBar;
        private System.Windows.Forms.ToolStripButton btnCreate;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripButton btnUndo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnClose;
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.ToolStripButton btnSetting;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnExport;
        protected System.Windows.Forms.Panel pnlContainer;
        protected System.Windows.Forms.Panel pnlTitle;
        private System.Windows.Forms.Label lblTitle;
        protected System.Windows.Forms.GroupBox groupBoxContent;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel1;
    }
}