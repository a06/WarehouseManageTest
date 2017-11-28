namespace WarehouseManage.UI.WinForm.Forms
{
    partial class PurchaseBrowseForm
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
            this.dtpBillDate1 = new WarehouseManage.UI.WinForm.Controls.DateTimePickerWithLabel();
            this.dtpBillDate2 = new WarehouseManage.UI.WinForm.Controls.DateTimePickerWithLabel();
            this.txtSupplierName = new WarehouseManage.UI.WinForm.Controls.TextboxWithLabel();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.groupBoxFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxFilter
            // 
            this.groupBoxFilter.Controls.Add(this.txtSupplierName);
            this.groupBoxFilter.Controls.Add(this.dtpBillDate2);
            this.groupBoxFilter.Controls.Add(this.dtpBillDate1);
            // 
            // groupBoxResult
            // 
            this.groupBoxResult.Size = new System.Drawing.Size(792, 344);
            this.groupBoxResult.Text = "查询结果: 0 个记录";
            // 
            // dtpBillDate1
            // 
            this.dtpBillDate1.LabelAlignment = System.Windows.Forms.TabAlignment.Left;
            this.dtpBillDate1.LabelAutoSize = true;
            this.dtpBillDate1.LabelBorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtpBillDate1.LabelText = "日期";
            this.dtpBillDate1.Location = new System.Drawing.Point(64, 32);
            this.dtpBillDate1.Name = "dtpBillDate1";
            this.dtpBillDate1.Size = new System.Drawing.Size(110, 20);
            this.dtpBillDate1.TabIndex = 0;
            this.dtpBillDate1.Value = new System.DateTime(2000, 12, 31, 23, 59, 0, 0);
            // 
            // dtpBillDate2
            // 
            this.dtpBillDate2.LabelAlignment = System.Windows.Forms.TabAlignment.Left;
            this.dtpBillDate2.LabelAutoSize = true;
            this.dtpBillDate2.LabelBorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtpBillDate2.LabelText = "至";
            this.dtpBillDate2.Location = new System.Drawing.Point(200, 32);
            this.dtpBillDate2.Name = "dtpBillDate2";
            this.dtpBillDate2.Size = new System.Drawing.Size(111, 20);
            this.dtpBillDate2.TabIndex = 1;
            this.dtpBillDate2.Value = new System.DateTime(2000, 12, 31, 23, 59, 59, 0);
            // 
            // txtSupplierName
            // 
            this.txtSupplierName.LabelAlignment = System.Windows.Forms.TabAlignment.Left;
            this.txtSupplierName.LabelAutoSize = true;
            this.txtSupplierName.LabelBorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSupplierName.LabelText = "供应商名称";
            this.txtSupplierName.Location = new System.Drawing.Point(400, 32);
            this.txtSupplierName.Name = "txtSupplierName";
            this.txtSupplierName.Size = new System.Drawing.Size(200, 20);
            this.txtSupplierName.TabIndex = 2;
            // 
            // PurchaseBrowseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(792, 512);
            this.MinimumSize = new System.Drawing.Size(800, 464);
            this.Name = "PurchaseBrowseForm";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.groupBoxFilter.ResumeLayout(false);
            this.groupBoxFilter.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.DateTimePickerWithLabel dtpBillDate1;
        private Controls.DateTimePickerWithLabel dtpBillDate2;
        private Controls.TextboxWithLabel txtSupplierName;
    }
}
