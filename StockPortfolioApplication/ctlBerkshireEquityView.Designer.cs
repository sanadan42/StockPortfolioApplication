namespace StockPortfolioApplication
{
    partial class ctlBerkshireEquityView
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
            this.lblShares.Location = new System.Drawing.Point(204, 11);
            this.lblShares.Name = "lblShares";
            this.lblShares.Size = new System.Drawing.Size(40, 13);
            this.lblShares.TabIndex = 124;
            this.lblShares.Text = "Shares";
            this.lblShares.Visible = false;
            // 
            // lblCostCalculated
            // 
            this.lblCostCalculated.AutoSize = true;
            this.lblCostCalculated.Location = new System.Drawing.Point(270, 11);
            this.lblCostCalculated.Name = "lblCostCalculated";
            this.lblCostCalculated.Size = new System.Drawing.Size(28, 13);
            this.lblCostCalculated.TabIndex = 123;
            this.lblCostCalculated.Text = "Cost";
            this.lblCostCalculated.Visible = false;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(62, 11);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(60, 13);
            this.lblDescription.TabIndex = 122;
            this.lblDescription.Text = "Description";
            this.lblDescription.Visible = false;
            // 
            // lblTicker
            // 
            this.lblTicker.AutoSize = true;
            this.lblTicker.Location = new System.Drawing.Point(7, 11);
            this.lblTicker.Name = "lblTicker";
            this.lblTicker.Size = new System.Drawing.Size(37, 13);
            this.lblTicker.TabIndex = 121;
            this.lblTicker.Text = "Ticker";
            this.lblTicker.Visible = false;
            // 
            // lblValueCalculated
            // 
            this.lblValueCalculated.AutoSize = true;
            this.lblValueCalculated.Location = new System.Drawing.Point(326, 11);
            this.lblValueCalculated.Name = "lblValueCalculated";
            this.lblValueCalculated.Size = new System.Drawing.Size(34, 13);
            this.lblValueCalculated.TabIndex = 120;
            this.lblValueCalculated.Text = "Value";
            this.lblValueCalculated.Visible = false;
            // 
            // ctlBerkshireEquityView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblShares);
            this.Controls.Add(this.lblCostCalculated);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblTicker);
            this.Controls.Add(this.lblValueCalculated);
            this.Name = "ctlBerkshireEquityView";
            this.Size = new System.Drawing.Size(389, 37);
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
