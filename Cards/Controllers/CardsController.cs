namespace Cards.Controllers
{
    using Cards.Data.Models;
    using Cards.Models.Collection;
    using Cards.Services.Cards;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class CardsController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signManager;
        private readonly ICardsservice cardsservice;

        public CardsController(SignInManager<User> signManager, UserManager<User> userManager, ICardsservice cardsservice)
        {
            this.signManager = signManager;
            this.userManager = userManager;
            this.cardsservice = cardsservice;
        }


        [HttpGet]
        public async Task<IActionResult> All()
        {

            return this.View();
        } 
        [HttpGet]
        public async Task<IActionResult> Add()
        {

            return this.View();
        }


        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Add(AddCardCollectionFormModel card)
        {
            if (!ModelState.IsValid)
            {
                return View(card);
            }

           await this.cardsservice.Create(card);

            return RedirectToAction(nameof(All));
        }
    
    }
}
