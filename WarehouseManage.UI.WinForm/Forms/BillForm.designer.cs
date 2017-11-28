namespace WarehouseManage.UI.WinForm.Forms
{
    partial class BillForm
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
            this.components = new System.ComponentModel.Container();
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
            this.dataGridView2 = new WarehouseManage.UI.WinForm.Controls.DataGridViewWithButton();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miCreateItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.miEditItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.miDeleteItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlTitle = new System.Windows.Forms.Panel();
            this.txtBillCode = new WarehouseManage.UI.WinForm.Controls.TextboxWithLabel();
            this.dtpBillDate = new WarehouseManage.UI.WinForm.Controls.DateTimePickerWithLabel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.statusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.controlBar.SuspendLayout();
            this.groupBoxContent.SuspendLayout();
            this.pnlContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
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
            this.controlBar.Size = new System.Drawing.Size(792, 25);
            this.controlBar.TabIndex = 0;
            // 
            // btnCreate
            // 
            this.btnCreate.Image = global::WarehouseManage.UI.WinForm.Properties.Resources.add;
            this.btnCreate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(61, 22);
            this.btnCreate.Text = "Create";
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Image = global::WarehouseManage.UI.WinForm.Properties.Resources.delete;
            this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(61, 22);
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
            this.btnSave.Size = new System.Drawing.Size(49, 22);
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnUndo
            // 
            this.btnUndo.Image = global::WarehouseManage.UI.WinForm.Properties.Resources.arrow_undo;
            this.btnUndo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(49, 22);
            this.btnUndo.Text = "Undo";
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // btnClose
            // 
            this.btnClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnClose.Image = global::WarehouseManage.UI.WinForm.Properties.Resources.door_out;
            this.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(55, 22);
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
            this.btnExport.Size = new System.Drawing.Size(61, 22);
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
            this.groupBoxContent.Size = new System.Drawing.Size(792, 445);
            this.groupBoxContent.TabIndex = 1;
            this.groupBoxContent.TabStop = false;
            // 
            // pnlContainer
            // 
            this.pnlContainer.Controls.Add(this.dataGridView2);
            this.pnlContainer.Controls.Add(this.panel2);
            this.pnlContainer.Controls.Add(this.panel1);
            this.pnlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContainer.Location = new System.Drawing.Point(3, 47);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(786, 395);
            this.pnlContainer.TabIndex = 1;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(0, 59);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.ShowButtonColumns = null;
            this.dataGridView2.Size = new System.Drawing.Size(786, 306);
            this.dataGridView2.TabIndex = 2;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miCreateItem,
            this.toolStripMenuItem1,
            this.miEditItem,
            this.toolStripMenuItem2,
            this.miDeleteItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(118, 82);
            // 
            // miCreateItem
            // 
            this.miCreateItem.Name = "miCreateItem";
            this.miCreateItem.Size = new System.Drawing.Size(117, 22);
            this.miCreateItem.Text = "miCreate";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(114, 6);
            // 
            // miEditItem
            // 
            this.miEditItem.Name = "miEditItem";
            this.miEditItem.Size = new System.Drawing.Size(117, 22);
            this.miEditItem.Text = "miEdit";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(114, 6);
            // 
            // miDeleteItem
            // 
            this.miDeleteItem.Name = "miDeleteItem";
            this.miDeleteItem.Size = new System.Drawing.Size(117, 22);
            this.miDeleteItem.Text = "miDelete";
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 365);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(786, 30);
            this.panel2.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(786, 59);
            this.panel1.TabIndex = 0;
            // 
            // pnlTitle
            // 
            this.pnlTitle.Controls.Add(this.txtBillCode);
            this.pnlTitle.Controls.Add(this.dtpBillDate);
            this.pnlTitle.Controls.Add(this.lblTitle);
            this.pnlTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitle.Location = new System.Drawing.Point(3, 17);
            this.pnlTitle.Name = "pnlTitle";
            this.pnlTitle.Size = new System.Drawing.Size(786, 30);
            this.pnlTitle.TabIndex = 0;
            // 
            // txtBillCode
            // 
            this.txtBillCode.LabelAlignment = System.Windows.Forms.TabAlignment.Left;
            this.txtBillCode.LabelAutoSize = true;
            this.txtBillCode.LabelBorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBillCode.LabelText = "BillCode";
            this.txtBillCode.Location = new System.Drawing.Point(677, 4);
            this.txtBillCode.Name = "txtBillCode";
            this.txtBillCode.Size = new System.Drawing.Size(100, 21);
            this.txtBillCode.TabIndex = 10;
            this.txtBillCode.TabStop = false;
            // 
            // dtpBillDate
            // 
            this.dtpBillDate.LabelAlignment = System.Windows.Forms.TabAlignment.Left;
            this.dtpBillDate.LabelAutoSize = true;
            this.dtpBillDate.LabelBorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtpBillDate.LabelText = "BillDate";
            this.dtpBillDate.Location = new System.Drawing.Point(520, 4);
            this.dtpBillDate.Name = "dtpBillDate";
            this.dtpBillDate.Size = new System.Drawing.Size(109, 21);
            this.dtpBillDate.TabIndex = 9;
            this.dtpBillDate.TabStop = false;
            this.dtpBillDate.Value = new System.DateTime(2000, 12, 31, 23, 59, 0, 0);
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
            this.statusBar.Location = new System.Drawing.Point(0, 470);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(792, 22);
            this.statusBar.TabIndex = 2;
            // 
            // statusLabel1
            // 
            this.statusLabel1.AutoSize = false;
            this.statusLabel1.Name = "statusLabel1";
            this.statusLabel1.Size = new System.Drawing.Size(100, 17);
            this.statusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BillForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 492);
            this.Controls.Add(this.groupBoxContent);
            this.Controls.Add(this.controlBar);
            this.Controls.Add(this.statusBar);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "BillForm";
            this.Text = "BillForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BillForm_FormClosing);
            this.Load += new System.EventHandler(this.BillForm_Load);
            this.Shown += new System.EventHandler(this.BillForm_Shown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.BillForm_KeyPress);
            this.controlBar.ResumeLayout(false);
            this.controlBar.PerformLayout();
            this.groupBoxContent.ResumeLayout(false);
            this.pnlContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.pnlTitle.ResumeLayout(false);
            this.pnlTitle.PerformLayout();
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip controlBar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        protected System.Windows.Forms.Panel pnlContainer;
        protected System.Windows.Forms.Panel pnlTitle;
        private System.Windows.Forms.Label lblTitle;
        protected System.Windows.Forms.GroupBox groupBoxContent;
        protected System.Windows.Forms.Panel panel1;
        protected WarehouseManage.UI.WinForm.Controls.DataGridViewWithButton dataGridView2;
        protected System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem miCreateItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem miEditItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem miDeleteItem;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel1;
        private System.Windows.Forms.ToolStripButton btnCreate;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripButton btnUndo;
        private System.Windows.Forms.ToolStripButton btnClose;
        private System.Windows.Forms.ToolStripButton btnSetting;
        private System.Windows.Forms.ToolStripButton btnExport;
        protected Controls.TextboxWithLabel txtBillCode;
        protected Controls.DateTimePickerWithLabel dtpBillDate;
    }
}