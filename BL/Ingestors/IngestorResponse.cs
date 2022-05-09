using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Ingestors
{
    public class IngestorResponse
    {
        public Guid TradeId { get; set; }
        public string Status { get; set; }
        public Dictionary<ValidationReasons, string> Reasons { get; set; }
    }
}
