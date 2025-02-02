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
            List<Symbol> differencelList = new List<Symbol>();

            HttpResponseMessage response = await client.GetAsync(TseTmcInitUrl);
            string serializedSymbols = await response.Content.ReadAsStringAsync();
            fixList = GeneralHelper.DeSerializeSymbols(serializedSymbols);

            while (true)
            {


                //Get symbols again

                //validate diffrence

                //Send to db maybe

                //SignalR

                Task.Delay(1000);
            }

        }
    }
}
