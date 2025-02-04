using Domain.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DAL.RepositoryInterface
{
    public interface ITsetmcCrawlerDAL
    {
        public Task<bool> SaveData(List<Symbol> symbols);
    }
}
