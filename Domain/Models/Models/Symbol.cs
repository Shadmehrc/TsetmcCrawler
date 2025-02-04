using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Models
{
    public class Symbol
    {
        [Key]
        public string InsCode { get; set; }
        public string SymbolTitle { get; set; }
        public string CompanyTitle { get; set; }
        public string EPS { get; set; }
        public string PE { get; set; }
        public string SymbolISIN { get; set; }
        public string FirstTradedPrice { get; set; }
        public string lastTradedPrice { get; set; }
        public string ClosingPrice { get; set; }
        public string HighPrice { get; set; }
        public string LowPrice { get; set; }
        public string Volume { get; set; }
        public string Value { get; set; }
        public string Quantity { get; set; }
        public string YesterdayClosingPrice { get; set; }

    }
}
