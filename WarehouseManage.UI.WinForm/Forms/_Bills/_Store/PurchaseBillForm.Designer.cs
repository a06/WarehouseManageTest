namespace WarehouseManage.UI.WinForm.Forms
{
    partial class PurchaseBillForm
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
            this.txtSupplier = new WarehouseManage.UI.WinForm.Controls.TextboxWithButton();
            this.txtDescription = new WarehouseManage.UI.WinForm.Controls.TextboxWithLabel();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.pnlContainer.SuspendLayout();
            this.pnlTitle.SuspendLayout();
            this.groupBoxContent.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContainer
            // 
            this.pnlContainer.Size = new System.Drawing.Size(786, 474);
            this.pnlTitle.Controls.SetChildIndex(this.dtpBillDate, 0);
            this.pnlTitle.Controls.SetChildIndex(this.txtBillCode, 0);
            // 
            // groupBoxContent
            // 
            this.groupBoxContent.Size = new System.Drawing.Size(792, 526);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtDescription);
            this.panel1.Controls.Add(this.txtSupplier);
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(0, 441);
            // 
            // txtSupplier
            // 
            this.txtSupplier.ButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.txtSupplier.ButtonImage = null;
            this.txtSupplier.ButtonSize = new System.Drawing.Size(18, 16);
            this.txtSupplier.ButtonTabStop = true;
            this.txtSupplier.LabelAlignment = System.Windows.Forms.TabAlignment.Left;
            this.txtSupplier.LabelAutoSize = true;
            this.txtSupplier.LabelBorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSupplier.LabelText = "Supplier";
            this.txtSupplier.Location = new System.Drawing.Point(110, 8);
            this.txtSupplier.Name = "txtSupplier";
            this.txtSupplier.Size = new System.Drawing.Size(200, 20);
            this.txtSupplier.TabIndex = 0;
            this.txtSupplier.ButtonClick += new System.EventHandler(this.txtSupplier_ButtonClick);
            // 
            // txtDescription
            // 
            this.txtDescription.LabelAlignment = System.Windows.Forms.TabAlignment.Left;
            this.txtDescription.LabelAutoSize = true;
            this.txtDescription.LabelBorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDescription.LabelText = "Description";
            this.txtDescription.Location = new System.Drawing.Point(520, 8);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(256, 20);
            this.txtDescription.TabIndex = 6;
            // 
            // PurchaseBillForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Name = "PurchaseBillForm";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.pnlContainer.ResumeLayout(false);
            this.pnlTitle.ResumeLayout(false);
            this.pnlTitle.PerformLayout();
            this.groupBoxContent.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.TextboxWithButton txtSupplier;
        private Controls.TextboxWithLabel txtDescription;
    }
}
