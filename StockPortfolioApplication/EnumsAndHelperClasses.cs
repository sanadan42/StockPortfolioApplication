﻿using System;
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
        WithdrawalStock = 3,
        DepositStock = 4,
        TransferBuy = 5,
        TransferSell = 6,
        Dividend = 14,
        DRIP = 15
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
