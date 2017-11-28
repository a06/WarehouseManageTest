namespace WarehouseManage.UI.WinForm.Forms
{
    partial class BillSeleForm
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
            this.toolStripFormCtrl = new System.Windows.Forms.ToolStrip();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSelect = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnReset = new System.Windows.Forms.ToolStripButton();
            this.btnSearch = new System.Windows.Forms.ToolStripButton();
            this.groupBoxFilter = new System.Windows.Forms.GroupBox();
            this.groupBoxResult = new System.Windows.Forms.GroupBox();
            this.groupBoxItems = new System.Windows.Forms.GroupBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.toolStripFormCtrl.SuspendLayout();
            this.groupBoxResult.SuspendLayout();
            this.groupBoxItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStripFormCtrl
            // 
            this.toolStripFormCtrl.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnClose,
            this.toolStripSeparator1,
            this.toolStripSeparator3,
            this.btnSelect,
            this.toolStripSeparator2,
            this.btnReset,
            this.btnSearch});
            this.toolStripFormCtrl.Location = new System.Drawing.Point(0, 0);
            this.toolStripFormCtrl.Name = "toolStripFormCtrl";
            this.toolStripFormCtrl.Size = new System.Drawing.Size(632, 25);
            this.toolStripFormCtrl.TabIndex = 17;
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
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // btnSelect
            // 
            this.btnSelect.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnSelect.Image = global::WarehouseManage.UI.WinForm.Properties.Resources.tick;
            this.btnSelect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(56, 22);
            this.btnSelect.Text = "Select";
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
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
            this.groupBoxFilter.Size = new System.Drawing.Size(632, 80);
            this.groupBoxFilter.TabIndex = 18;
            this.groupBoxFilter.TabStop = false;
            this.groupBoxFilter.Text = "Filter";
            // 
            // groupBoxResult
            // 
            this.groupBoxResult.Controls.Add(this.groupBoxItems);
            this.groupBoxResult.Controls.Add(this.dataGridView1);
            this.groupBoxResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxResult.Location = new System.Drawing.Point(0, 105);
            this.groupBoxResult.Name = "groupBoxResult";
            this.groupBoxResult.Size = new System.Drawing.Size(632, 348);
            this.groupBoxResult.TabIndex = 19;
            this.groupBoxResult.TabStop = false;
            this.groupBoxResult.Text = "Result";
            // 
            // groupBoxItems
            // 
            this.groupBoxItems.Controls.Add(this.dataGridView2);
            this.groupBoxItems.Controls.Add(this.toolStrip1);
            this.groupBoxItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxItems.Location = new System.Drawing.Point(3, 129);
            this.groupBoxItems.Name = "groupBoxItems";
            this.groupBoxItems.Size = new System.Drawing.Size(626, 216);
            this.groupBoxItems.TabIndex = 20;
            this.groupBoxItems.TabStop = false;
            this.groupBoxItems.Text = "Items";
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(3, 41);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(620, 172);
            this.dataGridView2.TabIndex = 1;
            this.dataGridView2.DoubleClick += new System.EventHandler(this.dataGridView2_DoubleClick);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Location = new System.Drawing.Point(3, 16);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(620, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
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
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridView1.Location = new System.Drawing.Point(3, 16);
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
            this.dataGridView1.Size = new System.Drawing.Size(626, 113);
            this.dataGridView1.TabIndex = 19;
            this.dataGridView1.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_RowEnter);
            // 
            // BillSeleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(632, 453);
            this.Controls.Add(this.groupBoxResult);
            this.Controls.Add(this.groupBoxFilter);
            this.Controls.Add(this.toolStripFormCtrl);
            this.MinimumSize = new System.Drawing.Size(480, 344);
            this.Name = "BillSeleForm";
            this.Load += new System.EventHandler(this.SeleBillForm_Load);
            this.Shown += new System.EventHandler(this.SeleBillForm_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SeleBillForm_KeyDown);
            this.toolStripFormCtrl.ResumeLayout(false);
            this.toolStripFormCtrl.PerformLayout();
            this.groupBoxResult.ResumeLayout(false);
            this.groupBoxItems.ResumeLayout(false);
            this.groupBoxItems.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStripFormCtrl;
        private System.Windows.Forms.ToolStripButton btnClose;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnSelect;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnReset;
        private System.Windows.Forms.ToolStripButton btnSearch;
        protected System.Windows.Forms.GroupBox groupBoxFilter;
        private System.Windows.Forms.GroupBox groupBoxResult;
        private System.Windows.Forms.GroupBox groupBoxItems;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        protected System.Windows.Forms.DataGridView dataGridView1;
    }
}
