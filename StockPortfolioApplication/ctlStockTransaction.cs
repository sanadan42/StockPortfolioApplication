﻿using System;
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
    public partial class ctlStockTransaction : UserControl
    {
        enum TransactionUsage
        {
            Financial = 0,
            Equity
        }

        public ctlStockTransaction()
        {
            InitializeComponent();
            InitializeControls();
        }

        private void InitializeControls()
        {
            using (var stockEntity = new StockPortfolioDBEntities())
            {

                var transactionTypes = stockEntity.tblTransactionTypes.OrderBy(t => t.TransactionType);
                var transactionEquityTypes = transactionTypes.Where(t => t.TransactionTypeUsage == (int)TransactionUsage.Equity).ToList();
                var transactionFinancialTypes = transactionTypes.Where(t => t.TransactionTypeUsage == (int)TransactionUsage.Financial).ToList();
                transactionEquityTypes.Insert(0, new tblTransactionType());
                transactionFinancialTypes.Insert(0, new tblTransactionType());

                var accounts = stockEntity.tblAccounts.OrderBy(a => a.AccountName).ToList();
                accounts.Insert(0, new tblAccount());

                var equitiesAll = stockEntity.tblEquities.OrderBy(c => c.StockTicker);
                var equities = equitiesAll.ToList(); 
                var dividendEquities = equitiesAll.Where(d => d.HasDividend == true).ToList();
                equities.Insert(0, new tblEquity());
                dividendEquities.Insert(0, new tblEquity());

                var currencies = stockEntity.tblCurrencies.OrderBy(c => c.CurrencyType).ToList();
                currencies.Insert(0, new tblCurrency());

                // initialize equity combo box
                cmbTransactionEquity.DataSource = transactionEquityTypes;
                cmbFinancialTransaction.DataSource = transactionFinancialTypes;
                cmbTransactionEquity.DisplayMember = cmbFinancialTransaction.DisplayMember = "TransactionType";
                cmbTransactionEquity.ValueMember = cmbFinancialTransaction.ValueMember = "TransactionTypeID";

                // initialize accounts combo box
                cmbAccountEquity.DataSource = cmbDividendAccount.DataSource = cmbFinancialAccount.DataSource = cmbAccountTo.DataSource = cmbFinancialAccountTo.DataSource = accounts;
                cmbAccountEquity.DisplayMember = cmbDividendAccount.DisplayMember = cmbFinancialAccount.DisplayMember = cmbAccountTo.DisplayMember = cmbFinancialAccountTo.DisplayMember = "AccountName";
                cmbAccountEquity.ValueMember = cmbDividendAccount.ValueMember = cmbFinancialAccount.ValueMember = cmbAccountTo.ValueMember = cmbFinancialAccountTo.ValueMember = "AccountID";
                cmbAccountTo.Visible = cmbFinancialAccountTo.Visible = false;

                // initialize Equity combo box
                cmbEquityEquity.DataSource = equities;
                cmbDividendEquity.DataSource = dividendEquities;
                cmbEquityEquity.DisplayMember = cmbDividendEquity.DisplayMember = "StockTicker";
                cmbEquityEquity.ValueMember = cmbDividendEquity.ValueMember = "EquityID";

                // initialize currency combo box
                cmbFinancialCurrency.DataSource = currencies;
                cmbFinancialCurrency.DisplayMember = "CurrencyType";
                cmbFinancialCurrency.ValueMember = "CurrencyID";

                lblAccountTo.Visible = lblFinancialAccountTo.Visible = false;
            }
        }

        private void InitEquityTransactions()
        {
            cmbTransactionEquity.SelectedIndex = 0;
            cmbAccountEquity.SelectedIndex = cmbAccountTo.SelectedIndex = 0;
            cmbEquityEquity.SelectedIndex = 0;
            numEquityShares.Value = 0;
            txtPrice.Text = "";
            txtCommission.Text = "";
            txtExchangeRate.Text = "";
        }

        private void InitDividendTransactions()
        {
            cmbDividendEquity.SelectedIndex = 0;
            cmbDividendAccount.SelectedIndex = 0;
            txtDividend.Text = "";
        }

        private void InitFinancialTransactions()
        {
            cmbFinancialTransaction.SelectedIndex = 0;
            cmbFinancialAccount.SelectedIndex = cmbFinancialAccountTo.SelectedIndex = 0;
            cmbFinancialCurrency.SelectedIndex = 0;
            numEquityShares.Value = 0;
            txtFincialNet.Text = "";
        }

        private void cmbTransaction_Change(object sender, EventArgs e)
        {
            // instead of strings these should probably be values that correspond to the selected value that is returned
            bool accountToStatus = cmbTransactionEquity.Text == "TRF-B" || cmbTransactionEquity.Text == "TRF-S";
            lblAccountTo.Visible = accountToStatus;
            cmbAccountTo.Visible = accountToStatus;
        }

        private void cmbFinancialTransaction_SelectedIndexChanged(object sender, EventArgs e)
        {
            // instead of strings these should probably be values that correspond to the selected value that is returned
            bool accountToStatus = cmbFinancialTransaction.Text == "CON";
            lblFinancialAccountTo.Visible = accountToStatus;
            cmbFinancialAccountTo.Visible = accountToStatus;
        }

        private void btnTransactionSave_Click(object sender, EventArgs e)
        {
            int shareModifier = 1;
            try
            {
                using (var stockEntity = new StockPortfolioDBEntities())
                {
                    if((int)cmbTransactionEquity.SelectedValue == (int)TransactionTypes.SellStock)
                    {
                        if ((int)numEquityShares.Value > 0)
                            shareModifier = -1;
                    }

                    stockEntity.tblTransactionEquities.Add(new tblTransactionEquity
                    {
                        TransactionDate = dtpTransactionDate.Value,
                        TransactionTypeIDFK = (int)cmbTransactionEquity.SelectedValue,
                        AccountIDFK = (int)cmbAccountEquity.SelectedValue,
                        EquityIDFK = (int)cmbEquityEquity.SelectedValue,
                        Shares = shareModifier*(int)numEquityShares.Value,
                        Price = decimal.Parse(txtPrice.Text),
                        Commission = decimal.Parse(txtCommission.Text),
                        ExchangeRate = decimal.Parse(txtExchangeRate.Text)
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
                InitEquityTransactions();
            }
        }

        private void btnDividendSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (var stockEntity = new StockPortfolioDBEntities())
                {
                    stockEntity.tblTransactionDividends.Add(new tblTransactionDividend
                    {
                        DividendDate = dtpDividend.Value,
                        EquityIDFK = (int)cmbDividendEquity.SelectedValue,
                        AccountIDFK = (int)cmbDividendAccount.SelectedValue,
                        DividendValue = decimal.Parse(txtDividend.Text)
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
                InitDividendTransactions();
            }
        }

        private void btnFinancialSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (var stockEntity = new StockPortfolioDBEntities())
                {
                    stockEntity.tblTransactionFinances.Add(new tblTransactionFinance
                    {
                        TransactionDate = dtpFinancialTransaction.Value,
                        TransactionIDFK = (int)cmbFinancialTransaction.SelectedValue,
                        AccountIDFK = (int)cmbFinancialAccount.SelectedValue,
                        Net = decimal.Parse(txtFincialNet.Text),
                        CurrencyIDFK = (int)cmbFinancialCurrency.SelectedValue
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
                InitDividendTransactions();
            }
        }
    }
}
