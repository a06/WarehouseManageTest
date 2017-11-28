using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using WarehouseManage.Common;
using WarehouseManage.UI.WinForm.Properties;

namespace WarehouseManage.UI.WinForm.Forms
{
    public partial class EditForm : DialogForm
    {
        #region --Property

        protected virtual string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                lblTitle.Text = value;
                this.Text = "编辑" + value;
            }
        }
        private string _title;

        protected virtual string Status
        {
            get { return _status; }
            set
            {
                _status = value;
                statusLabel1.Text = value;
            }
        }
        private string _status;

        protected override void SetFormDisplay()
        {
            btnCreate.Enabled = !this.IsBusy && ((this.EditState & EditState.Modified) == 0 && (this.EditState & EditState.Created) == 0);
            btnDelete.Enabled = !this.IsBusy && ((this.EditState & EditState.Modified) == 0 && (this.EditState & EditState.Created) == 0);
            btnSave.Enabled =   !this.IsBusy && ((this.EditState & EditState.Modified) != 0 || (this.EditState & EditState.Created) != 0);
            btnUndo.Enabled =   !this.IsBusy && ((this.EditState & EditState.Modified) != 0 || (this.EditState & EditState.Created) != 0);
            btnExport.Enabled = !this.IsBusy && ((this.EditState & EditState.Modified) == 0 && (this.EditState & EditState.Created) == 0);
            btnSetting.Enabled= !this.IsBusy;
            btnClose.Enabled =  !this.IsBusy;
            switch (this.EditState)
            {
                case EditState.Detached:
                    break;
                case EditState.Unchanged:
                    this.Status = "[未修改]";
                    break;
                case EditState.Created:
                    this.Status = "[新增]";
                    break;
                case EditState.Deleted:
                    this.Status = "[删除]";
                    break;
                case EditState.Modified:
                    this.Status = "[已修改]";
                    break;
                case EditState.ReadOnly:
                    this.Status = "[查看]";
                    break;
                default:
                    break;
            }
        }

        public EditState EditState
        {
            get { return _editState; }
            set
            {
                _editState = value;
                SetFormDisplay();
            }
        }
        private EditState _editState;

        /// <summary>
        /// 记住返回值
        /// </summary>
        protected DialogResult RememberDialogResult;

        protected Timer timer1;
        protected BindingSource bindingSource1;
        protected ErrorProvider errorProvider1;

        #endregion -----------

        //--protected----------
        protected virtual void InitLoad() { }
        protected virtual void InitShown() { }

        protected virtual ResultMessage GetByID(int id) { throw new NotImplementedException(); }
        protected virtual ResultMessage Create() { throw new NotImplementedException(); }
        protected virtual ResultMessage Delete() { throw new NotImplementedException(); }
        protected virtual ResultMessage Save_Create() { throw new NotImplementedException(); }
        protected virtual ResultMessage Save_Update() { throw new NotImplementedException(); }
        protected virtual ResultMessage Undo() { throw new NotImplementedException(); }
        protected virtual ResultMessage CheckValid() { throw new NotImplementedException(); }

        protected virtual ResultMessage Export()
        {
            return new ResultMessage(false, "NotImplemented");
        }
        protected virtual ResultMessage Setting()
        {
            return new ResultMessage(false, "NotImplemented");
        }

        protected virtual ResultMessage Save()
        {
            if ((this.EditState & EditState.Created) != 0)
            {
                return Save_Create();
            }
            else if ((this.EditState & EditState.Modified) != 0)
            {
                return Save_Update();
            }
            return new ResultMessage(false, "Not Save");
        }

        protected virtual void DataChanged(object sender, EventArgs e)
        {
            if (!bindingSource1.IsBindingSuspended)
            {
                if ((this.EditState & EditState.Created) != 0)
                {
                    this.EditState = EditState.Created;
                }
                else if ((this.EditState & EditState.Unchanged) != 0)
                {
                    this.EditState = EditState.Modified;
                }

                var ctrl = this.ActiveControl;
                if ((ctrl != null) && (errorProvider1.GetError(ctrl) != string.Empty))
                {
                    errorProvider1.SetError(ctrl, string.Empty);
                }
            }
        }

        //--public----------
        public virtual ResultMessage BeginCreate()
        {
            var rm = Create();
            if (rm.Result)
            {
                this.EditState = EditState.Created;
                Utility.FocusContainer(pnlContainer);
            }
            else
            {
                Utility.ShowError(rm.Message, this);
            }
            return rm;
        }

        public virtual ResultMessage BeginEdit(int id)
        {
            var rm = GetByID(id);
            if (rm.Result)
            {
                this.EditState = EditState.Unchanged;
                Utility.FocusContainer(pnlContainer);
            }
            else
            {
                Utility.ShowError(rm.Message, this);
            }
            return rm;
        }

        public virtual ResultMessage BeginDelete(int id)
        {
            var rm = GetByID(id);
            if (rm.Result)
            {
                this.EditState = EditState.Deleted;
                Utility.FocusContainer(pnlContainer);
            }
            else
            {
                Utility.ShowError(rm.Message, this);
            }
            return rm;
        }

        public virtual ResultMessage BeginView(int id)
        {
            var rm = GetByID(id);
            if (rm.Result)
            {
                this.EditState = EditState.ReadOnly;
                Utility.FocusContainer(pnlContainer);
            }
            else
            {
                Utility.ShowError(rm.Message, this);
            }
            return rm;
        }

        //--Constructor
        public EditForm()
        {
            InitializeComponent();

            this.Text = "编辑";
            this.Status = "";

            btnCreate.Text = Resources.ButtonText_Add;
            btnDelete.Text = Resources.ButtonText_Delete;
            btnSave.Text = Resources.ButtonText_Save;
            btnUndo.Text = Resources.ButtonText_Undo;
            btnExport.Text = Resources.ButtonText_Export;
            btnClose.Text = Resources.ButtonText_Close;

            this.RememberDialogResult = DialogResult.Cancel;
            errorProvider1 = new ErrorProvider { BlinkStyle = ErrorBlinkStyle.NeverBlink };
            bindingSource1 = new BindingSource();

            btnExport.Visible = false;
            btnSetting.Visible = false;
        }

        //--Event
        private void EditForm_Load(object sender, EventArgs e)
        {
            InitLoad();
        }

        private void EditForm_Shown(object sender, EventArgs e)
        {
            InitShown();

            if (this.EditState == EditState.Deleted)
            {
                btnDelete.PerformClick();
            }
        }

        private void EditForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            bindingSource1.EndEdit();
            e.Cancel = _checkChanges() == false;
            this.DialogResult = this.RememberDialogResult;
        }

        private void EditForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(13))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            this.IsBusy = true;
            try
            {
                BeginCreate();
            }
            finally
            {
                this.IsBusy = false;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            this.IsBusy = true;
            try
            {
                if (this.EditState != EditState.Deleted)
                {
                    this.EditState = EditState.Deleted;
                }
                if (Utility.ShowQuestionYesNo(string.Format(Resources.MessageText_ConfirmDelete, this.Title), Resources.MessageCaption_Question, this) == DialogResult.Yes)
                {
                    var rm = Delete();
                    if (rm.Result)
                    {
                        this.RememberDialogResult = DialogResult.OK;
                        BeginCreate();
                    }
                    else
                    {
                        Utility.ShowError(rm.Message, this);
                    }
                }
                else
                {
                    this.EditState = EditState.Unchanged;
                }
            }
            finally
            {
                this.IsBusy = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.IsBusy = true;
            try
            {
                bindingSource1.EndEdit();
                var rm = CheckValid();
                if (rm.Result)
                {
                    rm = Save();
                    if (rm.Result)
                    {
                        this.EditState = EditState.Unchanged;
                        this.RememberDialogResult = DialogResult.OK;
                    }
                    else
                    {
                        Utility.ShowError(rm.Message, this);
                    }
                }
                else
                {
                    Utility.ShowError(rm.Message, this);
                }
            }
            finally
            {
                this.IsBusy = false;
            }
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            this.IsBusy = true;
            try
            {
                bindingSource1.CancelEdit();
                if ((this.EditState & EditState.Created) != 0)
                {
                    this.BeginCreate();
                }
                else
                {
                    var rm = Undo();
                    if (rm.Result)
                    {
                        this.EditState = EditState.Unchanged;
                    }
                    else
                    {
                        Utility.ShowError(rm.Message, this);
                    }
                }
            }
            finally
            {
                this.IsBusy = false;
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            this.IsBusy = true;
            try
            {
                Export();
            }
            finally
            {
                this.IsBusy = false;
            }
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            this.IsBusy = true;
            try
            {
                Setting();
            }
            finally
            {
                this.IsBusy = false;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.IsBusy = true;
            try
            {
                this.Close();
            }
            finally
            {
                this.IsBusy = false;
            }
        }

        #region --Helper

        private bool _checkChanges()
        {
            if ((this.EditState & EditState.Modified) != 0)
            {
                switch (Utility.ShowQuestionYesNoCancel(Resources.MessageText_DataChange, Resources.MessageCaption_Question, this))
                {
                    case DialogResult.Yes:
                        var rm = CheckValid();
                        if (rm.Result)
                        {
                            rm = Save();
                            if (rm.Result)
                            {
                                this.EditState = EditState.Unchanged;
                                this.RememberDialogResult = DialogResult.OK;
                                return true;
                            }
                            else
                            {
                                Utility.ShowError(rm.Message, this);
                            }
                        }
                        else
                        {
                            Utility.ShowError(rm.Message, this);
                        }

                        return false;
                    case DialogResult.No:
                        return true;
                    default:
                        return false;
                }
            }
            return true;
        }

        #endregion

    }
}
