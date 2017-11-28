using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WarehouseManage.UI.WinForm.Forms
{
    public partial class AppSettingForm : WarehouseManage.UI.WinForm.Forms.SettingForm
    {
        //--Constructor
        public AppSettingForm()
        {
            InitializeComponent();
        }

        protected override void InitLoad()
        {
            //this.TitleText = "程序设置";
            //ltbCode.LabelText = "编号";
            //ltbFullName.LabelText = "名称";

            //this.ListState = ListState.CanAddItem & ListState.CanEditItem;

            //ltbCode.TextBoxTextChanged += this.OnConditionChanged;
            //ltbFullName.TextBoxTextChanged += this.OnConditionChanged;
        }
    }
}
