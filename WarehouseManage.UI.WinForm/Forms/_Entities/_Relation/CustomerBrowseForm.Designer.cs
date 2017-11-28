namespace WarehouseManage.UI.WinForm.Forms
{
    partial class CustomerBrowseForm
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
            this.txtCustomerName = new WarehouseManage.UI.WinForm.Controls.TextboxWithLabel();
            this.cmbIsDisable = new WarehouseManage.UI.WinForm.Controls.ComboBoxWithLabel();
            this.cmbAreaName = new WarehouseManage.UI.WinForm.Controls.ComboBoxWithLabel();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.groupBoxFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxFilter
            // 
            this.groupBoxFilter.Controls.Add(this.cmbAreaName);
            this.groupBoxFilter.Controls.Add(this.cmbIsDisable);
            this.groupBoxFilter.Controls.Add(this.txtCustomerName);
            // 
            // groupBoxResult
            // 
            this.groupBoxResult.Text = "查询结果: 0 个记录";
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.LabelAlignment = System.Windows.Forms.TabAlignment.Left;
            this.txtCustomerName.LabelAutoSize = true;
            this.txtCustomerName.LabelBorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCustomerName.LabelText = "CustomerName";
            this.txtCustomerName.Location = new System.Drawing.Point(264, 32);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(200, 20);
            this.txtCustomerName.TabIndex = 1;
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
            this.cmbIsDisable.Location = new System.Drawing.Point(542, 32);
            this.cmbIsDisable.Name = "cmbIsDisable";
            this.cmbIsDisable.Size = new System.Drawing.Size(77, 21);
            this.cmbIsDisable.TabIndex = 2;
            // 
            // cmbAreaName
            // 
            this.cmbAreaName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAreaName.FormattingEnabled = true;
            this.cmbAreaName.LabelAlignment = System.Windows.Forms.TabAlignment.Left;
            this.cmbAreaName.LabelAutoSize = true;
            this.cmbAreaName.LabelBorderStyle = System.Windows.Forms.BorderStyle.None;
            this.cmbAreaName.LabelText = "AreaName";
            this.cmbAreaName.Location = new System.Drawing.Point(80, 32);
            this.cmbAreaName.Name = "cmbAreaName";
            this.cmbAreaName.Size = new System.Drawing.Size(92, 21);
            this.cmbAreaName.TabIndex = 0;
            // 
            // CustomerBrowseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(792, 473);
            this.Name = "CustomerBrowseForm";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.groupBoxFilter.ResumeLayout(false);
            this.groupBoxFilter.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.TextboxWithLabel txtCustomerName;
        private Controls.ComboBoxWithLabel cmbIsDisable;
        private Controls.ComboBoxWithLabel cmbAreaName;
    }
}
