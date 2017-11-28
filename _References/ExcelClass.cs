using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yuxin.Store.BllClass
{
    public class ExcelClass
    {
        private Dictionary<int ,string> tabFiled;
        public ExcelClass(Dictionary<int, string> tabFiled)
        {
            this.tabFiled = tabFiled;
        }

        #region Excel导出方法
        /// <summary>
        /// 导出为Excel方法
        /// </summary>
        /// <param name="savePath">保存EXCEL的路径,如"C:\\ ab.xls"</param>
        /// <param name="dt1">数据表-可以改为范型集合</param>

        public void ToExcel(string savePath, System.Windows.Forms.DataGridView dgv)
        {
            Interop.Excel.ApplicationClass xlApp = new Interop.Excel.ApplicationClass();
            Interop.Excel.Workbooks workbooks = xlApp.Workbooks;
            Interop.Excel.Workbook workbook = workbooks.Add(Interop.Excel.XlWBATemplate.xlWBATWorksheet);
            Interop.Excel.Worksheet worksheet = (Interop.Excel.Worksheet)workbook.Worksheets[1];

            Interop.Excel.Range range = (Interop.Excel.Range)worksheet.Columns;
            range.EntireColumn.AutoFit();   //自动调整列宽
            range.NumberFormatLocal = "@";

            worksheet.Name = tabFiled[0];//命名工作表的名称


            try
            {
                //加列头
                for (int i = 1; i < tabFiled.Count; i++)
                {
                    worksheet.Cells[1, i] = tabFiled[i];
                }

                //加列值
                for (int p = 0; p < dgv.Rows.Count; p++)
                {
                    for (int j = 0; j < dgv.Columns.Count; j++)
                    {
                        worksheet.Cells[p + 2, j + 1] = dgv.Rows[p].Cells[j].Value.ToString();
                    }
                }
                workbook.Saved = true;
                workbook.SaveCopyAs(savePath);
            }
            catch (Exception ed)
            {
                throw new Exception(ed.Message);
            }
            finally
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet);
                worksheet = null;
                System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
                workbook = null;
                workbooks.Close();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(workbooks);
                workbooks = null;
                xlApp.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp);
                xlApp = null;
                GC.Collect();//使用此方法强制对所有代码进行垃圾回收。
            }
            //xlApp.Visible = true;//如果要显示EXCEL，那么finally语句的内容就不应该执行
        }
        #endregion| 
    }
}
