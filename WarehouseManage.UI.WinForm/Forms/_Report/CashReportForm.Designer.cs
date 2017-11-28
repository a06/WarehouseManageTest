namespace WarehouseManage.UI.WinForm.Forms
{
    partial class CashReportForm
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
            this.cmbItemsType = new WarehouseManage.UI.WinForm.Controls.ComboBoxWithLabel();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.groupBoxFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxFilter
            // 
            this.groupBoxFilter.Controls.Add(this.cmbItemsType);
            // 
            // groupBoxResult
            // 
            this.groupBoxResult.Text = "查询结果: 0 个记录";
            // 
            // cmbItemsType
            // 
            this.cmbItemsType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbItemsType.FormattingEnabled = true;
            this.cmbItemsType.Items.AddRange(new object[] {
            "Supplier",
            "Customer",
            "Employee"});
            this.cmbItemsType.LabelAlignment = System.Windows.Forms.TabAlignment.Left;
            this.cmbItemsType.LabelAutoSize = true;
            this.cmbItemsType.LabelBorderStyle = System.Windows.Forms.BorderStyle.None;
            this.cmbItemsType.LabelText = "ItemsType";
            this.cmbItemsType.Location = new System.Drawing.Point(80, 32);
            this.cmbItemsType.Name = "cmbItemsType";
            this.cmbItemsType.Size = new System.Drawing.Size(110, 21);
            this.cmbItemsType.TabIndex = 36;
            this.cmbItemsType.SelectedIndexChanged += new System.EventHandler(this.cmbItemsType_SelectedIndexChanged);
            // 
            // CashReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(792, 473);
            this.Name = "CashReportForm";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.groupBoxFilter.ResumeLayout(false);
            this.groupBoxFilter.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.ComboBoxWithLabel cmbItemsType;
    }
}
