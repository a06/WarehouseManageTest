namespace WarehouseManage.UI.WinForm.Forms
{
    partial class SettingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingForm));
            this.toolStripFormCtrl = new System.Windows.Forms.ToolStrip();
            this.btnOK = new System.Windows.Forms.ToolStripButton();
            this.btnCancel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnApply = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnDefault = new System.Windows.Forms.ToolStripButton();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.toolStripFormCtrl.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripFormCtrl
            // 
            this.toolStripFormCtrl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStripFormCtrl.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnOK,
            this.btnCancel,
            this.toolStripSeparator1,
            this.btnApply,
            this.toolStripSeparator2,
            this.btnDefault});
            this.toolStripFormCtrl.Location = new System.Drawing.Point(0, 393);
            this.toolStripFormCtrl.Name = "toolStripFormCtrl";
            this.toolStripFormCtrl.Size = new System.Drawing.Size(632, 25);
            this.toolStripFormCtrl.TabIndex = 3;
            // 
            // btnOK
            // 
            this.btnOK.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.Image")));
            this.btnOK.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(37, 22);
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(61, 22);
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnApply
            // 
            this.btnApply.Image = ((System.Drawing.Image)(resources.GetObject("btnApply.Image")));
            this.btnApply.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(55, 22);
            this.btnApply.Text = "Apply";
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnDefault
            // 
            this.btnDefault.Image = ((System.Drawing.Image)(resources.GetObject("btnDefault.Image")));
            this.btnDefault.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDefault.Name = "btnDefault";
            this.btnDefault.Size = new System.Drawing.Size(67, 22);
            this.btnDefault.Text = "Default";
            this.btnDefault.Click += new System.EventHandler(this.btnDefault_Click);
            // 
            // tabControl
            // 
            this.tabControl.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(632, 393);
            this.tabControl.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(624, 365);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Page1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 418);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.toolStripFormCtrl);
            this.MaximizeBox = false;
            this.Name = "SettingForm";
            this.Text = "SettingForm";
            this.Load += new System.EventHandler(this.SettingForm_Load);
            this.Shown += new System.EventHandler(this.SettingForm_Shown);
            this.toolStripFormCtrl.ResumeLayout(false);
            this.toolStripFormCtrl.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStripFormCtrl;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnOK;
        private System.Windows.Forms.ToolStripButton btnCancel;
        private System.Windows.Forms.ToolStripButton btnApply;
        private System.Windows.Forms.TabControl tabControl;
        protected System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnDefault;
    }
}