using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockPortfolioApplication
{
    enum EquityTransactionTypes
    {
        BuyStock = 1,
        SellStock = 2,
        WithdrawalStock = 3, // never used - should I delete this?
        DepositStock = 4, // never used - should I delete this?
        TransferBuy = 5,
        TransferSell = 6
    }

    enum FinancialTransactionTypes
    {
        Deposit = 7,
        Withdrawal = 8,
        Conversion = 10,
        ForeignExchange = 11,
        Interest = 12,
        Fees = 13
    }

    enum TransactionUsage
    {
        Financial = 0,
        Equity
    }
}
