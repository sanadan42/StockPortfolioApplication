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
    public partial class ctlEquityExchangeCurrency : UserControl
    {
        public ctlEquityExchangeCurrency()
        {
            InitializeComponent();
            InitializeControl();
        }

        private void InitializeControl()
        {
            using (var stockEntity = new StockPortfolioDBEntities())
            {
                InitCurrencyCombo();
                InitExchangeCombo();
            }
        }

        private void InitCurrencyCombo()
        {
            using (var stockEntity = new StockPortfolioDBEntities())
            {
                var currencies = stockEntity.tblCurrencies.OrderBy(c => c.CurrencyType).ToList();
                currencies.Insert(0, new tblCurrency());

                // initialize Currency combo box
                cmbExchangeCurrency.DataSource = currencies;
                cmbExchangeCurrency.DisplayMember = "CurrencyType";
                cmbExchangeCurrency.ValueMember = "CurrencyID";
            }
        }

        private void InitExchangeCombo()
        {
            using (var stockEntity = new StockPortfolioDBEntities())
            {
                var exchanges = stockEntity.tblStockExchanges.OrderBy(e => e.ExchangeName).ToList();
                exchanges.Insert(0, new tblStockExchanx());

                // initialize Exchange combo box
                cmbEquityExchange.DataSource = exchanges;
                cmbEquityExchange.DisplayMember = "ExchangeName";
                cmbEquityExchange.ValueMember = "ExchangeID";
            }
        }

        private void btnEquityAddNew_Click(object sender, EventArgs e)
        {
            try
            {
                using (var stockEntity = new StockPortfolioDBEntities())
                {
                    stockEntity.tblEquities.Add(new tblEquity
                    {
                        ExchangeIDFK = (int)cmbEquityExchange.SelectedValue,
                        StockTicker = txtEquityTicker.Text,
                        Description = txtEquityDescription.Text,
                        CurrentPrice = decimal.Parse(txtEquityCurrentPrice.Text),
                        HasDividend = (bool)chkEquityHasDividend.Checked
                    });
                    stockEntity.SaveChanges();
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
            finally
            {
                InitEquityEntry();
            }
        }

        private void InitEquityEntry()
        {
            cmbEquityExchange.SelectedIndex = 0;
            chkEquityHasDividend.Checked = false;
            txtEquityCurrentPrice.Text = txtEquityDescription.Text = txtEquityTicker.Text = "";
        }

        private void InitExchangeEntry()
        {
            cmbExchangeCurrency.SelectedIndex = 0;
            txtExchangeName.Text = txtExchangeDescription.Text = "";
        }

        private void InitCurrencyEntry()
        {
            txtCurrencyName.Text = txtCurrencyExchangeRate.Text = "";
        }

        private void btnExchangeAddNew_Click(object sender, EventArgs e)
        {
            try
            {
                using (var stockEntity = new StockPortfolioDBEntities())
                {
                    stockEntity.tblStockExchanges.Add(new tblStockExchanx
                    {
                        CurrencyIDFK = (int)cmbExchangeCurrency.SelectedValue,
                        ExchangeName = txtExchangeName.Text,
                        ExchangeDescription = txtExchangeDescription.Text
                    });
                    stockEntity.SaveChanges();
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
            finally
            {
                InitExchangeEntry();
                InitExchangeCombo();
            }
        }

        private void btnCurrencyAddNew_Click(object sender, EventArgs e)
        {
            try
            {
                using (var stockEntity = new StockPortfolioDBEntities())
                {
                    stockEntity.tblCurrencies.Add(new tblCurrency
                    {
                        CurrencyType = txtCurrencyName.Text,
                        ExchangeRate = decimal.Parse(txtCurrencyExchangeRate.Text)
                    });
                    stockEntity.SaveChanges();
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
            finally
            {
                InitCurrencyEntry();
                InitCurrencyCombo();
            }
        }

        
    }
}
