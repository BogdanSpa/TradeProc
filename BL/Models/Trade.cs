using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    public class Trade
    {
        public TradeType tradeType;
        public Guid TradeID { get; set; }
        public DateTime TradeDate { get; set; }
        public decimal Amount { get; set; }
        public Currency currency { get; set; }
        public bool isValid = false;
    }
}
