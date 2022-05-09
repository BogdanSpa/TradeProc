using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeProc.DTO;
using BL.Models;

namespace TradeProc.Mapping
{
    public static class ViewModelMapper
    {
        public static BbhTrade ToBbhTrade(this BbhModel trade)
        {
            if (trade == null)
            {
                return null;
            }
            else
            {
                return new BbhTrade()
                {
                    TradeID = trade.TradeID,
                    TradeDate = trade.TradeDate,
                    SourceFile = trade.SourceFile,
                    SourceId = trade.SourceId,
                    Amount = trade.Amount,
                    currency = (Currency)trade.currency,
                    tradeType = (TradeType)trade.tradeType,
                };
            }
        }
        public static BaringsTrade ToBaringsTrade(this BaringsModel trade)
        {
            if (trade == null)
            {
                return null;
            }
            else
            {
                return new BaringsTrade()
                {
                    TradeID = trade.TradeID,
                    TradeDate = trade.TradeDate,
                    TransactionCode = trade.TransactionCode,
                    TransactionSubCode = trade.TransactionSubCode,
                    ActionCode = trade.ActionCode,
                    Amount = trade.Amount,
                    currency = (Currency)trade.currency,
                    tradeType = (TradeType)trade.tradeType
                };
            }
        }
    }
}







