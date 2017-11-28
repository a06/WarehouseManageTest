namespace WarehouseManage.UI.WinForm.Forms
{
    partial class UserEditForm
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
            this.txtUserCode = new WarehouseManage.UI.WinForm.Controls.TextboxWithLabel();
            this.txtUserName = new WarehouseManage.UI.WinForm.Controls.TextboxWithLabel();
            this.txtPasswd = new WarehouseManage.UI.WinForm.Controls.TextboxWithLabel();
            this.txtDescription = new WarehouseManage.UI.WinForm.Controls.TextboxWithLabel();
            this.chkIsDisable = new System.Windows.Forms.CheckBox();
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
            this.pnlContainer.Controls.Add(this.txtPasswd);
            this.pnlContainer.Controls.Add(this.txtUserName);
            this.pnlContainer.Controls.Add(this.txtUserCode);
            // 
            // txtUserCode
            // 
            this.txtUserCode.LabelText = "UserCode";
            this.txtUserCode.Location = new System.Drawing.Point(131, 40);
            this.txtUserCode.Name = "txtUserCode";
            this.txtUserCode.Size = new System.Drawing.Size(100, 21);
            this.txtUserCode.TabIndex = 0;
            // 
            // txtUserName
            // 
            this.txtUserName.LabelText = "UserName";
            this.txtUserName.Location = new System.Drawing.Point(131, 80);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(100, 21);
            this.txtUserName.TabIndex = 2;
            // 
            // txtPasswd
            // 
            this.txtPasswd.LabelText = "Passwd";
            this.txtPasswd.Location = new System.Drawing.Point(129, 117);
            this.txtPasswd.Name = "txtPasswd";
            this.txtPasswd.Size = new System.Drawing.Size(100, 21);
            this.txtPasswd.TabIndex = 4;
            // 
            // txtDescription
            // 
            this.txtDescription.LabelText = "Description";
            this.txtDescription.Location = new System.Drawing.Point(129, 155);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(100, 21);
            this.txtDescription.TabIndex = 6;
            // 
            // chkIsDisable
            // 
            this.chkIsDisable.AutoSize = true;
            this.chkIsDisable.Location = new System.Drawing.Point(129, 192);
            this.chkIsDisable.Name = "chkIsDisable";
            this.chkIsDisable.Size = new System.Drawing.Size(72, 16);
            this.chkIsDisable.TabIndex = 8;
            this.chkIsDisable.Text = "IsDisable";
            this.chkIsDisable.UseVisualStyleBackColor = true;
            // 
            // UserEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(632, 418);
            this.Name = "UserEditForm";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.pnlContainer.ResumeLayout(false);
            this.pnlContainer.PerformLayout();
            this.groupBoxContent.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.TextboxWithLabel txtUserCode;
        private Controls.TextboxWithLabel txtDescription;
        private Controls.TextboxWithLabel txtPasswd;
        private Controls.TextboxWithLabel txtUserName;
        private System.Windows.Forms.CheckBox chkIsDisable;
    }
}
