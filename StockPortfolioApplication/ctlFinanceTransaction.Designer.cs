namespace StockPortfolioApplication
{
    partial class ctlFinanceTransaction
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
            this.dgvEquityTransactions = new System.Windows.Forms.DataGridView();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.grpFinancialTransactions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEquityTransactions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // grpFinancialTransactions
            // 
            this.grpFinancialTransactions.Controls.Add(this.dgvEquityTransactions);
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
            this.grpFinancialTransactions.Location = new System.Drawing.Point(0, 0);
            this.grpFinancialTransactions.Name = "grpFinancialTransactions";
            this.grpFinancialTransactions.Size = new System.Drawing.Size(750, 99);
            this.grpFinancialTransactions.TabIndex = 97;
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
            this.cmbFinancialAccountTo.TabStop = false;
            this.cmbFinancialAccountTo.Visible = false;
            // 
            // cmbFinancialCurrency
            // 
            this.cmbFinancialCurrency.FormattingEnabled = true;
            this.cmbFinancialCurrency.Location = new System.Drawing.Point(361, 43);
            this.cmbFinancialCurrency.Name = "cmbFinancialCurrency";
            this.cmbFinancialCurrency.Size = new System.Drawing.Size(70, 21);
            this.cmbFinancialCurrency.TabIndex = 5;
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
            this.btnFinancialSave.TabIndex = 6;
            this.btnFinancialSave.Text = "Save";
            this.btnFinancialSave.UseVisualStyleBackColor = true;
            // 
            // dtpFinancialTransaction
            // 
            this.dtpFinancialTransaction.Location = new System.Drawing.Point(8, 43);
            this.dtpFinancialTransaction.Name = "dtpFinancialTransaction";
            this.dtpFinancialTransaction.Size = new System.Drawing.Size(122, 20);
            this.dtpFinancialTransaction.TabIndex = 1;
            // 
            // cmbFinancialTransaction
            // 
            this.cmbFinancialTransaction.FormattingEnabled = true;
            this.cmbFinancialTransaction.Location = new System.Drawing.Point(136, 43);
            this.cmbFinancialTransaction.Name = "cmbFinancialTransaction";
            this.cmbFinancialTransaction.Size = new System.Drawing.Size(70, 21);
            this.cmbFinancialTransaction.TabIndex = 2;
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
            this.txtFincialNet.TabIndex = 4;
            // 
            // cmbFinancialAccount
            // 
            this.cmbFinancialAccount.FormattingEnabled = true;
            this.cmbFinancialAccount.Location = new System.Drawing.Point(212, 43);
            this.cmbFinancialAccount.Name = "cmbFinancialAccount";
            this.cmbFinancialAccount.Size = new System.Drawing.Size(70, 21);
            this.cmbFinancialAccount.TabIndex = 3;
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
            // dgvEquityTransactions
            // 
            this.dgvEquityTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEquityTransactions.Location = new System.Drawing.Point(3, 122);
            this.dgvEquityTransactions.Name = "dgvEquityTransactions";
            this.dgvEquityTransactions.Size = new System.Drawing.Size(921, 475);
            this.dgvEquityTransactions.TabIndex = 109;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(3, 121);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(921, 475);
            this.dataGridView1.TabIndex = 98;
            // 
            // ctlFinanceTransaction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.grpFinancialTransactions);
            this.Name = "ctlFinanceTransaction";
            this.Size = new System.Drawing.Size(927, 597);
            this.grpFinancialTransactions.ResumeLayout(false);
            this.grpFinancialTransactions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEquityTransactions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpFinancialTransactions;
        private System.Windows.Forms.Label lblFinancialAccountTo;
        private System.Windows.Forms.ComboBox cmbFinancialAccountTo;
        private System.Windows.Forms.ComboBox cmbFinancialCurrency;
        private System.Windows.Forms.Label lblCurrency;
        private System.Windows.Forms.Button btnFinancialSave;
        private System.Windows.Forms.DateTimePicker dtpFinancialTransaction;
        private System.Windows.Forms.ComboBox cmbFinancialTransaction;
        private System.Windows.Forms.Label lblFinancialNet;
        private System.Windows.Forms.TextBox txtFincialNet;
        private System.Windows.Forms.ComboBox cmbFinancialAccount;
        private System.Windows.Forms.Label lblFinancialDate;
        private System.Windows.Forms.Label lblFincialAccount;
        private System.Windows.Forms.Label lblFinancialTransaction;
        private System.Windows.Forms.DataGridView dgvEquityTransactions;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}
