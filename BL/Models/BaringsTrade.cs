using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    public class BaringsTrade : Trade
    {
        public string TransactionCode { get; set; }
        public string TransactionSubCode { get; set; }
        public string ActionCode { get; set; }
    }
}
