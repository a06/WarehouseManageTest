namespace WarehouseManage.UI.WinForm.Forms
{
    partial class EmployeeEditForm
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
            this.txtEmployeeName = new WarehouseManage.UI.WinForm.Controls.TextboxWithLabel();
            this.txtEmployeeCode = new WarehouseManage.UI.WinForm.Controls.TextboxWithLabel();
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
            this.pnlContainer.Controls.Add(this.txtEmployeeName);
            this.pnlContainer.Controls.Add(this.txtEmployeeCode);
            // 
            // chkIsDisable
            // 
            this.chkIsDisable.AutoSize = true;
            this.chkIsDisable.Location = new System.Drawing.Point(151, 224);
            this.chkIsDisable.Name = "chkIsDisable";
            this.chkIsDisable.Size = new System.Drawing.Size(69, 17);
            this.chkIsDisable.TabIndex = 38;
            this.chkIsDisable.Text = "IsDisable";
            this.chkIsDisable.UseVisualStyleBackColor = true;
            // 
            // txtDescription
            // 
            this.txtDescription.LabelAlignment = System.Windows.Forms.TabAlignment.Left;
            this.txtDescription.LabelAutoSize = true;
            this.txtDescription.LabelBorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDescription.LabelText = "Description";
            this.txtDescription.Location = new System.Drawing.Point(151, 164);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(256, 20);
            this.txtDescription.TabIndex = 37;
            // 
            // txtEmployeeName
            // 
            this.txtEmployeeName.LabelAlignment = System.Windows.Forms.TabAlignment.Left;
            this.txtEmployeeName.LabelAutoSize = true;
            this.txtEmployeeName.LabelBorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEmployeeName.LabelText = "EmployeeName";
            this.txtEmployeeName.Location = new System.Drawing.Point(151, 104);
            this.txtEmployeeName.Name = "txtEmployeeName";
            this.txtEmployeeName.Size = new System.Drawing.Size(200, 20);
            this.txtEmployeeName.TabIndex = 36;
            // 
            // txtEmployeeCode
            // 
            this.txtEmployeeCode.LabelAlignment = System.Windows.Forms.TabAlignment.Left;
            this.txtEmployeeCode.LabelAutoSize = true;
            this.txtEmployeeCode.LabelBorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEmployeeCode.LabelText = "EmployeeCode";
            this.txtEmployeeCode.Location = new System.Drawing.Point(151, 44);
            this.txtEmployeeCode.Name = "txtEmployeeCode";
            this.txtEmployeeCode.Size = new System.Drawing.Size(100, 20);
            this.txtEmployeeCode.TabIndex = 35;
            // 
            // EmployeeEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(632, 453);
            this.Name = "EmployeeEditForm";
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
        private Controls.TextboxWithLabel txtEmployeeName;
        private Controls.TextboxWithLabel txtEmployeeCode;
    }
}
