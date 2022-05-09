using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Models;

namespace BL.Ingestors
{
    public class Ingestor
    {
       // public List<Trade> TradeList;
        public List<Trade> ValidTrades = new List<Trade>();
        public List<Trade> InvalidTrades = new List<Trade>();
        public Dictionary<ValidationReasons, string> validationReasons;
        private List<IngestorResponse> ingestorResponseList = new List<IngestorResponse>();
        
        //public Ingestor(List<Trade> tradeList)
        //{
        //    TradeList = tradeList;
        //}

        public void sendToIngestor(List<Trade> TradeList)
        {
            foreach (var trade in TradeList)
            {
                bool isValid = ValidateTrade(trade);
                if (isValid)
                {
                    trade.isValid = true;
                    ValidTrades.Add(trade);
                    ingestorResponseList.Add(new IngestorResponse
                    {
                        TradeId = trade.TradeID,
                        Status = "Success",
                        Reasons = validationReasons
                    });
                }
                else
                if (!isValid)
                {
                    ingestorResponseList.Add(new IngestorResponse
                    {
                        TradeId = trade.TradeID,
                        Status = "Failure",
                        Reasons = validationReasons
                    });
                    InvalidTrades.Add(trade);
                }
            }
        }

        public bool ValidateTrade(Trade trade)
        {
            if (trade is BaringsTrade)
            {
                validationReasons = new Dictionary<ValidationReasons, string>();
                if (BaringsIngestor.isTradeValid((BaringsTrade)trade))
                    return true;
                else
                {
                    validationReasons = BaringsIngestor.ValidationPassing((BaringsTrade)trade);
                }
            }
            else
            if (trade is BbhTrade)
            {
                validationReasons = new Dictionary<ValidationReasons, string>();
                if (BbhIngestor.isTradeValid((BbhTrade)trade))
                    return true;
                else
                {
                    validationReasons = BbhIngestor.ValidationPassing((BbhTrade)trade);
                }
            }
            return false;
        }


        public List<IngestorResponse> GetIngestorResponse()
        {
            return ingestorResponseList;
        }
        public List<Trade> GetValidTrades()
        {
            return ValidTrades;
        }

        public List<Trade> GetInvalidTrades()
        {
            return InvalidTrades;
        }


    }
}
