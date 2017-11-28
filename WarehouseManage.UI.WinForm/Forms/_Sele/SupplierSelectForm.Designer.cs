namespace WarehouseManage.UI.WinForm.Forms
{
    partial class SupplierSelectForm
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
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.groupBoxFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxFilter
            // 
            this.groupBoxFilter.Controls.Add(this.txtSupplierName);
            // 
            // txtSupplierName
            // 
            this.txtSupplierName.LabelAlignment = System.Windows.Forms.TabAlignment.Left;
            this.txtSupplierName.LabelAutoSize = true;
            this.txtSupplierName.LabelBorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSupplierName.LabelText = "SupplierName";
            this.txtSupplierName.Location = new System.Drawing.Point(80, 32);
            this.txtSupplierName.Name = "txtSupplierName";
            this.txtSupplierName.Size = new System.Drawing.Size(200, 20);
            this.txtSupplierName.TabIndex = 6;
            // 
            // SupplierSelectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(632, 453);
            this.Name = "SupplierSelectForm";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.groupBoxFilter.ResumeLayout(false);
            this.groupBoxFilter.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.TextboxWithLabel txtSupplierName;
    }
}
