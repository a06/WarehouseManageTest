using System;
using System.Windows.Forms;
using System.Drawing;

namespace WarehouseManage.UI.WinForm.Controls
{
    public class TextboxWithButton : TextBox
    {
        public event System.EventHandler ButtonClick = null;

        //[System.Runtime.InteropServices.DllImport("user32.dll")]
        //?执行后不能绑定数据
        ////private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);

        private const int SPLIT = 6;
        //private const int BUTTON_WIDTH = 23;
        private readonly Label label = null;
        private readonly Button button = null;
        private readonly ToolTip toolTip = null;

        //--Property
        private bool IsBusy
        {
            set
            {
                if (value == true)
                    this.Cursor = Cursors.WaitCursor;
                button.Enabled = (value == false);
                if (value == false)
                    this.Cursor = Cursors.Default;
            }
        }

        public TabAlignment LabelAlignment
        {
            get { return _labelAlignment; }
            set
            {
                _labelAlignment = value;
                _setLabelLocation();
                if (this.DesignMode)
                {
                    label.Refresh();
                }
            }
        }
        private TabAlignment _labelAlignment = TabAlignment.Left;

        public bool LabelAutoSize
        {
            get { return label.AutoSize; }
            set
            {
                label.AutoSize = value;
                if (value == false)
                {
                    label.Width = this.Width;
                    label.Height = this.Height;
                }
                _setLabelLocation();
                if (this.DesignMode)
                {
                    label.Refresh();
                }
            }
        }

        public BorderStyle LabelBorderStyle
        {
            get { return label.BorderStyle; }
            set
            {
                label.BorderStyle = value;
            }
        }

        public string LabelText
        {
            get { return label.Text; }
            set
            {
                label.Text = value;
                _setLabelLocation();
                if (this.DesignMode)
                {
                    label.Refresh();
                }
            }
        }


        public Cursor ButtonCursor
        {
            get { return button.Cursor; }
            set { button.Cursor = value; }
        }

        public Image ButtonImage
        {
            get { return button.Image; }
            set { button.Image = value; }
        }

        public Size ButtonSize
        {
            get { return button.Size; }
            set { button.Size = value; }
        }

        public bool ButtonTabStop
        {
            get { return _buttonTabStop; }
            set
            {
                _buttonTabStop = value;
                button.TabStop = value;
            }
        }
        private bool _buttonTabStop = false;

        //--Contructor
        public TextboxWithButton()
            : base()
        {
            label = new Label()
            {
                Parent = this,
                AutoSize = true,
                TextAlign = ContentAlignment.MiddleCenter,
                Text = "LabelText",
            };

            button = new Button()
            {
                Parent = this,
                //Visible = false,
                //BackColor = SystemColors.ButtonFace,
                //Margin = new System.Windows.Forms.Padding(1, 1, 1, 1),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                TabStop = false,
                Text = "…",
            };
            _setButtonSize();
            _setButtonLocation();
            button.Click += new EventHandler(button_Click);

            toolTip = new ToolTip();
            toolTip.AutoPopDelay = 5000;
            toolTip.InitialDelay = 1000;
            toolTip.ReshowDelay = 500;
            toolTip.ShowAlways = true;
            toolTip.SetToolTip(button, "F12 ( Ctrl + Insert )"); 
        }

        //--Override
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            _setLabelLocation();
            _setButtonSize();
            _setButtonLocation();
        }

        protected override void OnMove(EventArgs e)
        {
            base.OnMove(e);
            _setLabelLocation();
            _setButtonSize();
            _setButtonLocation();
        }

        protected override void OnParentChanged(EventArgs e)
        {
            base.OnParentChanged(e);
            if (this.Parent != null)
            {
                label.Parent = this.Parent;
                _setLabelLocation();
            }
        }

        protected override void OnEnter(EventArgs e)
        {
            this.BackColor = Color.Azure; //#FFF0FFFF;
            this.SelectAll();

            base.OnEnter(e);
        }

        protected override void OnLeave(EventArgs e)
        {
            this.BackColor = SystemColors.Window;

            base.OnLeave(e);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyData == Keys.Space)
            {
                button.PerformClick();
            }
            base.OnKeyUp(e);
        }

        protected override void OnBorderStyleChanged(EventArgs e)
        {
            if (this.BorderStyle == BorderStyle.FixedSingle)
            {
                button.FlatStyle = FlatStyle.Flat;
            }
            else if (this.BorderStyle == BorderStyle.Fixed3D)
            {
                button.FlatStyle = FlatStyle.Standard;
            }
            base.OnBorderStyleChanged(e);
        }

        protected override void OnClientSizeChanged(EventArgs e)
        {
            _setButtonSize();
            _setButtonLocation();

            base.OnClientSizeChanged(e);
        }

        protected override void Dispose(bool disposing)
        {
            label.Dispose();
            button.Dispose();
            base.Dispose(disposing);
        }

        protected override void OnReadOnlyChanged(EventArgs e)
        {
            base.OnReadOnlyChanged(e);

            this.BackColor = SystemColors.Window;
        }

        //--Event
        private void button_Click(object sender, EventArgs e)
        {
            this.IsBusy = true;
            try
            {
                if (ButtonClick != null) ButtonClick(button, e);
                if (this.Text == string.Empty)
                {
                    this.Focus();
                }
            }
            finally
            {
                this.IsBusy = false;
            }
        }

        //--Helper
        private void _setLabelLocation()
        {
            switch (this.LabelAlignment)
            {
                case TabAlignment.Bottom:
                    label.Location = new Point(
                        this.Left + (this.Width - label.Width) / 2,
                        label.AutoSize ? this.Bottom + 3 : this.Bottom - 1
                        );
                    break;
                case TabAlignment.Left:
                    label.Location = new Point(
                        label.AutoSize ? this.Left - label.Width - 3 : this.Left - label.Width + 1,
                        this.Top + (this.Height - label.Height) / 2
                        );
                    break;
                case TabAlignment.Right:
                    label.Location = new Point(
                        label.AutoSize ? this.Right + 3 : this.Right - 1,
                        this.Top + (this.Height - label.Height) / 2
                        );
                    break;
                case TabAlignment.Top:
                    label.Location = new Point(
                        this.Left + (this.Width - label.Width) / 2,
                        label.AutoSize ? this.Top - label.Height - 3 : this.Top - label.Height + 1
                        );
                    break;
                default:
                    break;
            }
        }

        private void _setButtonSize()
        {
            var height = this.ClientSize.Height;
            //if (button.Height != height)
            {
                button.Size = new Size(height + 2, height - 0);
            }
        }

        private void _setButtonLocation()
        {
            button.Location = new Point(this.Width - button.Width - 4, 0);
            // Send EM_SETMARGINS to prevent text from disappearing underneath the button
            //?执行后不能绑定数据
            ////SendMessage(this.Handle, 0xd3, (IntPtr)2, (IntPtr)((button.Width + 2) << 16));
        }
    }
}
