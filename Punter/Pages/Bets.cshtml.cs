using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Punters;

namespace Punter.Pages
{
    public class BetsModel : PageModel
    {
        private readonly PunterDbContext _db;

        public BetsModel(PunterDbContext db)
        {
            _db = db;
        }

        public IList<Bet> Bet { get;  set; }

        [TempData]
        public string Message { get; set; }

        public async Task OnGetAsync()
        {
            Bet = await _db.Bet.AsNoTracking().ToListAsync();
        }

    }
}
