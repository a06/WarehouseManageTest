namespace WarehouseManage.UI.WinForm.Forms
{
    partial class SupplierBrowseForm
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
            this.txtSupplier = new WarehouseManage.UI.WinForm.Controls.TextboxWithLabel();
            this.cmbIsDisable = new WarehouseManage.UI.WinForm.Controls.ComboBoxWithLabel();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.groupBoxFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxFilter
            // 
            this.groupBoxFilter.Controls.Add(this.cmbIsDisable);
            this.groupBoxFilter.Controls.Add(this.txtSupplier);
            // 
            // groupBoxResult
            // 
            this.groupBoxResult.Size = new System.Drawing.Size(792, 344);
            this.groupBoxResult.Text = "查询结果: 0 个记录";
            // 
            // txtSupplier
            // 
            this.txtSupplier.LabelAlignment = System.Windows.Forms.TabAlignment.Left;
            this.txtSupplier.LabelAutoSize = true;
            this.txtSupplier.LabelBorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSupplier.LabelText = "Supplier";
            this.txtSupplier.Location = new System.Drawing.Point(80, 32);
            this.txtSupplier.Name = "txtSupplier";
            this.txtSupplier.Size = new System.Drawing.Size(200, 20);
            this.txtSupplier.TabIndex = 4;
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
            this.cmbIsDisable.TabIndex = 8;
            // 
            // SupplierBrowseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(792, 512);
            this.MinimumSize = new System.Drawing.Size(800, 464);
            this.Name = "SupplierBrowseForm";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.groupBoxFilter.ResumeLayout(false);
            this.groupBoxFilter.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.TextboxWithLabel txtSupplier;
        private Controls.ComboBoxWithLabel cmbIsDisable;
    }
}
