namespace StockPortfolioApplication
{
    partial class ctlTransactions
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
            this.pnlTransactionDisplay = new System.Windows.Forms.Panel();
            this.cmbTransactionSelection = new System.Windows.Forms.ComboBox();
            this.lblTransactionType = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pnlTransactionDisplay
            // 
            this.pnlTransactionDisplay.Location = new System.Drawing.Point(0, 30);
            this.pnlTransactionDisplay.Name = "pnlTransactionDisplay";
            this.pnlTransactionDisplay.Size = new System.Drawing.Size(927, 597);
            this.pnlTransactionDisplay.TabIndex = 0;
            // 
            // cmbTransactionSelection
            // 
            this.cmbTransactionSelection.FormattingEnabled = true;
            this.cmbTransactionSelection.Location = new System.Drawing.Point(104, 5);
            this.cmbTransactionSelection.Name = "cmbTransactionSelection";
            this.cmbTransactionSelection.Size = new System.Drawing.Size(141, 21);
            this.cmbTransactionSelection.TabIndex = 1;
            // 
            // lblTransactionType
            // 
            this.lblTransactionType.AutoSize = true;
            this.lblTransactionType.Location = new System.Drawing.Point(4, 9);
            this.lblTransactionType.Name = "lblTransactionType";
            this.lblTransactionType.Size = new System.Drawing.Size(90, 13);
            this.lblTransactionType.TabIndex = 2;
            this.lblTransactionType.Text = "Transaction Type";
            // 
            // ctlTransactions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblTransactionType);
            this.Controls.Add(this.cmbTransactionSelection);
            this.Controls.Add(this.pnlTransactionDisplay);
            this.Name = "ctlTransactions";
            this.Size = new System.Drawing.Size(927, 627);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlTransactionDisplay;
        private System.Windows.Forms.ComboBox cmbTransactionSelection;
        private System.Windows.Forms.Label lblTransactionType;
    }
}
