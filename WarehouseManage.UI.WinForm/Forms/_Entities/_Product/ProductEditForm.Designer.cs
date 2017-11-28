namespace WarehouseManage.UI.WinForm.Forms
{
    partial class ProductEditForm
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
            this.txtProductName = new WarehouseManage.UI.WinForm.Controls.TextboxWithLabel();
            this.txtProductCode = new WarehouseManage.UI.WinForm.Controls.TextboxWithLabel();
            this.txtUnit = new WarehouseManage.UI.WinForm.Controls.TextboxWithLabel();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.pnlContainer.SuspendLayout();
            this.groupBoxContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContainer
            // 
            this.pnlContainer.Controls.Add(this.txtUnit);
            this.pnlContainer.Controls.Add(this.chkIsDisable);
            this.pnlContainer.Controls.Add(this.txtDescription);
            this.pnlContainer.Controls.Add(this.txtProductName);
            this.pnlContainer.Controls.Add(this.txtProductCode);
            // 
            // chkIsDisable
            // 
            this.chkIsDisable.AutoSize = true;
            this.chkIsDisable.Location = new System.Drawing.Point(157, 280);
            this.chkIsDisable.Name = "chkIsDisable";
            this.chkIsDisable.Size = new System.Drawing.Size(69, 17);
            this.chkIsDisable.TabIndex = 4;
            this.chkIsDisable.Text = "IsDisable";
            this.chkIsDisable.UseVisualStyleBackColor = true;
            // 
            // txtDescription
            // 
            this.txtDescription.LabelAlignment = System.Windows.Forms.TabAlignment.Left;
            this.txtDescription.LabelAutoSize = true;
            this.txtDescription.LabelBorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDescription.LabelText = "Description";
            this.txtDescription.Location = new System.Drawing.Point(157, 220);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(256, 20);
            this.txtDescription.TabIndex = 3;
            // 
            // txtProductName
            // 
            this.txtProductName.LabelAlignment = System.Windows.Forms.TabAlignment.Left;
            this.txtProductName.LabelAutoSize = true;
            this.txtProductName.LabelBorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtProductName.LabelText = "ProductName";
            this.txtProductName.Location = new System.Drawing.Point(159, 100);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(200, 20);
            this.txtProductName.TabIndex = 1;
            // 
            // txtProductCode
            // 
            this.txtProductCode.LabelAlignment = System.Windows.Forms.TabAlignment.Left;
            this.txtProductCode.LabelAutoSize = true;
            this.txtProductCode.LabelBorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtProductCode.LabelText = "ProductCode";
            this.txtProductCode.Location = new System.Drawing.Point(159, 40);
            this.txtProductCode.Name = "txtProductCode";
            this.txtProductCode.Size = new System.Drawing.Size(100, 20);
            this.txtProductCode.TabIndex = 0;
            // 
            // txtUnit
            // 
            this.txtUnit.LabelAlignment = System.Windows.Forms.TabAlignment.Left;
            this.txtUnit.LabelAutoSize = true;
            this.txtUnit.LabelBorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUnit.LabelText = "Unit";
            this.txtUnit.Location = new System.Drawing.Point(159, 160);
            this.txtUnit.Name = "txtUnit";
            this.txtUnit.Size = new System.Drawing.Size(100, 20);
            this.txtUnit.TabIndex = 2;
            // 
            // ProductEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(632, 453);
            this.Name = "ProductEditForm";
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
        private Controls.TextboxWithLabel txtProductName;
        private Controls.TextboxWithLabel txtProductCode;
        private Controls.TextboxWithLabel txtUnit;
    }
}
