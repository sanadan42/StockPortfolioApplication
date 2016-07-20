namespace StockPortfolioApplication
{
    partial class ctlEquityTransaction
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
            this.grpTransactionEquities = new System.Windows.Forms.GroupBox();
            this.cmbTransactionEquity = new System.Windows.Forms.ComboBox();
            this.lblExchangeRate = new System.Windows.Forms.Label();
            this.cmbAccountEquity = new System.Windows.Forms.ComboBox();
            this.txtExchangeRate = new System.Windows.Forms.TextBox();
            this.cmbEquityEquity = new System.Windows.Forms.ComboBox();
            this.lblEquityTransactionDate = new System.Windows.Forms.Label();
            this.lblShares = new System.Windows.Forms.Label();
            this.dtpTransactionDate = new System.Windows.Forms.DateTimePicker();
            this.lblPrice = new System.Windows.Forms.Label();
            this.btnTransactionSave = new System.Windows.Forms.Button();
            this.lblCommission = new System.Windows.Forms.Label();
            this.lblAccountTo = new System.Windows.Forms.Label();
            this.numEquityShares = new System.Windows.Forms.NumericUpDown();
            this.cmbAccountTo = new System.Windows.Forms.ComboBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.lblEquityTransaction = new System.Windows.Forms.Label();
            this.txtCommission = new System.Windows.Forms.TextBox();
            this.lblEquityAccount = new System.Windows.Forms.Label();
            this.lblEquityEquity = new System.Windows.Forms.Label();
            this.dgvEquityTransactions = new System.Windows.Forms.DataGridView();
            this.grpTransactionEquities.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numEquityShares)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEquityTransactions)).BeginInit();
            this.SuspendLayout();
            // 
            // grpTransactionEquities
            // 
            this.grpTransactionEquities.Controls.Add(this.cmbTransactionEquity);
            this.grpTransactionEquities.Controls.Add(this.lblExchangeRate);
            this.grpTransactionEquities.Controls.Add(this.cmbAccountEquity);
            this.grpTransactionEquities.Controls.Add(this.txtExchangeRate);
            this.grpTransactionEquities.Controls.Add(this.cmbEquityEquity);
            this.grpTransactionEquities.Controls.Add(this.lblEquityTransactionDate);
            this.grpTransactionEquities.Controls.Add(this.lblShares);
            this.grpTransactionEquities.Controls.Add(this.dtpTransactionDate);
            this.grpTransactionEquities.Controls.Add(this.lblPrice);
            this.grpTransactionEquities.Controls.Add(this.btnTransactionSave);
            this.grpTransactionEquities.Controls.Add(this.lblCommission);
            this.grpTransactionEquities.Controls.Add(this.lblAccountTo);
            this.grpTransactionEquities.Controls.Add(this.numEquityShares);
            this.grpTransactionEquities.Controls.Add(this.cmbAccountTo);
            this.grpTransactionEquities.Controls.Add(this.txtPrice);
            this.grpTransactionEquities.Controls.Add(this.lblEquityTransaction);
            this.grpTransactionEquities.Controls.Add(this.txtCommission);
            this.grpTransactionEquities.Controls.Add(this.lblEquityAccount);
            this.grpTransactionEquities.Controls.Add(this.lblEquityEquity);
            this.grpTransactionEquities.Location = new System.Drawing.Point(0, 0);
            this.grpTransactionEquities.Name = "grpTransactionEquities";
            this.grpTransactionEquities.Size = new System.Drawing.Size(781, 109);
            this.grpTransactionEquities.TabIndex = 85;
            this.grpTransactionEquities.TabStop = false;
            this.grpTransactionEquities.Text = "Equity Transactions";
            // 
            // cmbTransactionEquity
            // 
            this.cmbTransactionEquity.FormattingEnabled = true;
            this.cmbTransactionEquity.Location = new System.Drawing.Point(141, 50);
            this.cmbTransactionEquity.Name = "cmbTransactionEquity";
            this.cmbTransactionEquity.Size = new System.Drawing.Size(90, 21);
            this.cmbTransactionEquity.TabIndex = 67;
            this.cmbTransactionEquity.SelectedIndexChanged += new System.EventHandler(this.cmbTransactionEquity_SelectedIndexChanged);
            // 
            // lblExchangeRate
            // 
            this.lblExchangeRate.AutoSize = true;
            this.lblExchangeRate.Location = new System.Drawing.Point(607, 32);
            this.lblExchangeRate.Name = "lblExchangeRate";
            this.lblExchangeRate.Size = new System.Drawing.Size(81, 13);
            this.lblExchangeRate.TabIndex = 83;
            this.lblExchangeRate.Text = "Exchange Rate";
            // 
            // cmbAccountEquity
            // 
            this.cmbAccountEquity.FormattingEnabled = true;
            this.cmbAccountEquity.Location = new System.Drawing.Point(237, 50);
            this.cmbAccountEquity.Name = "cmbAccountEquity";
            this.cmbAccountEquity.Size = new System.Drawing.Size(90, 21);
            this.cmbAccountEquity.TabIndex = 65;
            // 
            // txtExchangeRate
            // 
            this.txtExchangeRate.Location = new System.Drawing.Point(607, 50);
            this.txtExchangeRate.Name = "txtExchangeRate";
            this.txtExchangeRate.Size = new System.Drawing.Size(81, 20);
            this.txtExchangeRate.TabIndex = 82;
            // 
            // cmbEquityEquity
            // 
            this.cmbEquityEquity.FormattingEnabled = true;
            this.cmbEquityEquity.Location = new System.Drawing.Point(332, 50);
            this.cmbEquityEquity.Name = "cmbEquityEquity";
            this.cmbEquityEquity.Size = new System.Drawing.Size(70, 21);
            this.cmbEquityEquity.TabIndex = 66;
            // 
            // lblEquityTransactionDate
            // 
            this.lblEquityTransactionDate.AutoSize = true;
            this.lblEquityTransactionDate.Location = new System.Drawing.Point(59, 31);
            this.lblEquityTransactionDate.Name = "lblEquityTransactionDate";
            this.lblEquityTransactionDate.Size = new System.Drawing.Size(30, 13);
            this.lblEquityTransactionDate.TabIndex = 81;
            this.lblEquityTransactionDate.Text = "Date";
            // 
            // lblShares
            // 
            this.lblShares.AutoSize = true;
            this.lblShares.Location = new System.Drawing.Point(416, 31);
            this.lblShares.Name = "lblShares";
            this.lblShares.Size = new System.Drawing.Size(40, 13);
            this.lblShares.TabIndex = 68;
            this.lblShares.Text = "Shares";
            // 
            // dtpTransactionDate
            // 
            this.dtpTransactionDate.Location = new System.Drawing.Point(13, 50);
            this.dtpTransactionDate.Name = "dtpTransactionDate";
            this.dtpTransactionDate.Size = new System.Drawing.Size(122, 20);
            this.dtpTransactionDate.TabIndex = 80;
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(489, 31);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(31, 13);
            this.lblPrice.TabIndex = 69;
            this.lblPrice.Text = "Price";
            // 
            // btnTransactionSave
            // 
            this.btnTransactionSave.Location = new System.Drawing.Point(694, 50);
            this.btnTransactionSave.Name = "btnTransactionSave";
            this.btnTransactionSave.Size = new System.Drawing.Size(79, 21);
            this.btnTransactionSave.TabIndex = 79;
            this.btnTransactionSave.Text = "Save";
            this.btnTransactionSave.UseVisualStyleBackColor = true;
            this.btnTransactionSave.Click += new System.EventHandler(this.btnTransactionSave_Click);
            // 
            // lblCommission
            // 
            this.lblCommission.AutoSize = true;
            this.lblCommission.Location = new System.Drawing.Point(540, 31);
            this.lblCommission.Name = "lblCommission";
            this.lblCommission.Size = new System.Drawing.Size(62, 13);
            this.lblCommission.TabIndex = 70;
            this.lblCommission.Text = "Commission";
            // 
            // lblAccountTo
            // 
            this.lblAccountTo.AutoSize = true;
            this.lblAccountTo.Location = new System.Drawing.Point(208, 78);
            this.lblAccountTo.Name = "lblAccountTo";
            this.lblAccountTo.Size = new System.Drawing.Size(20, 13);
            this.lblAccountTo.TabIndex = 78;
            this.lblAccountTo.Text = "To";
            this.lblAccountTo.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblAccountTo.Visible = false;
            // 
            // numEquityShares
            // 
            this.numEquityShares.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numEquityShares.Location = new System.Drawing.Point(411, 50);
            this.numEquityShares.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numEquityShares.Name = "numEquityShares";
            this.numEquityShares.Size = new System.Drawing.Size(54, 20);
            this.numEquityShares.TabIndex = 71;
            // 
            // cmbAccountTo
            // 
            this.cmbAccountTo.FormattingEnabled = true;
            this.cmbAccountTo.Location = new System.Drawing.Point(237, 75);
            this.cmbAccountTo.Name = "cmbAccountTo";
            this.cmbAccountTo.Size = new System.Drawing.Size(90, 21);
            this.cmbAccountTo.TabIndex = 77;
            this.cmbAccountTo.Visible = false;
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(473, 50);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(59, 20);
            this.txtPrice.TabIndex = 72;
            // 
            // lblEquityTransaction
            // 
            this.lblEquityTransaction.AutoSize = true;
            this.lblEquityTransaction.Location = new System.Drawing.Point(155, 31);
            this.lblEquityTransaction.Name = "lblEquityTransaction";
            this.lblEquityTransaction.Size = new System.Drawing.Size(63, 13);
            this.lblEquityTransaction.TabIndex = 76;
            this.lblEquityTransaction.Text = "Transaction";
            // 
            // txtCommission
            // 
            this.txtCommission.Location = new System.Drawing.Point(542, 50);
            this.txtCommission.Name = "txtCommission";
            this.txtCommission.Size = new System.Drawing.Size(59, 20);
            this.txtCommission.TabIndex = 73;
            // 
            // lblEquityAccount
            // 
            this.lblEquityAccount.AutoSize = true;
            this.lblEquityAccount.Location = new System.Drawing.Point(259, 31);
            this.lblEquityAccount.Name = "lblEquityAccount";
            this.lblEquityAccount.Size = new System.Drawing.Size(47, 13);
            this.lblEquityAccount.TabIndex = 75;
            this.lblEquityAccount.Text = "Account";
            // 
            // lblEquityEquity
            // 
            this.lblEquityEquity.AutoSize = true;
            this.lblEquityEquity.Location = new System.Drawing.Point(345, 31);
            this.lblEquityEquity.Name = "lblEquityEquity";
            this.lblEquityEquity.Size = new System.Drawing.Size(36, 13);
            this.lblEquityEquity.TabIndex = 74;
            this.lblEquityEquity.Text = "Equity";
            // 
            // dgvEquityTransactions
            // 
            this.dgvEquityTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEquityTransactions.Location = new System.Drawing.Point(3, 122);
            this.dgvEquityTransactions.Name = "dgvEquityTransactions";
            this.dgvEquityTransactions.Size = new System.Drawing.Size(921, 475);
            this.dgvEquityTransactions.TabIndex = 86;
            this.dgvEquityTransactions.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvEquityTransactions_CellFormatting);
            // 
            // ctlEquityTransaction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvEquityTransactions);
            this.Controls.Add(this.grpTransactionEquities);
            this.Name = "ctlEquityTransaction";
            this.Size = new System.Drawing.Size(927, 597);
            this.grpTransactionEquities.ResumeLayout(false);
            this.grpTransactionEquities.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numEquityShares)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEquityTransactions)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpTransactionEquities;
        private System.Windows.Forms.ComboBox cmbTransactionEquity;
        private System.Windows.Forms.Label lblExchangeRate;
        private System.Windows.Forms.ComboBox cmbAccountEquity;
        private System.Windows.Forms.TextBox txtExchangeRate;
        private System.Windows.Forms.ComboBox cmbEquityEquity;
        private System.Windows.Forms.Label lblEquityTransactionDate;
        private System.Windows.Forms.Label lblShares;
        private System.Windows.Forms.DateTimePicker dtpTransactionDate;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Button btnTransactionSave;
        private System.Windows.Forms.Label lblCommission;
        private System.Windows.Forms.Label lblAccountTo;
        private System.Windows.Forms.NumericUpDown numEquityShares;
        private System.Windows.Forms.ComboBox cmbAccountTo;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label lblEquityTransaction;
        private System.Windows.Forms.TextBox txtCommission;
        private System.Windows.Forms.Label lblEquityAccount;
        private System.Windows.Forms.Label lblEquityEquity;
        private System.Windows.Forms.DataGridView dgvEquityTransactions;
    }
}
