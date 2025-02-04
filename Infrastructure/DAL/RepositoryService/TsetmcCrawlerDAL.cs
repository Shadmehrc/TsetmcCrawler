using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Domain.Models.Models;
using Infrastructure.DAL.RepositoryInterface;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DAL.RepositoryService
{
    public class TsetmcCrawlerDAL : ITsetmcCrawlerDAL
    {
        private readonly ApplicationDbContext _context;

        public TsetmcCrawlerDAL(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> SaveData(List<Symbol> symbols)
        {
            try
            {
                _context.AddRange(symbols);
                await _context.SaveChangesAsync();

                var products = await _context.Symbols.ToListAsync();
                return true;

            }
            catch (Exception msg)
            {
                throw new Exception(msg.Message);

            }


        }
    }
}
