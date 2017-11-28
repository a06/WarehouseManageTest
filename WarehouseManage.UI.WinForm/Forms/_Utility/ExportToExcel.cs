using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

using Excel = Microsoft.Office.Interop.Excel;

namespace WarehouseManage.UI.WinForm
{
    public class ExportInfo
    {
        public string Title { get; set; }
        public string Filter { get; set; }
        public string Counter { get; set; }

        public ExportInfo()
        {
            this.Title = "";
            this.Filter = "";
            this.Counter = "";
        }
        public ExportInfo(string title, string filter, string counter)
        {
            this.Title = title;
            this.Filter = filter;
            this.Counter = counter;
        }

        public void Reset()
        {
            this.Title = string.Empty;
            this.Filter = string.Empty;
            this.Counter = string.Empty;
        }
    }

    public static class ExportToExcel
    {
        public static bool DataGridViewToExcel(ExportInfo exportInfo, DataGridView grid)
        {
            Excel.ApplicationClass excel = new Excel.ApplicationClass();
            Excel.Workbooks workbooks = excel.Workbooks;
            Excel.Workbook workbook = workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
            Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Worksheets[1];
            Excel.Range range = (Excel.Range)worksheet.Columns;

            try
            {
                worksheet.Name = "Sheet1";

                range.NumberFormatLocal = "@"; //设置数字格式为文本
                range.EntireColumn.AutoFit(); //自动调整列宽

                int rowIndex = 0;

                rowIndex += 1;
                worksheet.Cells[rowIndex, 1] = exportInfo.Title;
                rowIndex += 1;
                worksheet.Cells[rowIndex, 1] = exportInfo.Filter;
                rowIndex += 1;
                worksheet.Cells[rowIndex, 1] = exportInfo.Counter;

                rowIndex += 1;
                //title
                int c = 0;
                foreach (DataGridViewColumn column in grid.Columns)
                {
                    if (column.Visible != false)
                    {
                        c += 1;
                        range = (Excel.Range)worksheet.Columns[c];
                        range.ColumnWidth = column.Width / 8;   //大概grid列宽除8

                        worksheet.Cells[rowIndex, c] = column.HeaderText;
                    }
                }
                //title Font Color Style
                range = worksheet.Range[worksheet.Cells[rowIndex, 1], worksheet.Cells[rowIndex, c]];
                range.Font.Bold = true;
                range.Interior.ColorIndex = 15;

                //rows
                int r = rowIndex;
                foreach (DataGridViewRow row in grid.Rows)
                {
                    r += 1;
                    c = 0;
                    foreach (DataGridViewColumn column in grid.Columns)
                    {
                        if (column.Visible != false)
                        {
                            c += 1;
                            //worksheet.Cells[r, c] = Convert.ToString(row.Cells[column.Index].Value);
                            worksheet.Cells[r, c] = row.Cells[column.Index].Value;
                        }
                    }
                }
                //title + rows LineStyle
                range = worksheet.Range[worksheet.Cells[rowIndex, 1], worksheet.Cells[r, c]];
                range.Borders.LineStyle = 1;

                excel.Visible = true; //显示EXCEL
                return true;
            }
            catch (Exception e)
            {
                range.Clear();
                Marshal.ReleaseComObject(range);
                range = null;

                Marshal.ReleaseComObject(worksheet);
                worksheet = null;

                var saveChanges = false;
                workbook.Close(saveChanges);
                Marshal.ReleaseComObject(workbook);
                workbook = null;

                workbooks.Close();
                Marshal.ReleaseComObject(workbooks);
                workbooks = null;

                excel.Quit();
                Marshal.ReleaseComObject(excel);
                excel = null;

                GC.Collect(); //强制垃圾回收。

                throw new Exception(e.Message);
            }
        }
    }
}
