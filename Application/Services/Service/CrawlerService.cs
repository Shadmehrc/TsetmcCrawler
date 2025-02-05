using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Services.ServiceInterface;
using Domain.Models.Models;
using System.Net.Http;
using System.Threading.Tasks;
using Infrastructure.DAL.RepositoryInterface;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;


namespace Application.Services.Service
{
    public class CrawlerService : ICrawlerService
    {
        private readonly IConfiguration _configuration;
        private readonly ITsetmcCrawlerDAL _context;
        private readonly ISignalRHub _hub;

        public CrawlerService(IConfiguration configuration, ITsetmcCrawlerDAL context, ISignalRHub hub)
        {
            _configuration = configuration;
            _context = context;
            _hub = hub;
        }


        public async Task<bool> Start()
        {
            using HttpClient client = new HttpClient();

            string TseTmcInitUrl = _configuration["TseTmcInitUrl"].ToString();
            List<Symbol> fixList = new List<Symbol>();
            List<Symbol> fixListTemp = new List<Symbol>();

            HttpResponseMessage response = await client.GetAsync(TseTmcInitUrl);
            string serializedSymbols = await response.Content.ReadAsStringAsync();
            fixList = GeneralHelper.DeSerializeSymbols(serializedSymbols);

            while (true)
            {
                //Get symbols again
                HttpResponseMessage responseTemp = await client.GetAsync(TseTmcInitUrl);
                string serializedSymbolsTemp = await responseTemp.Content.ReadAsStringAsync();
                fixListTemp = GeneralHelper.DeSerializeSymbols(serializedSymbolsTemp);


                //validate diffrence
                List<Symbol> differencelList = FindDifference(fixList, fixListTemp);
                fixList = fixListTemp;

                //TODO /Fix Dispose problem and test    
                //Save to DB 
                // await _context.SaveData(fixList);


                await Task.Delay(1000);

                //SignalR
                string serializedSymbolsHub=JsonConvert.SerializeObject(fixList);
                await _hub.SendData(serializedSymbolsHub);
                Console.WriteLine("1");
            }
            return true;
        }
        public List<Symbol> FindDifference(List<Symbol> oldList, List<Symbol> newList)
        {
            List<Symbol> differencelList = new List<Symbol>();

            foreach (var item in oldList)
            {
                var newItem = newList.FirstOrDefault(x => x.InsCode == item.InsCode);
                //if (item.SymbolTitle == "وسپهر")
                //{
                //    ;
                //}
                if (item.lastTradedPrice != newItem.lastTradedPrice)
                {
                    //todo maybe i can just add the changed item property and a flag
                    differencelList.Add(newItem);
                    Console.WriteLine("2");

                }
            }
            return differencelList;
        }

        public void SendSymbols(List<Symbol> symbols)
        {
            throw new NotImplementedException();
        }
    }
}
