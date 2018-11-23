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
    public class EditPunterModel : PageModel
    {
        private readonly PunterDbContext _db;

        public EditPunterModel(PunterDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Punter Punter { get; set; }

        [TempData]
        public string Message { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            try
            {
                PunterRepository repo = new PunterRepository(_db);
                Punter = await repo.GetPunterByID(id);
                //Customer = customer.First();
                if (Punter == null)
                {
                    return RedirectToPage("/Index");
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
            _db.Attach(Punter).State = EntityState.Modified;

            try
            {
                PunterRepository repo = new PunterRepository(_db);
                var update = await repo.UpdatePunter(Punter);
            }
            catch (DbUpdateConcurrencyException e)
            {
                Message = e.Message;                
            }

            return RedirectToPage("./Index");
        }
    }
}