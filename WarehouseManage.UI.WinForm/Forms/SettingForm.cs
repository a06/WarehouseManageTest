using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WarehouseManage.UI.WinForm.Forms
{
    public partial class SettingForm : DialogForm
    {
        protected virtual void InitLoad() { }
        protected virtual void InitShown() { }

        //--Constructor
        public SettingForm()
        {
            InitializeComponent();
        }

        private void SettingForm_Load(object sender, EventArgs e)
        {
            InitLoad();
        }

        private void SettingForm_Shown(object sender, EventArgs e)
        {
            InitShown();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            //
        }

        private void btnDefault_Click(object sender, EventArgs e)
        {
            //
        }
    }
}
