namespace StockPortfolioApplication
{
    partial class MainForm
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
            this.pnlDisplay = new System.Windows.Forms.Panel();
            this.pnlNavigation = new System.Windows.Forms.Panel();
            this.btnTestNewTransaction = new System.Windows.Forms.Button();
            this.btnBerkshireTesting = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnEECAdd = new System.Windows.Forms.Button();
            this.btnDataGridDisplay = new System.Windows.Forms.Button();
            this.pnlNavigation.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlDisplay
            // 
            this.pnlDisplay.Location = new System.Drawing.Point(187, 12);
            this.pnlDisplay.Name = "pnlDisplay";
            this.pnlDisplay.Size = new System.Drawing.Size(927, 627);
            this.pnlDisplay.TabIndex = 0;
            // 
            // pnlNavigation
            // 
            this.pnlNavigation.Controls.Add(this.btnTestNewTransaction);
            this.pnlNavigation.Controls.Add(this.btnBerkshireTesting);
            this.pnlNavigation.Controls.Add(this.button1);
            this.pnlNavigation.Controls.Add(this.btnEECAdd);
            this.pnlNavigation.Controls.Add(this.btnDataGridDisplay);
            this.pnlNavigation.Location = new System.Drawing.Point(8, 12);
            this.pnlNavigation.Name = "pnlNavigation";
            this.pnlNavigation.Size = new System.Drawing.Size(179, 627);
            this.pnlNavigation.TabIndex = 1;
            // 
            // btnTestNewTransaction
            // 
            this.btnTestNewTransaction.Location = new System.Drawing.Point(15, 20);
            this.btnTestNewTransaction.Name = "btnTestNewTransaction";
            this.btnTestNewTransaction.Size = new System.Drawing.Size(149, 40);
            this.btnTestNewTransaction.TabIndex = 5;
            this.btnTestNewTransaction.Text = "New Transaction Entry";
            this.btnTestNewTransaction.UseVisualStyleBackColor = true;
            this.btnTestNewTransaction.Click += new System.EventHandler(this.btnTestNewTransaction_Click);
            // 
            // btnBerkshireTesting
            // 
            this.btnBerkshireTesting.Location = new System.Drawing.Point(15, 293);
            this.btnBerkshireTesting.Name = "btnBerkshireTesting";
            this.btnBerkshireTesting.Size = new System.Drawing.Size(149, 40);
            this.btnBerkshireTesting.TabIndex = 4;
            this.btnBerkshireTesting.Text = "Berkshire Format";
            this.btnBerkshireTesting.UseVisualStyleBackColor = true;
            this.btnBerkshireTesting.Click += new System.EventHandler(this.btnBerkshireTesting_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(14, 247);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(149, 40);
            this.button1.TabIndex = 3;
            this.button1.Text = "Testing";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnEECAdd
            // 
            this.btnEECAdd.Location = new System.Drawing.Point(14, 66);
            this.btnEECAdd.Name = "btnEECAdd";
            this.btnEECAdd.Size = new System.Drawing.Size(149, 40);
            this.btnEECAdd.TabIndex = 2;
            this.btnEECAdd.Text = "Equity / Exchance / Currency Entry";
            this.btnEECAdd.UseVisualStyleBackColor = true;
            this.btnEECAdd.Click += new System.EventHandler(this.btnEECAdd_Click);
            // 
            // btnDataGridDisplay
            // 
            this.btnDataGridDisplay.Location = new System.Drawing.Point(15, 112);
            this.btnDataGridDisplay.Name = "btnDataGridDisplay";
            this.btnDataGridDisplay.Size = new System.Drawing.Size(149, 40);
            this.btnDataGridDisplay.TabIndex = 1;
            this.btnDataGridDisplay.Text = "Equity Update";
            this.btnDataGridDisplay.UseVisualStyleBackColor = true;
            this.btnDataGridDisplay.Click += new System.EventHandler(this.btnDataGridDisplay_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1126, 651);
            this.Controls.Add(this.pnlNavigation);
            this.Controls.Add(this.pnlDisplay);
            this.Name = "MainForm";
            this.Text = "Stock Portfolio";
            this.pnlNavigation.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlDisplay;
        private System.Windows.Forms.Panel pnlNavigation;
        private System.Windows.Forms.Button btnEECAdd;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnBerkshireTesting;
        private System.Windows.Forms.Button btnDataGridDisplay;
        private System.Windows.Forms.Button btnTestNewTransaction;
    }
}

