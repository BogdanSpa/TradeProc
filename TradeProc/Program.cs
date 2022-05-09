using TradeProc.DTO;

using TradeProc.Mapping;

using BL.Models;
using BL.Ingestors;

BaringsModel mbarTrade1 = new BaringsModel()
{
    ActionCode = "action",
    tradeType = 0,
    TradeDate = DateTime.Now,
    TradeID = Guid.NewGuid(),
    Amount = 120.1M,
    currency = 1,
    TransactionCode = "",
    TransactionSubCode = "1b312",
};

BaringsModel mbarTrade2 = new BaringsModel()
{
    ActionCode = "3rs21",
    tradeType = 0,
    TradeDate = DateTime.Now,
    TradeID = Guid.NewGuid(),
    Amount = 90.1M,
    currency = 1,
    TransactionCode = "323g",
    TransactionSubCode = "sab234aw1",
};

BaringsModel mbarTrade3 = new BaringsModel()
{
    ActionCode = "ssda232a",
    tradeType = 0,
    TradeDate = new DateTime(1998, 2, 4),
    TradeID = Guid.NewGuid(),
    Amount = 0,
    currency = 0,
    TransactionCode = "",
    TransactionSubCode = "cas34sa",
};

BbhModel mbbhTrade1 = new BbhModel()
{
    tradeType = 0,
    TradeID = Guid.NewGuid(),
    TradeDate = new DateTime(1998, 2, 4),
    Amount = 0,
    currency = 1,
    SourceFile = "/app/ty",
    SourceId = 1
};

BbhModel mbbhTrade2 = new BbhModel()
{
    tradeType = 1,
    TradeID = Guid.NewGuid(),
    TradeDate = DateTime.Now,
    Amount = 300.321m,
    currency = 1,
    SourceFile = "/app/ty/tyty",
    SourceId = 1
};

BbhModel mbbhTrade3 = new BbhModel()
{
    tradeType = 0,
    TradeID = Guid.NewGuid(),
    TradeDate = DateTime.Now,
    Amount = 300.321m,
    currency = 2,
    SourceFile = "",
    SourceId = 3
};

BaringsTrade barTrade1 = mbarTrade1.ToBaringsTrade();
BaringsTrade barTrade2 = mbarTrade2.ToBaringsTrade();
BaringsTrade barTrade3 = mbarTrade3.ToBaringsTrade();

BbhTrade bbhTrade1 = mbbhTrade1.ToBbhTrade();
BbhTrade bbhTrade2 = mbbhTrade2.ToBbhTrade();
BbhTrade bbhTrade3 = mbbhTrade3.ToBbhTrade();

List<Trade> tradeList = new List<Trade>();
//List<Trade> ValidTrades;
tradeList.Add(barTrade1);
tradeList.Add(barTrade2);
tradeList.Add(barTrade3);

tradeList.Add(bbhTrade1);
tradeList.Add(bbhTrade2);
tradeList.Add(bbhTrade3);

Ingestor ingestor = new Ingestor();

ingestor.sendToIngestor(tradeList);

Dictionary<Guid, string> TradeValidationDictionary = new Dictionary<Guid, string>();

try
{
    foreach (var trade in tradeList)
    {
        if (TradeValidationDictionary.ContainsKey(trade.TradeID))
        {
            throw new Exception("This trade has gotten a validation status already.");
        }
        else
        {
            if (trade.isValid)
                TradeValidationDictionary.Add(trade.TradeID, "SUCCESS");
            else
                TradeValidationDictionary.Add(trade.TradeID, "FAILURE");
        }
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.ToString());
}

foreach (var trade in TradeValidationDictionary)
{
    Console.WriteLine($"Trade with id: {trade.Key} has validation status: {trade.Value}");
}

foreach (var item in ingestor.GetIngestorResponse())
{
    Console.WriteLine($"Trade with ID {item.TradeId} has a {item.Status} status.");

    if (item.Reasons == null)
        continue;
    else
    {
        Dictionary<ValidationReasons, string>.ValueCollection values = item.Reasons.Values;
        if(values.Count > 0)
        Console.WriteLine("Reasons:");
        foreach (var value in values)
        {
            Console.WriteLine(value);
        }
    }
    Console.WriteLine();

}

//foreach(var trade in tradeList)
//{
//    if (trade.isValid)
//        Console.WriteLine($"Trade with id: {trade.TradeID} has validation status: VALID");
//    else
//    if(!trade.isValid)
//        Console.WriteLine($"Trade with id: {trade.TradeID} has validation status: NOT-VALID");
//}



//Console.WriteLine($"These trades are invalid: ");
//foreach (var trade in ingestor.GetInvalidTrades())
//{
//    Console.WriteLine($"{trade.TradeID}");
//}

//Console.WriteLine($"These trades are valid: ");
//foreach (var trade in ingestor.GetValidTrades())
//{
//    Console.WriteLine($"{trade.TradeID}");
//}