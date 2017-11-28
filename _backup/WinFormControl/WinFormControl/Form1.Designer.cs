namespace WinFormControl
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridViewButton1 = new UserControlDLL.DataGridViewButton();
            this.weibo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.blog = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewButton1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewButton1
            // 
            this.dataGridViewButton1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewButton1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.weibo,
            this.mail,
            this.blog});
            this.dataGridViewButton1.Location = new System.Drawing.Point(24, 37);
            this.dataGridViewButton1.Name = "dataGridViewButton1";
            this.dataGridViewButton1.RowTemplate.Height = 23;
            this.dataGridViewButton1.Size = new System.Drawing.Size(450, 150);
            this.dataGridViewButton1.TabIndex = 0;
            this.dataGridViewButton1.ButtonSelectClick += new UserControlDLL.DataGridViewButton.ButtonClick(this.dataGridViewButton1_ButtonSelectClick);
            // 
            // weibo
            // 
            this.weibo.DataPropertyName = "weibo";
            this.weibo.HeaderText = "微博";
            this.weibo.Name = "weibo";
            // 
            // mail
            // 
            this.mail.DataPropertyName = "mail";
            this.mail.HeaderText = "邮箱";
            this.mail.Name = "mail";
            // 
            // blog
            // 
            this.blog.DataPropertyName = "blog";
            this.blog.HeaderText = "博客";
            this.blog.Name = "blog";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 217);
            this.Controls.Add(this.dataGridViewButton1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewButton1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private UserControlDLL.DataGridViewButton dataGridViewButton1;
        private System.Windows.Forms.DataGridViewTextBoxColumn weibo;
        private System.Windows.Forms.DataGridViewTextBoxColumn mail;
        private System.Windows.Forms.DataGridViewTextBoxColumn blog;
    }
}

