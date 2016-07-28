namespace StockPortfolioApplication
{
    partial class ctlStockTransaction
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
            this.lblAccountTo = new System.Windows.Forms.Label();
            this.cmbAccountTo = new System.Windows.Forms.ComboBox();
            this.lblEquityTransaction = new System.Windows.Forms.Label();
            this.lblEquityAccount = new System.Windows.Forms.Label();
            this.lblEquityEquity = new System.Windows.Forms.Label();
            this.txtCommission = new System.Windows.Forms.TextBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.numEquityShares = new System.Windows.Forms.NumericUpDown();
            this.lblCommission = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblShares = new System.Windows.Forms.Label();
            this.cmbTransactionEquity = new System.Windows.Forms.ComboBox();
            this.cmbEquityEquity = new System.Windows.Forms.ComboBox();
            this.cmbAccountEquity = new System.Windows.Forms.ComboBox();
            this.btnTransactionSave = new System.Windows.Forms.Button();
            this.dtpTransactionDate = new System.Windows.Forms.DateTimePicker();
            this.lblEquityTransactionDate = new System.Windows.Forms.Label();
            this.grpTransactionEquities = new System.Windows.Forms.GroupBox();
            this.cmbDividendAccount = new System.Windows.Forms.ComboBox();
            this.cmbDividendEquity = new System.Windows.Forms.ComboBox();
            this.lblDividendDate = new System.Windows.Forms.Label();
            this.dtpDividend = new System.Windows.Forms.DateTimePicker();
            this.lblDividendValue = new System.Windows.Forms.Label();
            this.txtDividend = new System.Windows.Forms.TextBox();
            this.lblDividendAccount = new System.Windows.Forms.Label();
            this.lblDividendEquity = new System.Windows.Forms.Label();
            this.grpDividendTransactions = new System.Windows.Forms.GroupBox();
            this.btnDividendSave = new System.Windows.Forms.Button();
            this.grpFinancialTransactions = new System.Windows.Forms.GroupBox();
            this.lblFinancialAccountTo = new System.Windows.Forms.Label();
            this.cmbFinancialAccountTo = new System.Windows.Forms.ComboBox();
            this.cmbFinancialCurrency = new System.Windows.Forms.ComboBox();
            this.lblCurrency = new System.Windows.Forms.Label();
            this.btnFinancialSave = new System.Windows.Forms.Button();
            this.dtpFinancialTransaction = new System.Windows.Forms.DateTimePicker();
            this.cmbFinancialTransaction = new System.Windows.Forms.ComboBox();
            this.lblFinancialNet = new System.Windows.Forms.Label();
            this.txtFincialNet = new System.Windows.Forms.TextBox();
            this.cmbFinancialAccount = new System.Windows.Forms.ComboBox();
            this.lblFinancialDate = new System.Windows.Forms.Label();
            this.lblFincialAccount = new System.Windows.Forms.Label();
            this.lblFinancialTransaction = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numEquityShares)).BeginInit();
            this.grpTransactionEquities.SuspendLayout();
            this.grpDividendTransactions.SuspendLayout();
            this.grpFinancialTransactions.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblAccountTo
            // 
            this.lblAccountTo.AutoSize = true;
            this.lblAccountTo.Location = new System.Drawing.Point(191, 78);
            this.lblAccountTo.Name = "lblAccountTo";
            this.lblAccountTo.Size = new System.Drawing.Size(20, 13);
            this.lblAccountTo.TabIndex = 78;
            this.lblAccountTo.Text = "To";
            this.lblAccountTo.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblAccountTo.Visible = false;
            // 
            // cmbAccountTo
            // 
            this.cmbAccountTo.FormattingEnabled = true;
            this.cmbAccountTo.Location = new System.Drawing.Point(217, 75);
            this.cmbAccountTo.Name = "cmbAccountTo";
            this.cmbAccountTo.Size = new System.Drawing.Size(70, 21);
            this.cmbAccountTo.TabIndex = 77;
            this.cmbAccountTo.Visible = false;
            // 
            // lblEquityTransaction
            // 
            this.lblEquityTransaction.AutoSize = true;
            this.lblEquityTransaction.Location = new System.Drawing.Point(145, 31);
            this.lblEquityTransaction.Name = "lblEquityTransaction";
            this.lblEquityTransaction.Size = new System.Drawing.Size(63, 13);
            this.lblEquityTransaction.TabIndex = 76;
            this.lblEquityTransaction.Text = "Transaction";
            // 
            // lblEquityAccount
            // 
            this.lblEquityAccount.AutoSize = true;
            this.lblEquityAccount.Location = new System.Drawing.Point(231, 31);
            this.lblEquityAccount.Name = "lblEquityAccount";
            this.lblEquityAccount.Size = new System.Drawing.Size(47, 13);
            this.lblEquityAccount.TabIndex = 75;
            this.lblEquityAccount.Text = "Account";
            // 
            // lblEquityEquity
            // 
            this.lblEquityEquity.AutoSize = true;
            this.lblEquityEquity.Location = new System.Drawing.Point(306, 31);
            this.lblEquityEquity.Name = "lblEquityEquity";
            this.lblEquityEquity.Size = new System.Drawing.Size(36, 13);
            this.lblEquityEquity.TabIndex = 74;
            this.lblEquityEquity.Text = "Equity";
            // 
            // txtCommission
            // 
            this.txtCommission.Location = new System.Drawing.Point(503, 50);
            this.txtCommission.Name = "txtCommission";
            this.txtCommission.Size = new System.Drawing.Size(59, 20);
            this.txtCommission.TabIndex = 73;
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(434, 50);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(59, 20);
            this.txtPrice.TabIndex = 72;
            // 
            // numEquityShares
            // 
            this.numEquityShares.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numEquityShares.Location = new System.Drawing.Point(372, 50);
            this.numEquityShares.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numEquityShares.Name = "numEquityShares";
            this.numEquityShares.Size = new System.Drawing.Size(54, 20);
            this.numEquityShares.TabIndex = 71;
            // 
            // lblCommission
            // 
            this.lblCommission.AutoSize = true;
            this.lblCommission.Location = new System.Drawing.Point(501, 31);
            this.lblCommission.Name = "lblCommission";
            this.lblCommission.Size = new System.Drawing.Size(62, 13);
            this.lblCommission.TabIndex = 70;
            this.lblCommission.Text = "Commission";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(450, 31);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(31, 13);
            this.lblPrice.TabIndex = 69;
            this.lblPrice.Text = "Price";
            // 
            // lblShares
            // 
            this.lblShares.AutoSize = true;
            this.lblShares.Location = new System.Drawing.Point(377, 31);
            this.lblShares.Name = "lblShares";
            this.lblShares.Size = new System.Drawing.Size(40, 13);
            this.lblShares.TabIndex = 68;
            this.lblShares.Text = "Shares";
            // 
            // cmbTransactionEquity
            // 
            this.cmbTransactionEquity.FormattingEnabled = true;
            this.cmbTransactionEquity.Location = new System.Drawing.Point(141, 50);
            this.cmbTransactionEquity.Name = "cmbTransactionEquity";
            this.cmbTransactionEquity.Size = new System.Drawing.Size(70, 21);
            this.cmbTransactionEquity.TabIndex = 67;
            this.cmbTransactionEquity.SelectedIndexChanged += new System.EventHandler(this.cmbTransaction_Change);
            // 
            // cmbEquityEquity
            // 
            this.cmbEquityEquity.FormattingEnabled = true;
            this.cmbEquityEquity.Location = new System.Drawing.Point(293, 50);
            this.cmbEquityEquity.Name = "cmbEquityEquity";
            this.cmbEquityEquity.Size = new System.Drawing.Size(70, 21);
            this.cmbEquityEquity.TabIndex = 66;
            // 
            // cmbAccountEquity
            // 
            this.cmbAccountEquity.FormattingEnabled = true;
            this.cmbAccountEquity.Location = new System.Drawing.Point(217, 50);
            this.cmbAccountEquity.Name = "cmbAccountEquity";
            this.cmbAccountEquity.Size = new System.Drawing.Size(70, 21);
            this.cmbAccountEquity.TabIndex = 65;
            // 
            // btnTransactionSave
            // 
            this.btnTransactionSave.Location = new System.Drawing.Point(655, 50);
            this.btnTransactionSave.Name = "btnTransactionSave";
            this.btnTransactionSave.Size = new System.Drawing.Size(79, 21);
            this.btnTransactionSave.TabIndex = 79;
            this.btnTransactionSave.Text = "Save";
            this.btnTransactionSave.UseVisualStyleBackColor = true;
            this.btnTransactionSave.Click += new System.EventHandler(this.btnTransactionSave_Click);
            // 
            // dtpTransactionDate
            // 
            this.dtpTransactionDate.Location = new System.Drawing.Point(13, 50);
            this.dtpTransactionDate.Name = "dtpTransactionDate";
            this.dtpTransactionDate.Size = new System.Drawing.Size(122, 20);
            this.dtpTransactionDate.TabIndex = 80;
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
            // grpTransactionEquities
            // 
            this.grpTransactionEquities.Controls.Add(this.cmbTransactionEquity);
            this.grpTransactionEquities.Controls.Add(this.cmbAccountEquity);
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
            this.grpTransactionEquities.Location = new System.Drawing.Point(3, 3);
            this.grpTransactionEquities.Name = "grpTransactionEquities";
            this.grpTransactionEquities.Size = new System.Drawing.Size(750, 109);
            this.grpTransactionEquities.TabIndex = 84;
            this.grpTransactionEquities.TabStop = false;
            this.grpTransactionEquities.Text = "Equity Transactions";
            // 
            // cmbDividendAccount
            // 
            this.cmbDividendAccount.FormattingEnabled = true;
            this.cmbDividendAccount.Location = new System.Drawing.Point(139, 43);
            this.cmbDividendAccount.Name = "cmbDividendAccount";
            this.cmbDividendAccount.Size = new System.Drawing.Size(70, 21);
            this.cmbDividendAccount.TabIndex = 85;
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
            // dtpDividend
            // 
            this.dtpDividend.Location = new System.Drawing.Point(11, 43);
            this.dtpDividend.Name = "dtpDividend";
            this.dtpDividend.Size = new System.Drawing.Size(122, 20);
            this.dtpDividend.TabIndex = 93;
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
            // txtDividend
            // 
            this.txtDividend.Location = new System.Drawing.Point(293, 44);
            this.txtDividend.Name = "txtDividend";
            this.txtDividend.Size = new System.Drawing.Size(59, 20);
            this.txtDividend.TabIndex = 89;
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
            // lblDividendEquity
            // 
            this.lblDividendEquity.AutoSize = true;
            this.lblDividendEquity.Location = new System.Drawing.Point(228, 24);
            this.lblDividendEquity.Name = "lblDividendEquity";
            this.lblDividendEquity.Size = new System.Drawing.Size(36, 13);
            this.lblDividendEquity.TabIndex = 90;
            this.lblDividendEquity.Text = "Equity";
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
            this.grpDividendTransactions.Location = new System.Drawing.Point(3, 118);
            this.grpDividendTransactions.Name = "grpDividendTransactions";
            this.grpDividendTransactions.Size = new System.Drawing.Size(750, 109);
            this.grpDividendTransactions.TabIndex = 95;
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
            // grpFinancialTransactions
            // 
            this.grpFinancialTransactions.Controls.Add(this.lblFinancialAccountTo);
            this.grpFinancialTransactions.Controls.Add(this.cmbFinancialAccountTo);
            this.grpFinancialTransactions.Controls.Add(this.cmbFinancialCurrency);
            this.grpFinancialTransactions.Controls.Add(this.lblCurrency);
            this.grpFinancialTransactions.Controls.Add(this.btnFinancialSave);
            this.grpFinancialTransactions.Controls.Add(this.dtpFinancialTransaction);
            this.grpFinancialTransactions.Controls.Add(this.cmbFinancialTransaction);
            this.grpFinancialTransactions.Controls.Add(this.lblFinancialNet);
            this.grpFinancialTransactions.Controls.Add(this.txtFincialNet);
            this.grpFinancialTransactions.Controls.Add(this.cmbFinancialAccount);
            this.grpFinancialTransactions.Controls.Add(this.lblFinancialDate);
            this.grpFinancialTransactions.Controls.Add(this.lblFincialAccount);
            this.grpFinancialTransactions.Controls.Add(this.lblFinancialTransaction);
            this.grpFinancialTransactions.Location = new System.Drawing.Point(3, 233);
            this.grpFinancialTransactions.Name = "grpFinancialTransactions";
            this.grpFinancialTransactions.Size = new System.Drawing.Size(750, 99);
            this.grpFinancialTransactions.TabIndex = 96;
            this.grpFinancialTransactions.TabStop = false;
            this.grpFinancialTransactions.Text = "Financial Transactions";
            // 
            // lblFinancialAccountTo
            // 
            this.lblFinancialAccountTo.AutoSize = true;
            this.lblFinancialAccountTo.Location = new System.Drawing.Point(186, 73);
            this.lblFinancialAccountTo.Name = "lblFinancialAccountTo";
            this.lblFinancialAccountTo.Size = new System.Drawing.Size(20, 13);
            this.lblFinancialAccountTo.TabIndex = 108;
            this.lblFinancialAccountTo.Text = "To";
            this.lblFinancialAccountTo.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblFinancialAccountTo.Visible = false;
            // 
            // cmbFinancialAccountTo
            // 
            this.cmbFinancialAccountTo.FormattingEnabled = true;
            this.cmbFinancialAccountTo.Location = new System.Drawing.Point(212, 70);
            this.cmbFinancialAccountTo.Name = "cmbFinancialAccountTo";
            this.cmbFinancialAccountTo.Size = new System.Drawing.Size(70, 21);
            this.cmbFinancialAccountTo.TabIndex = 107;
            this.cmbFinancialAccountTo.Visible = false;
            // 
            // cmbFinancialCurrency
            // 
            this.cmbFinancialCurrency.FormattingEnabled = true;
            this.cmbFinancialCurrency.Location = new System.Drawing.Point(361, 43);
            this.cmbFinancialCurrency.Name = "cmbFinancialCurrency";
            this.cmbFinancialCurrency.Size = new System.Drawing.Size(70, 21);
            this.cmbFinancialCurrency.TabIndex = 105;
            // 
            // lblCurrency
            // 
            this.lblCurrency.AutoSize = true;
            this.lblCurrency.Location = new System.Drawing.Point(375, 24);
            this.lblCurrency.Name = "lblCurrency";
            this.lblCurrency.Size = new System.Drawing.Size(49, 13);
            this.lblCurrency.TabIndex = 106;
            this.lblCurrency.Text = "Currency";
            // 
            // btnFinancialSave
            // 
            this.btnFinancialSave.Location = new System.Drawing.Point(437, 43);
            this.btnFinancialSave.Name = "btnFinancialSave";
            this.btnFinancialSave.Size = new System.Drawing.Size(79, 21);
            this.btnFinancialSave.TabIndex = 98;
            this.btnFinancialSave.Text = "Save";
            this.btnFinancialSave.UseVisualStyleBackColor = true;
            this.btnFinancialSave.Click += new System.EventHandler(this.btnFinancialSave_Click);
            // 
            // dtpFinancialTransaction
            // 
            this.dtpFinancialTransaction.Location = new System.Drawing.Point(8, 43);
            this.dtpFinancialTransaction.Name = "dtpFinancialTransaction";
            this.dtpFinancialTransaction.Size = new System.Drawing.Size(122, 20);
            this.dtpFinancialTransaction.TabIndex = 103;
            // 
            // cmbFinancialTransaction
            // 
            this.cmbFinancialTransaction.FormattingEnabled = true;
            this.cmbFinancialTransaction.Location = new System.Drawing.Point(136, 43);
            this.cmbFinancialTransaction.Name = "cmbFinancialTransaction";
            this.cmbFinancialTransaction.Size = new System.Drawing.Size(70, 21);
            this.cmbFinancialTransaction.TabIndex = 97;
            this.cmbFinancialTransaction.SelectedIndexChanged += new System.EventHandler(this.cmbFinancialTransaction_SelectedIndexChanged);
            // 
            // lblFinancialNet
            // 
            this.lblFinancialNet.AutoSize = true;
            this.lblFinancialNet.Location = new System.Drawing.Point(310, 25);
            this.lblFinancialNet.Name = "lblFinancialNet";
            this.lblFinancialNet.Size = new System.Drawing.Size(24, 13);
            this.lblFinancialNet.TabIndex = 98;
            this.lblFinancialNet.Text = "Net";
            // 
            // txtFincialNet
            // 
            this.txtFincialNet.Location = new System.Drawing.Point(293, 43);
            this.txtFincialNet.Name = "txtFincialNet";
            this.txtFincialNet.Size = new System.Drawing.Size(59, 20);
            this.txtFincialNet.TabIndex = 99;
            // 
            // cmbFinancialAccount
            // 
            this.cmbFinancialAccount.FormattingEnabled = true;
            this.cmbFinancialAccount.Location = new System.Drawing.Point(212, 43);
            this.cmbFinancialAccount.Name = "cmbFinancialAccount";
            this.cmbFinancialAccount.Size = new System.Drawing.Size(70, 21);
            this.cmbFinancialAccount.TabIndex = 95;
            // 
            // lblFinancialDate
            // 
            this.lblFinancialDate.AutoSize = true;
            this.lblFinancialDate.Location = new System.Drawing.Point(54, 25);
            this.lblFinancialDate.Name = "lblFinancialDate";
            this.lblFinancialDate.Size = new System.Drawing.Size(30, 13);
            this.lblFinancialDate.TabIndex = 104;
            this.lblFinancialDate.Text = "Date";
            // 
            // lblFincialAccount
            // 
            this.lblFincialAccount.AutoSize = true;
            this.lblFincialAccount.Location = new System.Drawing.Point(226, 25);
            this.lblFincialAccount.Name = "lblFincialAccount";
            this.lblFincialAccount.Size = new System.Drawing.Size(47, 13);
            this.lblFincialAccount.TabIndex = 101;
            this.lblFincialAccount.Text = "Account";
            // 
            // lblFinancialTransaction
            // 
            this.lblFinancialTransaction.AutoSize = true;
            this.lblFinancialTransaction.Location = new System.Drawing.Point(140, 25);
            this.lblFinancialTransaction.Name = "lblFinancialTransaction";
            this.lblFinancialTransaction.Size = new System.Drawing.Size(63, 13);
            this.lblFinancialTransaction.TabIndex = 102;
            this.lblFinancialTransaction.Text = "Transaction";
            // 
            // ctlStockTransaction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpFinancialTransactions);
            this.Controls.Add(this.grpDividendTransactions);
            this.Controls.Add(this.grpTransactionEquities);
            this.Name = "ctlStockTransaction";
            this.Size = new System.Drawing.Size(970, 368);
            ((System.ComponentModel.ISupportInitialize)(this.numEquityShares)).EndInit();
            this.grpTransactionEquities.ResumeLayout(false);
            this.grpTransactionEquities.PerformLayout();
            this.grpDividendTransactions.ResumeLayout(false);
            this.grpDividendTransactions.PerformLayout();
            this.grpFinancialTransactions.ResumeLayout(false);
            this.grpFinancialTransactions.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblAccountTo;
        private System.Windows.Forms.ComboBox cmbAccountTo;
        private System.Windows.Forms.Label lblEquityTransaction;
        private System.Windows.Forms.Label lblEquityAccount;
        private System.Windows.Forms.Label lblEquityEquity;
        private System.Windows.Forms.TextBox txtCommission;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.NumericUpDown numEquityShares;
        private System.Windows.Forms.Label lblCommission;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblShares;
        private System.Windows.Forms.ComboBox cmbTransactionEquity;
        private System.Windows.Forms.ComboBox cmbEquityEquity;
        private System.Windows.Forms.ComboBox cmbAccountEquity;
        private System.Windows.Forms.Button btnTransactionSave;
        private System.Windows.Forms.DateTimePicker dtpTransactionDate;
        private System.Windows.Forms.Label lblEquityTransactionDate;
        private System.Windows.Forms.GroupBox grpTransactionEquities;
        private System.Windows.Forms.ComboBox cmbDividendAccount;
        private System.Windows.Forms.ComboBox cmbDividendEquity;
        private System.Windows.Forms.Label lblDividendDate;
        private System.Windows.Forms.DateTimePicker dtpDividend;
        private System.Windows.Forms.Label lblDividendValue;
        private System.Windows.Forms.TextBox txtDividend;
        private System.Windows.Forms.Label lblDividendAccount;
        private System.Windows.Forms.Label lblDividendEquity;
        private System.Windows.Forms.GroupBox grpDividendTransactions;
        private System.Windows.Forms.GroupBox grpFinancialTransactions;
        private System.Windows.Forms.DateTimePicker dtpFinancialTransaction;
        private System.Windows.Forms.ComboBox cmbFinancialTransaction;
        private System.Windows.Forms.Label lblFinancialNet;
        private System.Windows.Forms.TextBox txtFincialNet;
        private System.Windows.Forms.ComboBox cmbFinancialAccount;
        private System.Windows.Forms.Label lblFinancialDate;
        private System.Windows.Forms.Label lblFincialAccount;
        private System.Windows.Forms.Label lblFinancialTransaction;
        private System.Windows.Forms.Button btnDividendSave;
        private System.Windows.Forms.Button btnFinancialSave;
        private System.Windows.Forms.ComboBox cmbFinancialCurrency;
        private System.Windows.Forms.Label lblCurrency;
        private System.Windows.Forms.Label lblFinancialAccountTo;
        private System.Windows.Forms.ComboBox cmbFinancialAccountTo;
    }
}
