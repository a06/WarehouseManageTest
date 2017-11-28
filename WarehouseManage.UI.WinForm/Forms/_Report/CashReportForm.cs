using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using WarehouseManage.BusinessLogic;
using WarehouseManage.Common.Bills;
using WarehouseManage.Common.Entities;

namespace WarehouseManage.UI.WinForm.Forms
{
    public partial class CashReportForm : ReportForm
    {
        //--Constructor
        public CashReportForm()
        {
            InitializeComponent();

            this.Title = "即时现金";

            cmbItemsType.LabelText = "查看";
            cmbItemsType.Items.Clear();
            cmbItemsType.Items.Add("供应商");
            cmbItemsType.Items.Add("客户");
            cmbItemsType.Items.Add("员工");
            cmbItemsType.SelectedIndex = 0;

            this.ReportState = ReportState.CanExport;//BrowseState.CanAddItem & BrowseState.CanEditItem;
        }

        protected override void InitLoad()
        {

        }

        protected override void Reset()
        {
            //dtpBillDate2.Value = DateTime.Today;
            //dtpBillDate1.Value = dtpBillDate2.Value.AddMonths(-1);
            //txtSupplierName.Text = string.Empty;
        }

        protected override IEnumerable GetItems()
        {
            //var bl = new CashReportBL();

            //switch (cmbItemsType.SelectedIndex)
            //{
            //    case 0:
            //        return bl.GetSuppliers();
            //    case 1:
            //        return bl.GetCustomers();
            //    case 2:
            //        return bl.GetEmployees();
            //    default:
            //        return null;
            //}
            return null;
        }

        //protected override bool CreateItem()
        //{
        //    //var f = new CashBillForm();
        //    //f.BeginCreate();
        //    //return (f.ShowDialog() == DialogResult.OK);
        //    return false;
        //}

        private int _currentItemID
        {
            get
            {
                //return (dataGridView1.CurrentRow == null || !(dataGridView1.CurrentRow.DataBoundItem is CashHeadView))
                //           ? 0
                //           : (dataGridView1.CurrentRow.DataBoundItem as CashHeadView).CashID;
                return 0;
            }
        }

        //protected override bool EditItem()
        //{
        //    //var f = new CashBillForm();
        //    //f.BeginEdit(this._currentItemID);
        //    //return (f.ShowDialog() == DialogResult.OK);
        //    return false;
        //}

        //protected override bool DeleteItem()
        //{
        //    //var f = new CashBillForm();
        //    //f.BeginDelete(this._currentItemID);
        //    //return (f.ShowDialog() == DialogResult.OK);
        //    return false;
        //}

        protected override bool ViewItem()
        {
            //var f = new CashBillForm();
            //f.BeginView(this._currentItemID);
            //return (f.ShowDialog() == DialogResult.OK);
            return false;
        }

        #region GetColumns

