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
    public class AddBetModel : PageModel
    {
        private readonly PunterDbContext _db;

        public AddBetModel(PunterDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Bet Bet { get; set; }

        public Market Market;
        public Punter punt = Pages.PlaceBetModel.Punts;

        public async Task<IActionResult> OnPostAsync(int id)
        {
            Market = await _db.Market.FromSql($"ReadMarketByID {id}").FirstOrDefaultAsync();

            if (!ModelState.IsValid)
            {
                return Page();
            }
       
            Bet.PotentialPayout = Bet.Stake + Bet.Stake * Market.Odds;
            if (Pages.PlaceBetModel.Punts.Balance < Bet.Stake)
            {
                RedirectToPage("./AddBetModel");
            }
            else
            {
                BetsRepository repo = new BetsRepository(_db);
                var add = await repo.SaveBet(Bet, Market, punt);
            }
            return RedirectToPage("./PlaceBet");
        }

    }
}