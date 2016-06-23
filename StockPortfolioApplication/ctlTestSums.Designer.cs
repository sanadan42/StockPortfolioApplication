namespace StockPortfolioApplication
{
    partial class ctlTestSums
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
            this.btnGetAccount = new System.Windows.Forms.Button();
            this.dgSumShares = new System.Windows.Forms.DataGridView();
            this.cmbAccount = new System.Windows.Forms.ComboBox();
            this.lblFincialAccount = new System.Windows.Forms.Label();
            this.lblRealized = new System.Windows.Forms.Label();
            this.lblUnrealized = new System.Windows.Forms.Label();
            this.lblDividend = new System.Windows.Forms.Label();
            this.lblCost = new System.Windows.Forms.Label();
            this.lblPL = new System.Windows.Forms.Label();
            this.lblPLCalculated = new System.Windows.Forms.Label();
            this.lblCostCalculated = new System.Windows.Forms.Label();
            this.lblDividendCalculated = new System.Windows.Forms.Label();
            this.lblUnrealizedCalculated = new System.Windows.Forms.Label();
            this.lblRealizedCalculated = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnGetAllEquities = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgSumShares)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGetAccount
            // 
            this.btnGetAccount.Location = new System.Drawing.Point(94, 512);
            this.btnGetAccount.Name = "btnGetAccount";
            this.btnGetAccount.Size = new System.Drawing.Size(99, 35);
            this.btnGetAccount.TabIndex = 11;
            this.btnGetAccount.Text = "Get Account";
            this.btnGetAccount.UseVisualStyleBackColor = true;
            this.btnGetAccount.Click += new System.EventHandler(this.btnGetAccountEquites_Click);
            // 
            // dgSumShares
            // 
            this.dgSumShares.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgSumShares.Location = new System.Drawing.Point(3, 3);
            this.dgSumShares.Name = "dgSumShares";
            this.dgSumShares.Size = new System.Drawing.Size(873, 475);
            this.dgSumShares.TabIndex = 10;
            // 
            // cmbAccount
            // 
            this.cmbAccount.FormattingEnabled = true;
            this.cmbAccount.Location = new System.Drawing.Point(6, 526);
            this.cmbAccount.Name = "cmbAccount";
            this.cmbAccount.Size = new System.Drawing.Size(70, 21);
            this.cmbAccount.TabIndex = 102;
            // 
            // lblFincialAccount
            // 
            this.lblFincialAccount.AutoSize = true;
            this.lblFincialAccount.Location = new System.Drawing.Point(20, 508);
            this.lblFincialAccount.Name = "lblFincialAccount";
            this.lblFincialAccount.Size = new System.Drawing.Size(47, 13);
            this.lblFincialAccount.TabIndex = 103;
            this.lblFincialAccount.Text = "Account";
            // 
            // lblRealized
            // 
            this.lblRealized.AutoSize = true;
            this.lblRealized.Location = new System.Drawing.Point(417, 508);
            this.lblRealized.Name = "lblRealized";
            this.lblRealized.Size = new System.Drawing.Size(48, 13);
            this.lblRealized.TabIndex = 105;
            this.lblRealized.Text = "Realized";
            // 
            // lblUnrealized
            // 
            this.lblUnrealized.AutoSize = true;
            this.lblUnrealized.Location = new System.Drawing.Point(510, 508);
            this.lblUnrealized.Name = "lblUnrealized";
            this.lblUnrealized.Size = new System.Drawing.Size(57, 13);
            this.lblUnrealized.TabIndex = 106;
            this.lblUnrealized.Text = "Unrealized";
            // 
            // lblDividend
            // 
            this.lblDividend.AutoSize = true;
            this.lblDividend.Location = new System.Drawing.Point(599, 508);
            this.lblDividend.Name = "lblDividend";
            this.lblDividend.Size = new System.Drawing.Size(49, 13);
            this.lblDividend.TabIndex = 107;
            this.lblDividend.Text = "Dividend";
            // 
            // lblCost
            // 
            this.lblCost.AutoSize = true;
            this.lblCost.Location = new System.Drawing.Point(339, 508);
            this.lblCost.Name = "lblCost";
            this.lblCost.Size = new System.Drawing.Size(28, 13);
            this.lblCost.TabIndex = 108;
            this.lblCost.Text = "Cost";
            // 
            // lblPL
            // 
            this.lblPL.AutoSize = true;
            this.lblPL.Location = new System.Drawing.Point(685, 508);
            this.lblPL.Name = "lblPL";
            this.lblPL.Size = new System.Drawing.Size(20, 13);
            this.lblPL.TabIndex = 109;
            this.lblPL.Text = "PL";
            // 
            // lblPLCalculated
            // 
            this.lblPLCalculated.AutoSize = true;
            this.lblPLCalculated.Location = new System.Drawing.Point(685, 529);
            this.lblPLCalculated.Name = "lblPLCalculated";
            this.lblPLCalculated.Size = new System.Drawing.Size(20, 13);
            this.lblPLCalculated.TabIndex = 114;
            this.lblPLCalculated.Text = "PL";
            this.lblPLCalculated.Visible = false;
            // 
            // lblCostCalculated
            // 
            this.lblCostCalculated.AutoSize = true;
            this.lblCostCalculated.Location = new System.Drawing.Point(339, 529);
            this.lblCostCalculated.Name = "lblCostCalculated";
            this.lblCostCalculated.Size = new System.Drawing.Size(28, 13);
            this.lblCostCalculated.TabIndex = 113;
            this.lblCostCalculated.Text = "Cost";
            this.lblCostCalculated.Visible = false;
            // 
            // lblDividendCalculated
            // 
            this.lblDividendCalculated.AutoSize = true;
            this.lblDividendCalculated.Location = new System.Drawing.Point(599, 529);
            this.lblDividendCalculated.Name = "lblDividendCalculated";
            this.lblDividendCalculated.Size = new System.Drawing.Size(49, 13);
            this.lblDividendCalculated.TabIndex = 112;
            this.lblDividendCalculated.Text = "Dividend";
            this.lblDividendCalculated.Visible = false;
            // 
            // lblUnrealizedCalculated
            // 
            this.lblUnrealizedCalculated.AutoSize = true;
            this.lblUnrealizedCalculated.Location = new System.Drawing.Point(510, 529);
            this.lblUnrealizedCalculated.Name = "lblUnrealizedCalculated";
            this.lblUnrealizedCalculated.Size = new System.Drawing.Size(57, 13);
            this.lblUnrealizedCalculated.TabIndex = 111;
            this.lblUnrealizedCalculated.Text = "Unrealized";
            this.lblUnrealizedCalculated.Visible = false;
            // 
            // lblRealizedCalculated
            // 
            this.lblRealizedCalculated.AutoSize = true;
            this.lblRealizedCalculated.Location = new System.Drawing.Point(417, 529);
            this.lblRealizedCalculated.Name = "lblRealizedCalculated";
            this.lblRealizedCalculated.Size = new System.Drawing.Size(48, 13);
            this.lblRealizedCalculated.TabIndex = 110;
            this.lblRealizedCalculated.Text = "Realized";
            this.lblRealizedCalculated.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(94, 553);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 35);
            this.button1.TabIndex = 115;
            this.button1.Text = "Get Stock Prices";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnGetAllEquities
            // 
            this.btnGetAllEquities.Location = new System.Drawing.Point(210, 512);
            this.btnGetAllEquities.Name = "btnGetAllEquities";
            this.btnGetAllEquities.Size = new System.Drawing.Size(99, 35);
            this.btnGetAllEquities.TabIndex = 104;
            this.btnGetAllEquities.Text = "Get All Equities";
            this.btnGetAllEquities.UseVisualStyleBackColor = true;
            this.btnGetAllEquities.Click += new System.EventHandler(this.btnGetAllEquities_Click);
            // 
            // ctlTestSums
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblPLCalculated);
            this.Controls.Add(this.lblCostCalculated);
            this.Controls.Add(this.lblDividendCalculated);
            this.Controls.Add(this.lblUnrealizedCalculated);
            this.Controls.Add(this.lblRealizedCalculated);
            this.Controls.Add(this.lblPL);
            this.Controls.Add(this.lblCost);
            this.Controls.Add(this.lblDividend);
            this.Controls.Add(this.lblUnrealized);
            this.Controls.Add(this.lblRealized);
            this.Controls.Add(this.btnGetAllEquities);
            this.Controls.Add(this.cmbAccount);
            this.Controls.Add(this.lblFincialAccount);
            this.Controls.Add(this.btnGetAccount);
            this.Controls.Add(this.dgSumShares);
            this.Name = "ctlTestSums";
            this.Size = new System.Drawing.Size(879, 645);
            ((System.ComponentModel.ISupportInitialize)(this.dgSumShares)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGetAccount;
        private System.Windows.Forms.DataGridView dgSumShares;
        private System.Windows.Forms.ComboBox cmbAccount;
        private System.Windows.Forms.Label lblFincialAccount;
        private System.Windows.Forms.Label lblRealized;
        private System.Windows.Forms.Label lblUnrealized;
        private System.Windows.Forms.Label lblDividend;
        private System.Windows.Forms.Label lblCost;
        private System.Windows.Forms.Label lblPL;
        private System.Windows.Forms.Label lblPLCalculated;
        private System.Windows.Forms.Label lblCostCalculated;
        private System.Windows.Forms.Label lblDividendCalculated;
        private System.Windows.Forms.Label lblUnrealizedCalculated;
        private System.Windows.Forms.Label lblRealizedCalculated;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnGetAllEquities;
    }
}
