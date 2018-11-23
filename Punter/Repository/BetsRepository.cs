using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Punters.Repository
{
    public class BetsRepository
    {
        #region Fields and Methods

        private readonly PunterDbContext _db;

        #endregion  

        public BetsRepository(PunterDbContext db)
        {
            _db = db;
        }

        public async Task<int> SaveBet(Bet Bet, Market Market, Punter Punter)
        {
            return await _db.Database.ExecuteSqlCommandAsync($"AddBet {Punter.PunterID},{Market.MarketID},{Market.Odds},{Bet.Stake},{Bet.PotentialPayout}");
        }
    }
}
