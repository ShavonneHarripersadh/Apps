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
    public class CreateMarketsModel : PageModel
    {
        #region Context and Properties
        private readonly PunterDbContext _db;

        [TempData]
        public string Message { get; set; }

        [BindProperty]
        public Market Market { get; set; }
        #endregion

        public CreateMarketsModel(PunterDbContext db)
        {
            _db = db;           
        }

        #region Methods
        public async Task<IActionResult> OnPostAsync()
        {       
            try
            {
                if (!ModelState.IsValid)
                {
                    return Page();
                }
                MarketRepository repo = new MarketRepository(_db);
                var Add =await repo.SaveMarket(Market);
                var msg = $"Market : {Market.MarketName} added!";
                Message = msg;                
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
            return RedirectToPage("/Markets");
        }
        #endregion
    }
}