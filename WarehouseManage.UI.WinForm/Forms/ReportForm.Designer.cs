namespace WarehouseManage.UI.WinForm.Forms
{
    partial class ReportForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportForm));
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripFormCtrl = new System.Windows.Forms.ToolStrip();
            this.lblTitleMessage = new System.Windows.Forms.ToolStripLabel();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSetting = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExport = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnReset = new System.Windows.Forms.ToolStripButton();
            this.btnSearch = new System.Windows.Forms.ToolStripButton();
            this.groupBoxFilter = new System.Windows.Forms.GroupBox();
            this.groupBoxResult = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripResultCtrl = new System.Windows.Forms.ToolStrip();
            this.btnViewItem = new System.Windows.Forms.ToolStripButton();
            this.toolStripFormCtrl.SuspendLayout();
            this.groupBoxResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.toolStripResultCtrl.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Location = new System.Drawing.Point(0, 451);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(792, 22);
            this.statusStrip.TabIndex = 15;
            // 
            // toolStripFormCtrl
            // 
            this.toolStripFormCtrl.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblTitleMessage,
            this.btnClose,
            this.toolStripSeparator4,
            this.btnSetting,
            this.toolStripSeparator3,
            this.btnExport,
            this.toolStripSeparator2,
            this.btnReset,
            this.btnSearch});
            this.toolStripFormCtrl.Location = new System.Drawing.Point(0, 0);
            this.toolStripFormCtrl.Name = "toolStripFormCtrl";
            this.toolStripFormCtrl.Size = new System.Drawing.Size(792, 25);
            this.toolStripFormCtrl.TabIndex = 18;
            // 
            // lblTitleMessage
            // 
            this.lblTitleMessage.AutoSize = false;
            this.lblTitleMessage.Name = "lblTitleMessage";
            this.lblTitleMessage.Size = new System.Drawing.Size(256, 22);
            this.lblTitleMessage.Text = "TitleMessage";
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
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
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
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
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
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnReset
            // 
            this.btnReset.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnReset.Image = global::WarehouseManage.UI.WinForm.Properties.Resources.control_repeat;
            this.btnReset.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(55, 22);
            this.btnReset.Text = "Reset";
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnSearch.Image = global::WarehouseManage.UI.WinForm.Properties.Resources.magnifier;
            this.btnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(60, 22);
            this.btnSearch.Text = "Search";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // groupBoxFilter
            // 
            this.groupBoxFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxFilter.Location = new System.Drawing.Point(0, 25);
            this.groupBoxFilter.Name = "groupBoxFilter";
            this.groupBoxFilter.Size = new System.Drawing.Size(792, 80);
            this.groupBoxFilter.TabIndex = 19;
            this.groupBoxFilter.TabStop = false;
            this.groupBoxFilter.Text = "Filter";
            // 
            // groupBoxResult
            // 
            this.groupBoxResult.Controls.Add(this.dataGridView1);
            this.groupBoxResult.Controls.Add(this.toolStrip1);
            this.groupBoxResult.Controls.Add(this.toolStripResultCtrl);
            this.groupBoxResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxResult.Location = new System.Drawing.Point(0, 105);
            this.groupBoxResult.Name = "groupBoxResult";
            this.groupBoxResult.Size = new System.Drawing.Size(792, 346);
            this.groupBoxResult.TabIndex = 22;
            this.groupBoxResult.TabStop = false;
            this.groupBoxResult.Text = "Result";
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 41);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(658, 302);
            this.dataGridView1.TabIndex = 24;
            this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Right;
            this.toolStrip1.Location = new System.Drawing.Point(661, 41);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(128, 302);
            this.toolStrip1.TabIndex = 23;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripResultCtrl
            // 
            this.toolStripResultCtrl.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnViewItem});
            this.toolStripResultCtrl.Location = new System.Drawing.Point(3, 16);
            this.toolStripResultCtrl.Name = "toolStripResultCtrl";
            this.toolStripResultCtrl.Size = new System.Drawing.Size(786, 25);
            this.toolStripResultCtrl.TabIndex = 22;
            // 
            // btnViewItem
            // 
            this.btnViewItem.Image = ((System.Drawing.Image)(resources.GetObject("btnViewItem.Image")));
            this.btnViewItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnViewItem.Name = "btnViewItem";
            this.btnViewItem.Size = new System.Drawing.Size(71, 22);
            this.btnViewItem.Text = "ViewItem";
            this.btnViewItem.Click += new System.EventHandler(this.btnViewItem_Click);
            // 
            // ReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(792, 473);
            this.Controls.Add(this.groupBoxResult);
            this.Controls.Add(this.groupBoxFilter);
            this.Controls.Add(this.toolStripFormCtrl);
            this.Controls.Add(this.statusStrip);
            this.Name = "ReportForm";
            this.Text = "ReportForm";
            this.Load += new System.EventHandler(this.ReportForm_Load);
            this.Shown += new System.EventHandler(this.ReportForm_Shown);
            this.toolStripFormCtrl.ResumeLayout(false);
            this.toolStripFormCtrl.PerformLayout();
            this.groupBoxResult.ResumeLayout(false);
            this.groupBoxResult.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.toolStripResultCtrl.ResumeLayout(false);
            this.toolStripResultCtrl.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStrip toolStripFormCtrl;
        private System.Windows.Forms.ToolStripLabel lblTitleMessage;
        private System.Windows.Forms.ToolStripButton btnClose;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton btnSetting;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnExport;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnReset;
        private System.Windows.Forms.ToolStripButton btnSearch;
        protected System.Windows.Forms.GroupBox groupBoxFilter;
        protected System.Windows.Forms.GroupBox groupBoxResult;
        protected System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStrip toolStripResultCtrl;
        private System.Windows.Forms.ToolStripButton btnViewItem;
    }
}
