using System;
using System.Windows.Forms;
using System.Drawing;

namespace WarehouseManage.UI.WinForm.Controls
{
    public class ComboBoxWithLabel : ComboBox
    {
        private const int LABEL_SPLIT = 6;
        private const int LABEL_TOP = 3;
        private readonly Label label = null;

        //--Property
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

        //--Contructor
        public ComboBoxWithLabel()
            : base()
        {
            label = new Label()
            {
                Parent = this,
                AutoSize = true,
                TextAlign = ContentAlignment.MiddleCenter,
                Text = "LabelText",
            };
        }

        //--Override
        protected override void OnResize(EventArgs e)
        {
            _setLabelLocation();
            base.OnResize(e);
        }

        protected override void OnMove(EventArgs e)
        {
            _setLabelLocation();
            base.OnMove(e);
        }

        protected override void OnParentChanged(EventArgs e)
        {
            if (this.Parent != null)
            {
                label.Parent = this.Parent;
                _setLabelLocation();
            }
            base.OnParentChanged(e);
        }

        protected override void OnEnter(EventArgs e)
        {
            this.BackColor = Color.Azure; //#FFF0FFFF;
            base.OnEnter(e);
        }

        protected override void OnLeave(EventArgs e)
        {
            this.BackColor = SystemColors.Window;
            base.OnLeave(e);
        }

        protected override void Dispose(bool disposing)
        {
            label.Dispose();
            base.Dispose(disposing);
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
    }
}
