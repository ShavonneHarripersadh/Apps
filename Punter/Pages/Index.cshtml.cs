using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Punters;
using Punters.Repository;

namespace Punters.Pages
{
    public class IndexModel : PageModel
    {
        private readonly PunterDbContext context;

        public IndexModel(PunterDbContext PunterContext)
        {
            context = PunterContext;
        }

        public IList<Punter> Punter { get; private set; }

        [TempData]
        public string Message { get; set; }

        public async Task OnGetAsync()
        {
            try
            {
                PunterRepository repo = new PunterRepository(context);
                Punter = await repo.GetPunter();
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }            
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            //var customer = await _db.Customers.FindAsync(id);

            try
            {
                PunterRepository repo = new PunterRepository(context);
                var delete =await repo.DeletePunter(id);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return RedirectToPage();
        }

    }
}
