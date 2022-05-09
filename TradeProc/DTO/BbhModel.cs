using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TradeProc.DTO
{
    public class BbhModel
    {
        public int tradeType;
        public Guid TradeID;
        public DateTime TradeDate;
        public decimal Amount;
        public int currency;
        public int SourceId;
        public string SourceFile;
    }
}
