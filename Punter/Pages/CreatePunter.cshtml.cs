using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Punters.Repository;

namespace Punters.Pages
{
    public class CreatePunterModel : PageModel
    {
        #region Fields and Properties

        private readonly PunterDbContext _db;

        [TempData]
        public string Message { get; set; }

        [BindProperty]
        public Punter Punter { get; set; }

        #endregion

        public CreatePunterModel(PunterDbContext db)
        {
            _db = db;
        }

        #region Methods

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            try
            {
                string msg;
                var punterRepo = new PunterRepository(_db);
                var result = await punterRepo.SavePunter(Punter);
                if (result > 0)
                {
                    msg = $"Punter : {Punter.PunterName} successfully added!";
                }
                else
                {
                    msg = "PUT NICE ENGLISH MESSAGE HERE WHEN THE PUNTER DOESNT ADD";
                }

                Message = msg;

                // ADD LOG4NET
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                // ADD LOG4NET
            }

            return RedirectToPage("/Index");
        }

        #endregion
    }
}