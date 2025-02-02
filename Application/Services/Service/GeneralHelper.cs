using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Services.ServiceInterface;
using Domain.Models.Models;
using Newtonsoft.Json;

namespace Application.Services.Service
{
    public static class GeneralHelper 
    {
        public static List<Symbol> DeSerializeSymbols(string rawSymbols)
        {
            try
            {
                var root = JsonConvert.DeserializeObject<SymbolRootClass>(rawSymbols);
                var symbols = new List<Symbol>();
                if (root == null) return symbols;
                symbols.AddRange(root.marketwatch.Select(item => new Symbol
                {
                    SymbolTitle = item.lva,
                    CompanyTitle = item.lvc,
                    EPS = item.eps.ToString(),
                    PE = item.pe,
                    SymbolISIN = item.insID,
                    FirstTradedPrice = Convert.ToDouble(item.pf).ToString(),
                    lastTradedPrice = Convert.ToDouble(item.pdv).ToString(),
                    ClosingPrice = Convert.ToDouble(item.pcl).ToString(),
                    HighPrice = Convert.ToDouble(item.pMax).ToString(),
                    LowPrice = Convert.ToDouble(item.pmn).ToString(),
                    Value = Convert.ToDouble(item.qtc).ToString(),
                    Volume = Convert.ToDouble(item.qtj).ToString(),
                    Quantity = Convert.ToDouble(item.ztt).ToString(),
                    YesterdayClosingPrice = Convert.ToDouble(item.py).ToString(),
                    InsCode = item.insCode
                }));
                return symbols;
            }
            catch (Exception ex)
            {
                Console.WriteLine("error occured");
                throw;
            }
        }


    }
}
