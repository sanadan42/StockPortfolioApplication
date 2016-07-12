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
        private List<System.Windows.Forms.Label> displayList;
        private const int OFFSET_Y = 18;
        private const int OFFSET_BALANCE = 100;

        public ctlAccountBalances(Portfolio p)
        {
            this.displayList = new List<Label>();
            this.portfolio = p;
            InitializeComponent();
            DisplaydisplayList();
        }

        private void DisplaydisplayList()
        {
            InitAccountNameLabels(3, OFFSET_Y * 2);
            int x = 0;
            foreach(Label l in displayList)
            {
                if (l.Size.Width > x)
                    x = l.Size.Width;
            }
            InitHeaderLabels(x, OFFSET_Y);
            InitBalances(x, OFFSET_Y * 2);

            int width = 0;
            int height = 0;
            foreach(Label l in displayList)
            {
                this.grpAccountBalances.Controls.Add(l);
                l.Visible = true;
                if (l.Location.Y > height)
                    height = l.Location.Y;
                if (l.Location.X > width)
                    width = l.Location.X;
            }
            height += OFFSET_Y;
            width += OFFSET_BALANCE + 10;
            this.grpAccountBalances.Size = new Size(width, height);
            this.Size = new Size(width + 5, height + 15);
        }

        private Label CreateLabel(int x, int y, string text, ContentAlignment alignment)
        {
            Label label = new Label();
            label.AutoSize = true;
            label.Location = new Point(x, y);
            label.TextAlign = alignment;
            label.Text = text;

            return label;
        }

        private void InitAccountNameLabels(int xInit, int yInit)
        {

            int x = xInit;
            int y = yInit;
            foreach(Account a in portfolio.GetAccounts())
            {
                this.displayList.Add(CreateLabel(x, y, a.AccountName, ContentAlignment.TopLeft));
                y += OFFSET_Y;
            }
        }

        private void InitHeaderLabels(int xInit, int yInit)
        {
            int x = xInit; // 50?
            int y = yInit; // 3?
            foreach(BalanceType currency in portfolio.GetCurrencyTypes())
            {
                this.displayList.Add(CreateLabel(x, y, currency.Currency, ContentAlignment.TopCenter));
                x += OFFSET_BALANCE;
            }
        }

        private void InitBalances(int xInit, int yInit)
        {
            int y = yInit;
            foreach (Account a in portfolio.GetAccounts())
            {
                a.CalculateAccountBalances();
                int x = xInit;
                foreach (BalanceType b in portfolio.GetCurrencyTypes())
                {
                    string balanceText;
                    if (a.GetBalance(b.CurrencyID) != null)
                    {
                        balanceText = a.GetBalance(b.CurrencyID).Balance.ToString("c", a.GetBalance(b.CurrencyID).GetCultureInfo());
                    }
                    else
                    {
                        balanceText = "-";
                    }
                    this.displayList.Add(CreateLabel(x, y, balanceText, ContentAlignment.TopCenter));
                    x += OFFSET_BALANCE;
                }
                y += OFFSET_Y;
            }
        }
    }

}