        protected override DataGridViewColumn[] GetColumns()
        {
            if (cmbItemsType == null) return new DataGridViewColumn[] { };

            switch (cmbItemsType.SelectedIndex)
            {
                case 0:
                    return new DataGridViewColumn[]
                    {
                        new DataGridViewTextBoxColumn()
                        {
                            Name = "colSupplierName",
                            DataPropertyName = "SupplierName",
                            HeaderText = "供应商名称",
                            ReadOnly = true,
                            DefaultCellStyle = CellStyle.ReadonlyCellStyle,
                            Width = 200,
                        },
                        new DataGridViewTextBoxColumn()
                        {
                            Name = "colBeginSum",
                            DataPropertyName = "BeginSum",
                            HeaderText = "期初金额",
                            ReadOnly = true,
                            DefaultCellStyle = CellStyle.ReadonlyDecimalCellStyle,
                            Width = 80,
                        },
                        new DataGridViewTextBoxColumn()
                        {
                            Name = "colPurchaseSum",
                            DataPropertyName = "PurchaseSum",
                            HeaderText = "进货金额",
                            ReadOnly = true,
                            DefaultCellStyle = CellStyle.ReadonlyDecimalCellStyle,
                            Width = 80,
                        },
                        new DataGridViewTextBoxColumn()
                        {
                            Name = "colPurchaseReturnSum",
                            DataPropertyName = "PurchaseReturnSum",
                            HeaderText = "退货金额",
                            ReadOnly = true,
                            DefaultCellStyle = CellStyle.ReadonlyDecimalCellStyle,
                            Width = 80,
                        },
                        new DataGridViewTextBoxColumn()
                        {
                            Name = "colCashOutSum",
                            DataPropertyName = "CashOutSum",
                            HeaderText = "付款金额",
                            ReadOnly = true,
                            DefaultCellStyle = CellStyle.ReadonlyDecimalCellStyle,
                            Width = 80,
                        },
                        new DataGridViewTextBoxColumn()
                        {
                            Name = "colEndSum",
                            DataPropertyName = "EndSum",
                            HeaderText = "期末金额",
                            ReadOnly = true,
                            DefaultCellStyle = CellStyle.ReadonlyDecimalCellStyle,
                            Width = 80,
                        },
                    };
                case 1:
                    return new DataGridViewColumn[]
                    {
                        new DataGridViewTextBoxColumn()
                        {
                            Name = "colCustomerName",
                            DataPropertyName = "CustomerName",
                            HeaderText = "客户名称",
                            ReadOnly = true,
                            DefaultCellStyle = CellStyle.ReadonlyCellStyle,
                            Width = 200,
                        },
                        new DataGridViewTextBoxColumn()
                        {
                            Name = "colBeginSum",
                            DataPropertyName = "BeginSum",
                            HeaderText = "期初金额",
                            ReadOnly = true,
                            DefaultCellStyle = CellStyle.ReadonlyDecimalCellStyle,
                            Width = 80,
                        },
                        new DataGridViewTextBoxColumn()
                        {
                            Name = "colSaleSum",
                            DataPropertyName = "SaleSum",
                            HeaderText = "销售金额",
                            ReadOnly = true,
                            DefaultCellStyle = CellStyle.ReadonlyDecimalCellStyle,
                            Width = 80,
                        },
                        new DataGridViewTextBoxColumn()
                        {
                            Name = "colSaleReturnSum",
                            DataPropertyName = "SaleReturnSum",
                            HeaderText = "返还金额",
                            ReadOnly = true,
                            DefaultCellStyle = CellStyle.ReadonlyDecimalCellStyle,
                            Width = 80,
                        },
                        new DataGridViewTextBoxColumn()
                        {
                            Name = "colCashInSum",
                            DataPropertyName = "CashInSum",
                            HeaderText = "收款金额",
                            ReadOnly = true,
                            DefaultCellStyle = CellStyle.ReadonlyDecimalCellStyle,
                            Width = 80,
                        },
                        new DataGridViewTextBoxColumn()
                        {
                            Name = "colEndSum",
                            DataPropertyName = "EndSum",
                            HeaderText = "期末金额",
                            ReadOnly = true,
                            DefaultCellStyle = CellStyle.ReadonlyDecimalCellStyle,
                            Width = 80,
                        },
                    };
                case 2:
                    return new DataGridViewColumn[]
                    {
                        new DataGridViewTextBoxColumn()
                        {
                            Name = "colEmployeeName",
                            DataPropertyName = "EmployeeName",
                            HeaderText = "员工名称",
                            ReadOnly = true,
                            DefaultCellStyle = CellStyle.ReadonlyCellStyle,
                            Width = 200,
                        },
                        new DataGridViewTextBoxColumn()
                        {
                            Name = "colBeginSum",
                            DataPropertyName = "BeginSum",
                            HeaderText = "期初金额",
                            ReadOnly = true,
                            DefaultCellStyle = CellStyle.ReadonlyDecimalCellStyle,
                            Width = 80,
                        },
                        new DataGridViewTextBoxColumn()
                        {
                            Name = "colSenderFeeSum",
                            DataPropertyName = "SenderFeeSum",
                            HeaderText = "送货金额",
                            ReadOnly = true,
                            DefaultCellStyle = CellStyle.ReadonlyDecimalCellStyle,
                            Width = 80,
                        },
                        new DataGridViewTextBoxColumn()
                        {
                            Name = "colCollecterFeeSum",
                            DataPropertyName = "CollecterFeeSum",
                            HeaderText = "回扣金额",
                            ReadOnly = true,
                            DefaultCellStyle = CellStyle.ReadonlyDecimalCellStyle,
                            Width = 80,
                        },
                        new DataGridViewTextBoxColumn()
                        {
                            Name = "colSalarySum",
                            DataPropertyName = "SalarySum",
                            HeaderText = "工资金额",
                            ReadOnly = true,
                            DefaultCellStyle = CellStyle.ReadonlyDecimalCellStyle,
                            Width = 80,
                        },
                        new DataGridViewTextBoxColumn()
                        {
                            Name = "colEndSum",
                            DataPropertyName = "EndSum",
                            HeaderText = "期末金额",
                            ReadOnly = true,
                            DefaultCellStyle = CellStyle.ReadonlyDecimalCellStyle,
                            Width = 80,
                        },
                    };
                default:
                    return new DataGridViewColumn[] { };
            }
        }

        #endregion

        private void cmbItemsType_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.IsBusy = true;
            try
            {
                this.DataGridViewColumns = GetColumns();
                this.Search();
            }
            finally
            {
                this.IsBusy = false;
            }
        }
    }
}
