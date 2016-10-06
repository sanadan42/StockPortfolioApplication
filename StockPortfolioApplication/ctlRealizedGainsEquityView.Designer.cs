namespace StockPortfolioApplication
{
    partial class ctlCapitalGainsEquityView
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
            this.lblShares = new System.Windows.Forms.Label();
            this.lblCostCalculated = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblTicker = new System.Windows.Forms.Label();
            this.lblValueCalculated = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblShares
            // 
            this.lblShares.AutoSize = true;
            this.lblShares.Location = new System.Drawing.Point(220, 3);
            this.lblShares.Name = "lblShares";
            this.lblShares.Size = new System.Drawing.Size(40, 13);
            this.lblShares.TabIndex = 124;
            this.lblShares.Text = "Shares";
            // 
            // lblCostCalculated
            // 
            this.lblCostCalculated.AutoSize = true;
            this.lblCostCalculated.Location = new System.Drawing.Point(300, 3);
            this.lblCostCalculated.Name = "lblCostCalculated";
            this.lblCostCalculated.Size = new System.Drawing.Size(28, 13);
            this.lblCostCalculated.TabIndex = 123;
            this.lblCostCalculated.Text = "Cost";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(58, 3);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(60, 13);
            this.lblDescription.TabIndex = 122;
            this.lblDescription.Text = "Description";
            // 
            // lblTicker
            // 
            this.lblTicker.AutoSize = true;
            this.lblTicker.Location = new System.Drawing.Point(3, 3);
            this.lblTicker.Name = "lblTicker";
            this.lblTicker.Size = new System.Drawing.Size(37, 13);
            this.lblTicker.TabIndex = 121;
            this.lblTicker.Text = "Ticker";
            // 
            // lblValueCalculated
            // 
            this.lblValueCalculated.AutoSize = true;
            this.lblValueCalculated.Location = new System.Drawing.Point(388, 3);
            this.lblValueCalculated.Name = "lblValueCalculated";
            this.lblValueCalculated.Size = new System.Drawing.Size(34, 13);
            this.lblValueCalculated.TabIndex = 120;
            this.lblValueCalculated.Text = "Value";
            // 
            // ctlCapitalGainsEquityView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblShares);
            this.Controls.Add(this.lblCostCalculated);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblTicker);
            this.Controls.Add(this.lblValueCalculated);
            this.Name = "ctlCapitalGainsEquityView";
            this.Size = new System.Drawing.Size(463, 19);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblShares;
        private System.Windows.Forms.Label lblCostCalculated;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblTicker;
        private System.Windows.Forms.Label lblValueCalculated;
        
    }
}
