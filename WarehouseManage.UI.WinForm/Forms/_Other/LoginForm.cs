using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using WarehouseManage.Common;
using WarehouseManage.BusinessLogic;
using WarehouseManage.UI.WinForm.Properties;

namespace WarehouseManage.UI.WinForm.Forms
{
    public partial class LoginForm : DialogForm
    {
        //--Constructor
        public LoginForm()
        {
            InitializeComponent();

            this.Text = Resources.WindowText_Login;
            txtUserCode.LabelText = Resources.LabelText_UserCode;
            txtPasswd.LabelText = Resources.LableText_UserPass;
        }

        public LoginForm(string usercode, string passwd)
            : this()
        {
            txtUserCode.Text = usercode;
            txtPasswd.Text = passwd;
        }

        //--Event
        private void pnlOkCancel1_btnOkClick(object sender, EventArgs e)
        {
            this.IsBusy = true;
            try
            {
                if (_checkValid())
                {
                    var rm = _login(txtUserCode.Text, txtPasswd.Text);

                    if (rm.Result == true)
                    {
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        Utility.ShowError(rm.Message, this);
                        txtUserCode.Focus();
                    }
                }
            }
            finally
            {
                this.IsBusy = false;
            }
        }

        private void pnlOkCancel1_btnCancelClick(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void frmLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(13))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");

                if (txtPasswd.ContainsFocus && _checkValid())
                    pnlOkCancel1_btnOkClick(sender, e);
            }
        }

        //--Helper
        private bool _checkValid()
        {
            txtUserCode.Text = txtUserCode.Text.Trim();
            if (string.IsNullOrEmpty(txtUserCode.Text))
            {
                txtUserCode.Focus();
                return false;
            }

            txtPasswd.Text = txtPasswd.Text.Trim();
            if (string.IsNullOrEmpty(txtPasswd.Text))
            {
                txtPasswd.Focus();
                return false;
            }

            return true;
        }

        private ResultMessage _login(string usercode, string passwd)
        {
            var bl = new UserBL();
            return bl.Login(usercode, passwd);
        }
    }
}
