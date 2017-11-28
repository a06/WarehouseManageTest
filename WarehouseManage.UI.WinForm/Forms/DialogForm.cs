using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WarehouseManage.UI.WinForm.Forms
{
    public partial class DialogForm : Form
    {
        protected virtual bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                if (_isBusy != value)
                {
                    _isBusy = value;
                    this.SuspendLayout();

                    if (_isBusy) this.Cursor = Cursors.WaitCursor;
                    SetFormDisplay();
                    if (!_isBusy) this.Cursor = Cursors.Default;

                    this.ResumeLayout();
                }
            }
        }
        private bool _isBusy;

        // method
        protected virtual void SetFormDisplay() { }

        // constructor
        public DialogForm()
        {
            InitializeComponent();
        }
    }
}
