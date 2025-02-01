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
    public class CrawlerService :  ICrawlerService
    {
        private readonly IConfiguration _configuration;

        public CrawlerService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async void Start( )
        {
            using HttpClient client = new HttpClient();
            string test2 = _configuration["TseTmcInitUrl"].ToString();
            HttpResponseMessage response = await client.GetAsync(test2);
            var test = GeneralHelper.DeSerializeSymbols(response.ToString());
            throw new NotImplementedException();
        }
    }
}
