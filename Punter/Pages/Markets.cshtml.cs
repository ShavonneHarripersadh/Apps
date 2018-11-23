using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Punters;
using Punters.Repository;

namespace Punter.Pages
{
    public class MarketsModel : PageModel
    {
        private readonly PunterDbContext context;

        public MarketsModel(PunterDbContext PunterContext)
        {
            context = PunterContext;
        }

        public IList<Market> Market { get; private set; }

        [TempData]
        public string Message { get; set; }

        public async Task OnGetAsync()
        {
            try
            {
                MarketRepository repo = new MarketRepository(context);
                Market = await repo.GetMarket();
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
            
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            
            try
            {
                MarketRepository repo = new MarketRepository(context);
                var delete = await repo.DeleteMarket(id);

            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }

            return RedirectToPage();
        }
    }
}
