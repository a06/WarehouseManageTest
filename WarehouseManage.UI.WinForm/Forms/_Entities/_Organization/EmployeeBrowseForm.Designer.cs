namespace WarehouseManage.UI.WinForm.Forms
{
    partial class EmployeeBrowseForm
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
            this.cmbIsDisable = new WarehouseManage.UI.WinForm.Controls.ComboBoxWithLabel();
            this.txtEmployeeName = new WarehouseManage.UI.WinForm.Controls.TextboxWithLabel();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.groupBoxFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxFilter
            // 
            this.groupBoxFilter.Controls.Add(this.cmbIsDisable);
            this.groupBoxFilter.Controls.Add(this.txtEmployeeName);
            // 
            // groupBoxResult
            // 
            this.groupBoxResult.Size = new System.Drawing.Size(792, 385);
            this.groupBoxResult.Text = "查询结果: 0 个记录";
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
            this.cmbIsDisable.TabIndex = 15;
            // 
            // txtEmployeeName
            // 
            this.txtEmployeeName.LabelAlignment = System.Windows.Forms.TabAlignment.Left;
            this.txtEmployeeName.LabelAutoSize = true;
            this.txtEmployeeName.LabelBorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEmployeeName.LabelText = "EmployeeName";
            this.txtEmployeeName.Location = new System.Drawing.Point(80, 32);
            this.txtEmployeeName.Name = "txtEmployeeName";
            this.txtEmployeeName.Size = new System.Drawing.Size(200, 20);
            this.txtEmployeeName.TabIndex = 14;
            // 
            // EmployeeBrowseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(792, 512);
            this.MinimumSize = new System.Drawing.Size(800, 464);
            this.Name = "EmployeeBrowseForm";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.groupBoxFilter.ResumeLayout(false);
            this.groupBoxFilter.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.ComboBoxWithLabel cmbIsDisable;
        private Controls.TextboxWithLabel txtEmployeeName;
    }
}
