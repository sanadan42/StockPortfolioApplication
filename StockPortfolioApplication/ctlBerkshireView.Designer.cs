namespace StockPortfolioApplication
{
    partial class ctlBerkshireView
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
            this.pnlBerkshireEquityView = new System.Windows.Forms.Panel();
            this.pnlBerkshireSummary = new System.Windows.Forms.Panel();
            this.lblCostTotal = new System.Windows.Forms.Label();
            this.lblValueTotal = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pnlBerkshireEquityView
            // 
            this.pnlBerkshireEquityView.Location = new System.Drawing.Point(0, 0);
            this.pnlBerkshireEquityView.Name = "pnlBerkshireEquityView";
            this.pnlBerkshireEquityView.Size = new System.Drawing.Size(926, 314);
            this.pnlBerkshireEquityView.TabIndex = 0;
            // 
            // pnlBerkshireSummary
            // 
            this.pnlBerkshireSummary.Location = new System.Drawing.Point(311, 469);
            this.pnlBerkshireSummary.Name = "pnlBerkshireSummary";
            this.pnlBerkshireSummary.Size = new System.Drawing.Size(613, 116);
            this.pnlBerkshireSummary.TabIndex = 1;
            // 
            // lblCostTotal
            // 
            this.lblCostTotal.AutoSize = true;
            this.lblCostTotal.Location = new System.Drawing.Point(422, 367);
            this.lblCostTotal.Name = "lblCostTotal";
            this.lblCostTotal.Size = new System.Drawing.Size(55, 13);
            this.lblCostTotal.TabIndex = 2;
            this.lblCostTotal.Text = "Cost Total";
            // 
            // lblValueTotal
            // 
            this.lblValueTotal.AutoSize = true;
            this.lblValueTotal.Location = new System.Drawing.Point(483, 367);
            this.lblValueTotal.Name = "lblValueTotal";
            this.lblValueTotal.Size = new System.Drawing.Size(61, 13);
            this.lblValueTotal.TabIndex = 3;
            this.lblValueTotal.Text = "Value Total";
            // 
            // ctlBerkshireView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblValueTotal);
            this.Controls.Add(this.lblCostTotal);
            this.Controls.Add(this.pnlBerkshireSummary);
            this.Controls.Add(this.pnlBerkshireEquityView);
            this.Name = "ctlBerkshireView";
            this.Size = new System.Drawing.Size(927, 627);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ctlBerkshireView_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlBerkshireEquityView;
        private System.Windows.Forms.Panel pnlBerkshireSummary;
        private System.Windows.Forms.Label lblCostTotal;
        private System.Windows.Forms.Label lblValueTotal;
    }
}
