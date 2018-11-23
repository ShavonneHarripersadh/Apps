using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Punters.Repository
{
    public class PunterRepository
    {
        #region Fields and Methods

        private readonly PunterDbContext _db;

        #endregion  

        public PunterRepository(PunterDbContext db)
        {
            _db = db;
        }

        public async Task<int> SavePunter(Punter punter)
        {
            return await _db.Database.ExecuteSqlCommandAsync($"AddPunter {punter.PunterName} ,{punter.Balance}");
        }

        public async Task<List<Punter>> GetPunter()
        {
            return await _db.Punter.AsNoTracking().ToListAsync();
        }

        public async Task<int> DeletePunter(int id)
        {
            return await _db.Database.ExecuteSqlCommandAsync($"DeletePunter {id}");
        }

        public async Task<Punter> GetPunterByID(int id)
        {
            return await _db.Punter.FromSql($"ReadPunterByID {id}").FirstOrDefaultAsync();
        }

        public async Task<int> UpdatePunter(Punter Punter)
        {
            return await _db.Database.ExecuteSqlCommandAsync($"UpdatePunter {Punter.PunterID},{Punter.PunterName},{Punter.Balance}");
        }
    }
}
