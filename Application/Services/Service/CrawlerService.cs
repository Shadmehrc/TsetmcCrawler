using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Services.ServiceInterface;
using Domain.Models.Models;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;


namespace Application.Services.Service
{
    public class CrawlerService : ICrawlerService
    {
        private readonly IConfiguration _configuration;

        public CrawlerService(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public async void Start()
        {
            using HttpClient client = new HttpClient();

            string TseTmcInitUrl = _configuration["TseTmcInitUrl"].ToString();


            //Send to db maybe
            //Send init symbols

            List<Symbol> fixList = new List<Symbol>();
            List<Symbol> fixListTemp = new List<Symbol>();



            HttpResponseMessage response = await client.GetAsync(TseTmcInitUrl);
            string serializedSymbols = await response.Content.ReadAsStringAsync();
            fixList = GeneralHelper.DeSerializeSymbols(serializedSymbols);

            while (true)
            {
                //Get symbols again
                HttpResponseMessage responseTemp = await client.GetAsync(TseTmcInitUrl);
                string serializedSymbolstTemp = await response.Content.ReadAsStringAsync();
                fixListTemp = GeneralHelper.DeSerializeSymbols(serializedSymbols);

               // var temp = fixListTemp.FirstOrDefault(x => x.CompanyTitle == "عيار");
                //validate diffrence
                List<Symbol> differencelList = FindDifference(fixList, fixListTemp);

                //Send to db maybe
                fixList = fixListTemp;


                //SignalR

            }

        }
        public List<Symbol> FindDifference(List<Symbol> oldList, List<Symbol> newList)
        {
            List<Symbol> differencelList = new List<Symbol>();

            foreach (var item in oldList)
            {
                var newItem = newList.FirstOrDefault(x => x.InsCode == item.InsCode);
                if (item.Value != newItem.Value)
                {
                    //todo maybe i can just add the changed item property and a flag
                    differencelList.Add(newItem);
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
