using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

using WarehouseManage.UI.WinForm.Properties;
using WarehouseManage.UI.WinForm.Forms;

namespace WarehouseManage.UI.WinForm
{
    public partial class MainForm : Form
    {
        // Property
        protected bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                if (_isBusy) this.Cursor = Cursors.WaitCursor;
                this.Enabled = !_isBusy;
                if (!_isBusy) this.Cursor = Cursors.Default;
            }
        }
        private bool _isBusy;

        // Constructor
        public MainForm()
        {
            InitializeComponent();

            this.Text = Resources.ProgramName;

            miSideBar.Visible = false;

            miStore.Text = " 库存 ";
            miPurchaseBill.Text = "进货单";
            miPurchaseReturnBill.Text = "退货单";
            miSaleBill.Text = "销售单";
            miSaleReturnBill.Text = "返还单";
            miStoreBalance.Text = "库存结算";

            miCash.Text = " 现金 ";
            miCashOut.Text = "付款单";
            miCashIn.Text = "收款单";
            miSalary.Text = "工资单";
            miCashBalance.Text = "现金结算";

            miBase.Text = " 基础信息 ";
            miProduct.Text = "商品";
            miSupplier.Text = "供应商";
            miCustomer.Text = "客户";
            miEmployee.Text = "员工";

            miReport.Text = " 报表 ";
            miStoreReport.Text = "即时库存";
            miCashReport.Text = "即时现金";

            miSystem.Text = " 系统 ";
            miAppSetting.Text = "程序设置";
            miUserBrowse.Text = "用户管理";
            miChangePasswd.Text = "更改密码";

            miWindow.Text = " 窗口 ";
            miMiniAll.Text = "全部缩小";
            miCloseAll.Text = "全部关闭";

            miExit.Text = " 退出 ";
            miReLogin.Text = "重新登录";
            miCloseApp.Text = "关闭程序";
        }

        // event
        private void frmMain_Load(object sender, EventArgs e)
        {
            //
        }

        private void frmMain_Shown(object sender, EventArgs e)
        {
            miReLogin.PerformClick();
        }

        private void miReLogin_Click(object sender, EventArgs e)
        {
            _showLoginForm();
        }

        private void miClose_Click(object sender, EventArgs e)
        {
            _closeAllForm();
            this.Close();
        }

        private void miMiniAll_Click(object sender, EventArgs e)
        {
            _miniAllForm();
        }

        private void miCloseAll_Click(object sender, EventArgs e)
        {
            _closeAllForm();
        }

        private void miAppSetting_Click(object sender, EventArgs e)
        {
            ///var result = _showDialogForm(typeof(AppSettingForm), sender, e);
            ///if (result == DialogResult.OK)
            {
            }
        }

        private void miListUser_Click(object sender, EventArgs e)
        {
            _showMdiChildForm(typeof(UserBrowseForm), sender, e, true);
        }

        private void miChangePasswd_Click(object sender, EventArgs e)
        {
            //show ChangePasswd page
            ///var result = _showDialogForm(typeof(UserSettingForm), sender, e);
            ///if (result == DialogResult.OK)
            {
            }
        }

        //--
        private void miPurchaseBill_Click(object sender, EventArgs e)
        {
            _showMdiChildForm(typeof(PurchaseBrowseForm), sender, e, true);
        }

        private void miPurchaseReturnBill_Click(object sender, EventArgs e)
        {
            //_showMdiChildForm(typeof(PurchaseReturnBrowseForm), sender, e, true);
        }

        private void miSaleBill_Click(object sender, EventArgs e)
        {
            //_showMdiChildForm(typeof(SaleBrowseForm), sender, e, true);
        }

        private void miSaleReturnBill_Click(object sender, EventArgs e)
        {
            //_showMdiChildForm(typeof(SaleReturnBrowseForm), sender, e, true);
        }

        private void miStoreBalance_Click(object sender, EventArgs e)
        {
            ///_showMdiChildForm(typeof(StoreBalanceBrowseForm), sender, e, true);
        }

        private void miProduct_Click(object sender, EventArgs e)
        {
            _showMdiChildForm(typeof(ProductBrowseForm), sender, e, true);
        }

        private void miSupplier_Click(object sender, EventArgs e)
        {
            _showMdiChildForm(typeof(SupplierBrowseForm), sender, e, true);
        }

        private void miCustomer_Click(object sender, EventArgs e)
        {
            _showMdiChildForm(typeof(CustomerBrowseForm), sender, e, true);
        }

        private void miEmployee_Click(object sender, EventArgs e)
        {
            _showMdiChildForm(typeof(EmployeeBrowseForm), sender, e, true);
        }

        private void miCashOut_Click(object sender, EventArgs e)
        {
            //_showMdiChildForm(typeof(CashOutBrowseForm), sender, e, true);
        }

        private void miCashBalance_Click(object sender, EventArgs e)
        {
            ///_showMdiChildForm(typeof(CashBalanceBrowseForm), sender, e, true);
        }

        private void miCashIn_Click(object sender, EventArgs e)
        {
            //_showMdiChildForm(typeof(CashInBrowseForm), sender, e, true);
        }

        private void miSalary_Click(object sender, EventArgs e)
        {
            //_showMdiChildForm(typeof(SalaryBrowseForm), sender, e, true);
        }

        #region helper

        private bool _showMdiChildForm(Type formType, object sender, EventArgs e, bool isSingleton = true)
        {
            this.IsBusy = true;
            try
            {
                //var titleText = (sender is ToolStripItem) ? (sender as ToolStripItem).Text : string.Empty;

                if (isSingleton)
                {
                    foreach (MdiChildForm f in this.MdiChildren)
                    {
                        if (f.GetType() == formType/* && f.Title == titleText*/)
                        {
                            //if (f.WindowState == FormWindowState.Minimized)
                            //{
                            //    f.WindowState = FormWindowState.Normal;
                            //}
                            f.WindowState = FormWindowState.Maximized;
                            f.Visible = true;
                            f.BringToFront();
                            f.Activate();
                            f.Focus();
                            return true;
                        }
                    }
                }

                try
                {
                    var newForm = (MdiChildForm)Activator.CreateInstance(formType);
                    newForm.MdiParent = this;
                    //newForm.Title = titleText;
                    newForm.Show();
                    newForm.WindowState = FormWindowState.Maximized;
                    newForm.BringToFront();
                    newForm.Activate();
                    newForm.Focus();
                    return true;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            finally
            {
                this.IsBusy = false;
            }
        }

        private DialogResult _showDialogForm(Type formType, object sender, EventArgs e)
        {
            this.IsBusy = true;
            try
            {
                var text = (sender is ToolStripItem) ? (sender as ToolStripItem).Text : string.Empty;

                try
                {
                    var dialogForm = (DialogForm)Activator.CreateInstance(formType);
                    dialogForm.Text = text;
                    return dialogForm.ShowDialog();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            finally
            {
                this.IsBusy = false;
            }
        }

        private bool _showLoginForm()
        {
            this.IsBusy = true;
            try
            {
                _disableAllMenu();
                _closeAllForm();
                var f = new LoginForm("admin", "admin");
                if (f.ShowDialog() == DialogResult.OK)
                {
                    _enableAllMenu();
                    this.WindowState = FormWindowState.Maximized;
                    return true;
                }
                else
                {
                    _disableAllMenu();
                    return false;
                }
            }
            finally
            {
                this.IsBusy = false;
            }
        }

        private string GetTitleTextFromMenuItem(object sender)
        {
            return (sender is ToolStripItem) ? (sender as ToolStripItem).Text : string.Empty;
        }

        private void _enableAllMenu()
        {
            Utility.ChangeMenuItem(true, menuStrip1.Items, null);
        }

        private void _disableAllMenu()
        {
            ToolStripItem[] exclusion = { miReLogin, miCloseApp };
            Utility.ChangeMenuItem(false, menuStrip1.Items, new ToolStripItemCollection(menuStrip1, exclusion));
        }

        private void _closeAllForm()
        {
            foreach (Form f in this.MdiChildren)
            {
                f.Close();
            }
        }

        private void _miniAllForm()
        {
            foreach (Form f in this.MdiChildren)
            {
                f.WindowState = FormWindowState.Minimized;
            }
        }

        #endregion

        private void miTest_Click(object sender, EventArgs e)
        {
            var f = new TestForm();
            f.ShowDialog();
        }

        private void miStoreReport_Click(object sender, EventArgs e)
        {
            _showMdiChildForm(typeof(StoreReportForm), sender, e, true);
        }

        private void miCashReport_Click(object sender, EventArgs e)
        {
            _showMdiChildForm(typeof(CashReportForm), sender, e, true);
        }

        private void miReceivableReport_Click(object sender, EventArgs e)
        {
            //
        }

        private void miPayableReport_Click(object sender, EventArgs e)
        {
            //
        }

    }
}
