using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeProc.DTO
{
    public class BaringsModel
    {
        public int tradeType;
        public Guid TradeID;
        public DateTime TradeDate;
        public decimal Amount;
        public int currency;
        public string TransactionCode;
        public string TransactionSubCode;
        public string ActionCode;

    }
}
