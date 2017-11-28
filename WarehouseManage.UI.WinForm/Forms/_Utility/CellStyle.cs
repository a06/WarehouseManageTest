using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace WarehouseManage.UI.WinForm
{
    public static class CellStyle
    {
        public static DataGridViewCellStyle DecimalCellStyle
        {
            get
            {
                return new DataGridViewCellStyle()
                {
                    Alignment = DataGridViewContentAlignment.MiddleRight,
                    Format = "0.##",
                };
            }
        }

        public static DataGridViewCellStyle ReadonlyDecimalCellStyle
        {
            get
            {
                return new DataGridViewCellStyle()
                {
                    Alignment = DataGridViewContentAlignment.MiddleRight,
                    Format = "0.##",
                    BackColor = System.Drawing.Color.Gainsboro,
                };
            }
        }

        public static DataGridViewCellStyle MoneyCellStyle
        {
            get
            {
                return new DataGridViewCellStyle()
                {
                    Alignment = DataGridViewContentAlignment.MiddleRight,
                    Format = "0.00",
                };
            }
        }

        public static DataGridViewCellStyle ReadonlyMoneyCellStyle
        {
            get
            {
                return new DataGridViewCellStyle()
                {
                    Alignment = DataGridViewContentAlignment.MiddleRight,
                    Format = "0.00",
                    BackColor = System.Drawing.Color.Gainsboro,
                };
            }
        }

        public static DataGridViewCellStyle ReadonlyCellStyle
        {
            get
            {
                return new DataGridViewCellStyle()
                {
                    BackColor = System.Drawing.Color.Gainsboro,
                };
            }
        }
    }
}
