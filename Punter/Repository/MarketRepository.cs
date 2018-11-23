using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Punters.Repository
{
    public class MarketRepository
    {
        #region Fields and Methods

        private readonly PunterDbContext _db;

        #endregion  

        public MarketRepository(PunterDbContext db)
        {
            _db = db;
        }

        public async Task<int> SaveMarket(Market Market)
        {
            return await _db.Database.ExecuteSqlCommandAsync($"AddMarket {Market.MarketName} ,{Market.Odds}");
        }

        public async Task<List<Market>> GetMarket()
        {
            return await _db.Market.AsNoTracking().ToListAsync();
        }

        public async Task<int> DeleteMarket(int id)
        {
            return await _db.Database.ExecuteSqlCommandAsync($"DeleteMarket {id}");
        }

        public async Task<Market> GetMarketByID(int id)
        {
            return await _db.Market.FromSql($"ReadMarketByID {id}").FirstOrDefaultAsync();
        }

        public async Task<int> UpdateMarket(Market Market)
        {
            return await _db.Database.ExecuteSqlCommandAsync($"UpdateMarket {Market.MarketID},{Market.MarketName},{Market.Odds}");
        }
    }
}
