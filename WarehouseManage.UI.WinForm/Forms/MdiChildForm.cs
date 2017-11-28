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
    public partial class MdiChildForm : Form
    {
        public virtual string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                this.Text = value;
            }
        }
        private string _title;

        protected virtual bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                if (_isBusy) this.Cursor = Cursors.WaitCursor;
                SetFormDisplay();
                if (!_isBusy) this.Cursor = Cursors.Default;
            }
        }
        private bool _isBusy;

        //--Method
        protected virtual void SetFormDisplay() { }

        //--Constructor
        public MdiChildForm()
        {
            InitializeComponent();
        }
    }
}
