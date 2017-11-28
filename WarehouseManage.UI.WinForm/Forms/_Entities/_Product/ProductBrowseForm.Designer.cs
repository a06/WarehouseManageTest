namespace WarehouseManage.UI.WinForm.Forms
{
    partial class ProductBrowseForm
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
            this.txtProductName = new WarehouseManage.UI.WinForm.Controls.TextboxWithLabel();
            this.cmbIsDisable = new WarehouseManage.UI.WinForm.Controls.ComboBoxWithLabel();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.groupBoxFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxFilter
            // 
            this.groupBoxFilter.Controls.Add(this.cmbIsDisable);
            this.groupBoxFilter.Controls.Add(this.txtProductName);
            // 
            // groupBoxResult
            // 
            this.groupBoxResult.Size = new System.Drawing.Size(792, 385);
            this.groupBoxResult.Text = "查询结果: 0 个记录";
            // 
            // txtProductName
            // 
            this.txtProductName.LabelAlignment = System.Windows.Forms.TabAlignment.Left;
            this.txtProductName.LabelAutoSize = true;
            this.txtProductName.LabelBorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtProductName.LabelText = "ProductName";
            this.txtProductName.Location = new System.Drawing.Point(80, 32);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(200, 20);
            this.txtProductName.TabIndex = 4;
            // 
            // cmbIsDisable
            // 
            this.cmbIsDisable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIsDisable.FormattingEnabled = true;
            this.cmbIsDisable.Items.AddRange(new object[] {
            "All",
            "Enable",
            "Disable"});
            this.cmbIsDisable.LabelAlignment = System.Windows.Forms.TabAlignment.Left;
            this.cmbIsDisable.LabelAutoSize = true;
            this.cmbIsDisable.LabelBorderStyle = System.Windows.Forms.BorderStyle.None;
            this.cmbIsDisable.LabelText = "IsDisable";
            this.cmbIsDisable.Location = new System.Drawing.Point(360, 32);
            this.cmbIsDisable.Name = "cmbIsDisable";
            this.cmbIsDisable.Size = new System.Drawing.Size(77, 21);
            this.cmbIsDisable.TabIndex = 6;
            // 
            // ProductBrowseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(792, 512);
            this.MinimumSize = new System.Drawing.Size(800, 539);
            this.Name = "ProductBrowseForm";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.groupBoxFilter.ResumeLayout(false);
            this.groupBoxFilter.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.TextboxWithLabel txtProductName;
        private Controls.ComboBoxWithLabel cmbIsDisable;
    }
}
