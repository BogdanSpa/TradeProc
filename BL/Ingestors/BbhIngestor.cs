using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Models;
namespace BL.Ingestors
{
    public class BbhIngestor
    {
        //public BbhTrade trade { get; set; }
        //public BbhIngestor(BbhTrade Trade)
        //{
        //    trade = Trade;
        //}
        
        public static bool isTradeValid(BbhTrade trade)
        {
            if (trade.Amount > 0 && trade.TradeDate > new DateTime(2021, 6, 1) && trade.SourceFile != String.Empty)
            {
                return true;
            }
            else
            {
                return false;
            }    
        }

        public static Dictionary<ValidationReasons, string> ValidationPassing(BbhTrade trade)
        {
            Dictionary<ValidationReasons, string> result = new Dictionary<ValidationReasons, string>();
            if (trade.Amount <= 0)
            {
                result.Add(ValidationReasons.Amount, "Amount should be greater than 0");
            }
            if (trade.TradeDate <= new DateTime(2021, 6, 1))
            {
                result.Add(ValidationReasons.TradeDate, "Transaction Date must precede 01/06/2021");
            }
            if (trade.SourceFile == string.Empty)
            {
                result.Add(ValidationReasons.SourceFile, "SourceFile is empty");
            }

            return result;
        }

    }
}
