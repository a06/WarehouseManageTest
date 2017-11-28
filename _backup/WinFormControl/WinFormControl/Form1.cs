using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinFormControl
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DataColumn dc1 = new DataColumn("weibo", typeof(System.String));
            dt.Columns.Add(dc1);

            DataColumn dc2 = new DataColumn("mail", typeof(System.String));
            dt.Columns.Add(dc2);

            DataColumn dc3 = new DataColumn("blog", typeof(System.String));
            dt.Columns.Add(dc3);

            for (int i = 0; i < 50; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = "下里巴人simple";
                dr[1] = "524300045@qq.com";
                dr[2] = "msdn" + i.ToString();
                dt.Rows.Add(dr);
            }
            //设置要显示按钮的单元列
            string[] showcell = { "weibo", "mail" };
            this.dataGridViewButton1.SetParam(showcell);
            this.dataGridViewButton1.DataSource = dt;
        }

        private void dataGridViewButton1_ButtonSelectClick()
        {
            Form2 f2 = new Form2();
            if (f2.ShowDialog()==DialogResult.OK)
            {
                this.dataGridViewButton1.CurrentCell.Value = f2.ReturnText;
            }
        }
    }
}
