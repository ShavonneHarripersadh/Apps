using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Punters.Pages
{
    public class PlaceBetModel : PageModel
    {
        public readonly PunterDbContext _db;
        
        public Punter Punter { get; set; }
        public PlaceBetModel(PunterDbContext db)
        {
            _db = db;
        }

        
        
        public static Punter Punts ;
        
        public IList<Market> Market { get; private set; }

        public async Task OnGetAsync(int id)
        {
            
            var o = 4;
            Punter = await _db.Punter.FromSql($"ReadPunterByID {id}").FirstOrDefaultAsync();
            Punts = Punter;
            try
            {
                Market = await _db.Market.AsNoTracking().ToListAsync();

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            
        }

        //public async Task OnGetAsync()
        //{
        //    Market = await _db.Market.AsNoTracking().ToListAsync();
        //}
    }
}