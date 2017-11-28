namespace WarehouseManage.UI.WinForm.Forms
{
    partial class CustomerEditForm
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
            this.txtCustomerName = new WarehouseManage.UI.WinForm.Controls.TextboxWithLabel();
            this.txtCustomerCode = new WarehouseManage.UI.WinForm.Controls.TextboxWithLabel();
            this.cmbAreaName = new WarehouseManage.UI.WinForm.Controls.ComboBoxWithLabel();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.pnlContainer.SuspendLayout();
            this.groupBoxContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContainer
            // 
            this.pnlContainer.Controls.Add(this.cmbAreaName);
            this.pnlContainer.Controls.Add(this.chkIsDisable);
            this.pnlContainer.Controls.Add(this.txtDescription);
            this.pnlContainer.Controls.Add(this.txtCustomerName);
            this.pnlContainer.Controls.Add(this.txtCustomerCode);
            // 
            // chkIsDisable
            // 
            this.chkIsDisable.AutoSize = true;
            this.chkIsDisable.Location = new System.Drawing.Point(146, 241);
            this.chkIsDisable.Name = "chkIsDisable";
            this.chkIsDisable.Size = new System.Drawing.Size(69, 17);
            this.chkIsDisable.TabIndex = 4;
            this.chkIsDisable.Text = "IsDisable";
            this.chkIsDisable.UseVisualStyleBackColor = true;
            // 
            // txtDescription
            // 
            this.txtDescription.LabelText = "Description";
            this.txtDescription.Location = new System.Drawing.Point(146, 194);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(256, 20);
            this.txtDescription.TabIndex = 3;
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.LabelText = "CustomerName";
            this.txtCustomerName.Location = new System.Drawing.Point(146, 147);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(200, 20);
            this.txtCustomerName.TabIndex = 2;
            // 
            // txtCustomerCode
            // 
            this.txtCustomerCode.LabelText = "CustomerCode";
            this.txtCustomerCode.Location = new System.Drawing.Point(146, 100);
            this.txtCustomerCode.Name = "txtCustomerCode";
            this.txtCustomerCode.Size = new System.Drawing.Size(100, 20);
            this.txtCustomerCode.TabIndex = 1;
            // 
            // cmbAreaName
            // 
            this.cmbAreaName.FormattingEnabled = true;
            this.cmbAreaName.LabelText = "AreaName";
            this.cmbAreaName.Location = new System.Drawing.Point(146, 52);
            this.cmbAreaName.Name = "cmbAreaName";
            this.cmbAreaName.Size = new System.Drawing.Size(100, 21);
            this.cmbAreaName.TabIndex = 0;
            // 
            // CustomerEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(632, 453);
            this.Name = "CustomerEditForm";
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
        private Controls.TextboxWithLabel txtCustomerName;
        private Controls.TextboxWithLabel txtCustomerCode;
        private Controls.ComboBoxWithLabel cmbAreaName;
    }
}
