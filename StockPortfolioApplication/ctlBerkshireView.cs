using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace StockPortfolioApplication
{
    public partial class ctlBerkshireView : UserControl
    {
        private Portfolio portfolio;
        private List<ctlBerkshireEquityView> equityViewList;

        public ctlBerkshireView()
        {
            portfolio = new Portfolio();
            portfolio.CreatePortfolio();

            Init();
        }

        public ctlBerkshireView(Portfolio portfolio)
        {
            this.portfolio = portfolio;

            Init();
        }

        private void Init()
        {
            InitializeComponent();
            BuildEquityList(portfolio.GetEquityList());

            int i = 0;
            foreach (ctlBerkshireEquityView brk in equityViewList)
            {
                if (i > 0)
                {
                    brk.SetBackColor(i++);
                }
                else i++;
                this.pnlBerkshireEquityView.Controls.Add(brk);
            }

            // resize the main equity panel view to fit all equities
            pnlBerkshireEquityView.Size = new Size(pnlBerkshireEquityView.Width, this.equityViewList[this.equityViewList.Count - 1].Bottom);
            // display all totals
            CreateTotals(portfolio.GetAccountSummary());
        }

        private void SetEquitiesVisible()
        {
            foreach (ctlBerkshireEquityView brk in equityViewList)
            {
                brk.Visible = true;
            }
        }

        private void SetEquitiesInvisible()
        {
            foreach (ctlBerkshireEquityView brk in equityViewList)
            {
                brk.Visible = false;
            }
        }

        private void BuildEquityList(List<Equity> equityList)
        {
            if(equityList.Count != 0)
            {
                this.equityViewList = new List<ctlBerkshireEquityView>();

                AddHeader();
                int y = 0;

                foreach (Equity e in equityList)
                {
                    if (e.Shares > 0)
                    {
                        ctlBerkshireEquityView brkEquityView = new ctlBerkshireEquityView();
                        y += brkEquityView.Size.Height;
                        brkEquityView.Location = new Point(0, y);
                        brkEquityView.Populate(e);
                        brkEquityView.Visible = true;
                        this.equityViewList.Add(brkEquityView);
                    }
                }
            }
        }

        private void AddHeader()
        {
            ctlBerkshireEquityView brk = new ctlBerkshireEquityView();
            brk.SetAsHeader();
            
            if(this.equityViewList != null) // check to see if current list is null
            {
                if(this.equityViewList.Count > 0) // if not empty then insert at the beginning
                {
                    this.equityViewList.Insert(0, brk);
                }
                else // if empty then simply add a new item (I'm afraid insert will throw an exception, but not sure)
                {
                    this.equityViewList.Add(brk);
                }
            }
            else // if null then build the new list
            {
                this.equityViewList = new List<ctlBerkshireEquityView>();
                this.equityViewList.Add(brk);
            }
        }

        private void CreateTotals(Account account)
        {
            account.RefreshTotals();
            lblCostTotal.Location = new Point(equityViewList[0].CostHPos, pnlBerkshireEquityView.Bottom + 6);
            lblValueTotal.Location = new Point(equityViewList[0].ValueHPos, pnlBerkshireEquityView.Bottom + 6);
            lblCostTotal.Text = account.TotalEquityCost.ToString("C");
            lblValueTotal.Text = account.TotalEquityValue.ToString("C");

            pnlBerkshireSummary.Location = new Point(equityViewList[0].ValueHPos, lblCostTotal.Bottom + 6);
            pnlBerkshireSummaryLabels.Location = new Point(pnlBerkshireSummary.Left - pnlBerkshireSummaryLabels.Width, pnlBerkshireSummary.Top);
            lblSummaryDividends.Text = account.TotalDividendGain.ToString("C");
            lblSummaryRealized.Text = account.TotalRealizedGain.ToString("C");
            lblSummaryUnrealized.Text = account.TotalUnrealizedGain.ToString("C");
            lblSummaryTotals.Text = account.TotalPLGain.ToString("C");
        }
        
        private void ctlBerkshireView_Paint(object sender, PaintEventArgs e)
        {
            using (Graphics g = e.Graphics)
            {
                DrawTotalLines(g);
                DrawSummaryLines(g);
            }
        }

        private void DrawTotalLines(Graphics g)
        {
            int y1 = pnlBerkshireEquityView.Bottom;
            int y2 = y1 + 3;

            int length = 65;
            int x1 = equityViewList[0].CostHPos;
            int x2 = x1 + length;
            int x3 = equityViewList[0].ValueHPos;
            int x4 = x3 + length;

            g.DrawLine(new Pen(Color.Black, 1), new Point(x1, y1), new Point(x2, y1));
            g.DrawLine(new Pen(Color.Black, 1), new Point(x1, y2), new Point(x2, y2));
            g.DrawLine(new Pen(Color.Black, 1), new Point(x3, y1), new Point(x4, y1));
            g.DrawLine(new Pen(Color.Black, 1), new Point(x3, y2), new Point(x4, y2));
        }

        private void DrawSummaryLines(Graphics g)
        {
            int x1 = equityViewList[0].CostHPos;
            int x2 = equityViewList[0].ValueHPos + 65;
            int y = lblCostTotal.Bottom + 3;
            g.DrawLine(new Pen(Color.Black, 1), new Point(x1, y), new Point(x2, y));
        }
    }
}
