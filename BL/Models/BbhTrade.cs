using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    public class BbhTrade : Trade
    {
        public int SourceId { get; set; }
        public string SourceFile { get; set; }
    }
}
