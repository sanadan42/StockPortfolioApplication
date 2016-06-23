namespace StockPortfolioApplication
{
    partial class ctlEquities
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
            this.dgEquities = new System.Windows.Forms.DataGridView();
            this.btnDGUpdate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgEquities)).BeginInit();
            this.SuspendLayout();
            // 
            // dgEquities
            // 
            this.dgEquities.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgEquities.Location = new System.Drawing.Point(3, 3);
            this.dgEquities.Name = "dgEquities";
            this.dgEquities.Size = new System.Drawing.Size(681, 475);
            this.dgEquities.TabIndex = 6;
            // 
            // btnDGUpdate
            // 
            this.btnDGUpdate.Location = new System.Drawing.Point(302, 484);
            this.btnDGUpdate.Name = "btnDGUpdate";
            this.btnDGUpdate.Size = new System.Drawing.Size(99, 35);
            this.btnDGUpdate.TabIndex = 9;
            this.btnDGUpdate.Text = "Update";
            this.btnDGUpdate.UseVisualStyleBackColor = true;
            this.btnDGUpdate.Click += new System.EventHandler(this.btnDGUpdate_Click);
            // 
            // ctlEquities
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnDGUpdate);
            this.Controls.Add(this.dgEquities);
            this.Name = "ctlEquities";
            this.Size = new System.Drawing.Size(926, 530);
            ((System.ComponentModel.ISupportInitialize)(this.dgEquities)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgEquities;
        private System.Windows.Forms.Button btnDGUpdate;
    }
}
