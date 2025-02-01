using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Models
{
    public class Symbol
    {
        public string SymbolTitle { get; set; }
        public string CompanyTitle { get; set; }
        public string EPS { get; set; }
        public string PE { get; set; }
        public string SymbolISIN { get; set; }
        public double FirstTradedPrice { get; set; }
        public double lastTradedPrice { get; set; }
        public double ClosingPrice { get; set; }
        public double HighPrice { get; set; }
        public double LowPrice { get; set; }
        public double Volume { get; set; }
        public double Value { get; set; }
        public double Quantity { get; set; }
        public double YesterdayClosingPrice { get; set; }
        public string InsCode { get; set; }
    }
}
