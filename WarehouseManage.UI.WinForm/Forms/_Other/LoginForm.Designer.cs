namespace WarehouseManage.UI.WinForm.Forms
{
    partial class LoginForm
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlOkCancel = new WarehouseManage.UI.WinForm.Controls.PanelOkCancel();
            this.txtUserCode = new WarehouseManage.UI.WinForm.Controls.TextboxWithLabel();
            this.txtPasswd = new WarehouseManage.UI.WinForm.Controls.TextboxWithLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(314, 60);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // pnlOkCancel
            // 
            this.pnlOkCancel.Location = new System.Drawing.Point(78, 156);
            this.pnlOkCancel.Name = "pnlOkCancel";
            this.pnlOkCancel.Size = new System.Drawing.Size(159, 27);
            this.pnlOkCancel.TabIndex = 2;
            this.pnlOkCancel.btnOkClick += new System.EventHandler(this.pnlOkCancel1_btnOkClick);
            this.pnlOkCancel.btnCancelClick += new System.EventHandler(this.pnlOkCancel1_btnCancelClick);
            // 
            // txtUserCode
            // 
            this.txtUserCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtUserCode.LabelAlignment = System.Windows.Forms.TabAlignment.Left;
            this.txtUserCode.LabelText = "UserCode";
            this.txtUserCode.Location = new System.Drawing.Point(113, 79);
            this.txtUserCode.Name = "txtUserCode";
            this.txtUserCode.Size = new System.Drawing.Size(116, 20);
            this.txtUserCode.TabIndex = 0;
            // 
            // txtPasswd
            // 
            this.txtPasswd.LabelAlignment = System.Windows.Forms.TabAlignment.Left;
            this.txtPasswd.LabelText = "Passwd";
            this.txtPasswd.Location = new System.Drawing.Point(113, 108);
            this.txtPasswd.Name = "txtPasswd";
            this.txtPasswd.PasswordChar = '*';
            this.txtPasswd.Size = new System.Drawing.Size(116, 20);
            this.txtPasswd.TabIndex = 1;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 195);
            this.Controls.Add(this.txtPasswd);
            this.Controls.Add(this.txtUserCode);
            this.Controls.Add(this.pnlOkCancel);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "LoginForm";
            this.Text = "LoginForm";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmLogin_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private WarehouseManage.UI.WinForm.Controls.PanelOkCancel pnlOkCancel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Controls.TextboxWithLabel txtUserCode;
        private Controls.TextboxWithLabel txtPasswd;
    }
}