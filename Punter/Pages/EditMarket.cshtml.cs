using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Punters.Repository;

namespace Punters.Pages
{
    public class EditMarketModel : PageModel
    {
        private readonly PunterDbContext _db;

        [BindProperty]
        public Market Market { get; set; }

        [TempData]
        public string Message { get; set; }

        public EditMarketModel(PunterDbContext db)
        {
            _db = db;
        }

        

        public async Task<IActionResult> OnGetAsync(int id)
        {
            try
            {
                MarketRepository repo = new MarketRepository(_db);
                Market =await repo.GetMarketByID(id);
                //Customer = customer.First();
                if (Market == null)
                {
                    return RedirectToPage("/Markets");
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _db.Attach(Market).State = EntityState.Modified;

            try
            {
                MarketRepository repo = new MarketRepository(_db);
                var update = await repo.UpdateMarket(Market);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                Message = ex.Message;
            }

            return RedirectToPage("./Markets");
        }
    }
}