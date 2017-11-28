namespace WarehouseManage.UI.WinForm.Forms
{
    partial class SupplierEditForm
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
            this.chkIsDisable = new System.Windows.Forms.CheckBox();
            this.txtDescription = new WarehouseManage.UI.WinForm.Controls.TextboxWithLabel();
            this.txtSupplierName = new WarehouseManage.UI.WinForm.Controls.TextboxWithLabel();
            this.txtSupplierCode = new WarehouseManage.UI.WinForm.Controls.TextboxWithLabel();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.pnlContainer.SuspendLayout();
            this.groupBoxContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContainer
            // 
            this.pnlContainer.Controls.Add(this.chkIsDisable);
            this.pnlContainer.Controls.Add(this.txtDescription);
            this.pnlContainer.Controls.Add(this.txtSupplierName);
            this.pnlContainer.Controls.Add(this.txtSupplierCode);
            // 
            // chkIsDisable
            // 
            this.chkIsDisable.AutoSize = true;
            this.chkIsDisable.Location = new System.Drawing.Point(143, 188);
            this.chkIsDisable.Name = "chkIsDisable";
            this.chkIsDisable.Size = new System.Drawing.Size(69, 17);
            this.chkIsDisable.TabIndex = 24;
            this.chkIsDisable.Text = "IsDisable";
            this.chkIsDisable.UseVisualStyleBackColor = true;
            // 
            // txtDescription
            // 
            this.txtDescription.LabelText = "Description";
            this.txtDescription.Location = new System.Drawing.Point(143, 145);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(256, 20);
            this.txtDescription.TabIndex = 23;
            // 
            // txtSupplierName
            // 
            this.txtSupplierName.LabelText = "SupplierName";
            this.txtSupplierName.Location = new System.Drawing.Point(143, 98);
            this.txtSupplierName.Name = "txtSupplierName";
            this.txtSupplierName.Size = new System.Drawing.Size(200, 20);
            this.txtSupplierName.TabIndex = 22;
            // 
            // txtSupplierCode
            // 
            this.txtSupplierCode.LabelText = "SupplierCode";
            this.txtSupplierCode.Location = new System.Drawing.Point(143, 54);
            this.txtSupplierCode.Name = "txtSupplierCode";
            this.txtSupplierCode.Size = new System.Drawing.Size(100, 20);
            this.txtSupplierCode.TabIndex = 21;
            // 
            // SupplierEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(632, 453);
            this.Name = "SupplierEditForm";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.pnlContainer.ResumeLayout(false);
            this.pnlContainer.PerformLayout();
            this.groupBoxContent.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkIsDisable;
        private Controls.TextboxWithLabel txtDescription;
        private Controls.TextboxWithLabel txtSupplierName;
        private Controls.TextboxWithLabel txtSupplierCode;
    }
}
