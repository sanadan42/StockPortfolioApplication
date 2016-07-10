namespace StockPortfolioApplication
{
    partial class ctlDividendTransaction
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grpDividendTransactions = new System.Windows.Forms.GroupBox();
            this.btnDividendSave = new System.Windows.Forms.Button();
            this.dtpDividend = new System.Windows.Forms.DateTimePicker();
            this.lblDividendEquity = new System.Windows.Forms.Label();
            this.cmbDividendAccount = new System.Windows.Forms.ComboBox();
            this.lblDividendAccount = new System.Windows.Forms.Label();
            this.cmbDividendEquity = new System.Windows.Forms.ComboBox();
            this.lblDividendDate = new System.Windows.Forms.Label();
            this.txtDividend = new System.Windows.Forms.TextBox();
            this.lblDividendValue = new System.Windows.Forms.Label();
            this.dgvDividendTransactions = new System.Windows.Forms.DataGridView();
            this.grpDividendTransactions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDividendTransactions)).BeginInit();
            this.SuspendLayout();
            // 
            // grpDividendTransactions
            // 
            this.grpDividendTransactions.Controls.Add(this.btnDividendSave);
            this.grpDividendTransactions.Controls.Add(this.dtpDividend);
            this.grpDividendTransactions.Controls.Add(this.lblDividendEquity);
            this.grpDividendTransactions.Controls.Add(this.cmbDividendAccount);
            this.grpDividendTransactions.Controls.Add(this.lblDividendAccount);
            this.grpDividendTransactions.Controls.Add(this.cmbDividendEquity);
            this.grpDividendTransactions.Controls.Add(this.lblDividendDate);
            this.grpDividendTransactions.Controls.Add(this.txtDividend);
            this.grpDividendTransactions.Controls.Add(this.lblDividendValue);
            this.grpDividendTransactions.Location = new System.Drawing.Point(0, 0);
            this.grpDividendTransactions.Name = "grpDividendTransactions";
            this.grpDividendTransactions.Size = new System.Drawing.Size(750, 109);
            this.grpDividendTransactions.TabIndex = 96;
            this.grpDividendTransactions.TabStop = false;
            this.grpDividendTransactions.Text = "Dividend Transactions";
            // 
            // btnDividendSave
            // 
            this.btnDividendSave.Location = new System.Drawing.Point(358, 44);
            this.btnDividendSave.Name = "btnDividendSave";
            this.btnDividendSave.Size = new System.Drawing.Size(79, 21);
            this.btnDividendSave.TabIndex = 97;
            this.btnDividendSave.Text = "Save";
            this.btnDividendSave.UseVisualStyleBackColor = true;
            this.btnDividendSave.Click += new System.EventHandler(this.btnDividendSave_Click);
            // 
            // dtpDividend
            // 
            this.dtpDividend.Location = new System.Drawing.Point(11, 43);
            this.dtpDividend.Name = "dtpDividend";
            this.dtpDividend.Size = new System.Drawing.Size(122, 20);
            this.dtpDividend.TabIndex = 93;
            // 
            // lblDividendEquity
            // 
            this.lblDividendEquity.AutoSize = true;
            this.lblDividendEquity.Location = new System.Drawing.Point(228, 24);
            this.lblDividendEquity.Name = "lblDividendEquity";
            this.lblDividendEquity.Size = new System.Drawing.Size(36, 13);
            this.lblDividendEquity.TabIndex = 90;
            this.lblDividendEquity.Text = "Equity";
            // 
            // cmbDividendAccount
            // 
            this.cmbDividendAccount.FormattingEnabled = true;
            this.cmbDividendAccount.Location = new System.Drawing.Point(139, 43);
            this.cmbDividendAccount.Name = "cmbDividendAccount";
            this.cmbDividendAccount.Size = new System.Drawing.Size(70, 21);
            this.cmbDividendAccount.TabIndex = 85;
            // 
            // lblDividendAccount
            // 
            this.lblDividendAccount.AutoSize = true;
            this.lblDividendAccount.Location = new System.Drawing.Point(153, 24);
            this.lblDividendAccount.Name = "lblDividendAccount";
            this.lblDividendAccount.Size = new System.Drawing.Size(47, 13);
            this.lblDividendAccount.TabIndex = 91;
            this.lblDividendAccount.Text = "Account";
            // 
            // cmbDividendEquity
            // 
            this.cmbDividendEquity.FormattingEnabled = true;
            this.cmbDividendEquity.Location = new System.Drawing.Point(215, 43);
            this.cmbDividendEquity.Name = "cmbDividendEquity";
            this.cmbDividendEquity.Size = new System.Drawing.Size(70, 21);
            this.cmbDividendEquity.TabIndex = 86;
            // 
            // lblDividendDate
            // 
            this.lblDividendDate.AutoSize = true;
            this.lblDividendDate.Location = new System.Drawing.Point(57, 24);
            this.lblDividendDate.Name = "lblDividendDate";
            this.lblDividendDate.Size = new System.Drawing.Size(30, 13);
            this.lblDividendDate.TabIndex = 94;
            this.lblDividendDate.Text = "Date";
            // 
            // txtDividend
            // 
            this.txtDividend.Location = new System.Drawing.Point(293, 44);
            this.txtDividend.Name = "txtDividend";
            this.txtDividend.Size = new System.Drawing.Size(59, 20);
            this.txtDividend.TabIndex = 89;
            // 
            // lblDividendValue
            // 
            this.lblDividendValue.AutoSize = true;
            this.lblDividendValue.Location = new System.Drawing.Point(298, 25);
            this.lblDividendValue.Name = "lblDividendValue";
            this.lblDividendValue.Size = new System.Drawing.Size(49, 13);
            this.lblDividendValue.TabIndex = 88;
            this.lblDividendValue.Text = "Dividend";
            // 
            // dgvDividendTransactions
            // 
            this.dgvDividendTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDividendTransactions.Location = new System.Drawing.Point(3, 122);
            this.dgvDividendTransactions.Name = "dgvDividendTransactions";
            this.dgvDividendTransactions.Size = new System.Drawing.Size(921, 475);
            this.dgvDividendTransactions.TabIndex = 97;
            // 
            // ctlDividendTransaction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvDividendTransactions);
            this.Controls.Add(this.grpDividendTransactions);
            this.Name = "ctlDividendTransaction";
            this.Size = new System.Drawing.Size(927, 597);
            this.grpDividendTransactions.ResumeLayout(false);
            this.grpDividendTransactions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDividendTransactions)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpDividendTransactions;
        private System.Windows.Forms.Button btnDividendSave;
        private System.Windows.Forms.DateTimePicker dtpDividend;
        private System.Windows.Forms.Label lblDividendEquity;
        private System.Windows.Forms.ComboBox cmbDividendAccount;
        private System.Windows.Forms.Label lblDividendAccount;
        private System.Windows.Forms.ComboBox cmbDividendEquity;
        private System.Windows.Forms.Label lblDividendDate;
        private System.Windows.Forms.TextBox txtDividend;
        private System.Windows.Forms.Label lblDividendValue;
        private System.Windows.Forms.DataGridView dgvDividendTransactions;
    }
}
