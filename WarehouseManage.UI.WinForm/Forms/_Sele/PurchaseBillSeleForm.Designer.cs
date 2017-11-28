namespace WarehouseManage.UI.WinForm.Forms
{
    partial class PurchaseBillSeleForm
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
            this.txtSupplierName = new WarehouseManage.UI.WinForm.Controls.TextboxWithLabel();
            this.dtpBillDate2 = new WarehouseManage.UI.WinForm.Controls.DateTimePickerWithLabel();
            this.dtpBillDate1 = new WarehouseManage.UI.WinForm.Controls.DateTimePickerWithLabel();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).BeginInit();
            this.groupBoxFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxFilter
            // 
            this.groupBoxFilter.Controls.Add(this.txtSupplierName);
            this.groupBoxFilter.Controls.Add(this.dtpBillDate2);
            this.groupBoxFilter.Controls.Add(this.dtpBillDate1);
            this.groupBoxFilter.Size = new System.Drawing.Size(712, 80);
            // 
            // txtSupplierName
            // 
            this.txtSupplierName.LabelAlignment = System.Windows.Forms.TabAlignment.Left;
            this.txtSupplierName.LabelAutoSize = true;
            this.txtSupplierName.LabelBorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSupplierName.LabelText = "供应商名称";
            this.txtSupplierName.Location = new System.Drawing.Point(384, 30);
            this.txtSupplierName.Name = "txtSupplierName";
            this.txtSupplierName.Size = new System.Drawing.Size(200, 20);
            this.txtSupplierName.TabIndex = 5;
            // 
            // dtpBillDate2
            // 
            this.dtpBillDate2.LabelAlignment = System.Windows.Forms.TabAlignment.Left;
            this.dtpBillDate2.LabelAutoSize = true;
            this.dtpBillDate2.LabelBorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtpBillDate2.LabelText = "至";
            this.dtpBillDate2.Location = new System.Drawing.Point(184, 30);
            this.dtpBillDate2.Name = "dtpBillDate2";
            this.dtpBillDate2.Size = new System.Drawing.Size(111, 20);
            this.dtpBillDate2.TabIndex = 4;
            this.dtpBillDate2.Value = new System.DateTime(2000, 12, 31, 23, 59, 59, 0);
            // 
            // dtpBillDate1
            // 
            this.dtpBillDate1.LabelAlignment = System.Windows.Forms.TabAlignment.Left;
            this.dtpBillDate1.LabelAutoSize = true;
            this.dtpBillDate1.LabelBorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtpBillDate1.LabelText = "日期";
            this.dtpBillDate1.Location = new System.Drawing.Point(48, 30);
            this.dtpBillDate1.Name = "dtpBillDate1";
            this.dtpBillDate1.Size = new System.Drawing.Size(110, 20);
            this.dtpBillDate1.TabIndex = 3;
            this.dtpBillDate1.Value = new System.DateTime(2000, 12, 31, 23, 59, 0, 0);
            // 
            // PurchaseBillSeleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(712, 503);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "PurchaseBillSeleForm";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).EndInit();
            this.groupBoxFilter.ResumeLayout(false);
            this.groupBoxFilter.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.TextboxWithLabel txtSupplierName;
        private Controls.DateTimePickerWithLabel dtpBillDate2;
        private Controls.DateTimePickerWithLabel dtpBillDate1;
    }
}
