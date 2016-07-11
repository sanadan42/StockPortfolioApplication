using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockPortfolioApplication
{
    public partial class ctlAccountBalances : UserControl
    {
        Portfolio portfolio;
        private List<System.Windows.Forms.Label> accountNames;
        private List<System.Windows.Forms.Label> accountBalances;

        public ctlAccountBalances(Portfolio p)
        {
            this.accountNames = new List<Label>();
            this.accountBalances = new List<Label>();
            this.portfolio = p;
            InitializeComponent();
            DisplayAccountNames();
        }

        private void DisplayAccountNames()
        {
            InitAccountNameLabels();

            foreach(Label l in accountNames)
            {
                this.grpAccountBalances.Controls.Add(l);
                l.Visible = true;
            }
        }

        private void InitAccountNameLabels()
        {
            int x = 3;
            int y = 26;
            foreach(Account a in portfolio.GetAccounts())
            {
                Label newAccount = new Label();
                newAccount.AutoSize = true;
                newAccount.Location = new Point(x, y);
                newAccount.Text = a.AccountName;

                this.accountNames.Add(newAccount);
                y += 16;
            }
            this.grpAccountBalances.Size = new Size(grpAccountBalances.Size.Width, y + 10);
        }
    }
}
