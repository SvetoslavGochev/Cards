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
        private readonly ICardsservice cardsService;

        public CardsController(SignInManager<User> signManager, UserManager<User> userManager, ICardsservice cardsservice)
        {
            this.signManager = signManager;
            this.userManager = userManager;
            this.cardsService = cardsservice;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> All()
        {

            return this.View(this.cardsService.All());
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Add(CardCollectionFormModel card)
        {
            if (!ModelState.IsValid)
            {
                return View(card);
            }
            var userId = this.userManager.GetUserId(this.User);

            await this.cardsService.Create(card, userId);

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Collection()
        {
            var userId = this.userManager.GetUserId(this.User);


            return this.View(this.cardsService.Collection(userId));
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> RemoveFromCollection(string cardId)
        {
            if (cardId == null)
            {
                return NotFound();
            }

            var car = this.cardsService.GetCard(cardId);

            if (car == null)
            {
                return NotFound();
            }
            var carDelete = this.cardsService.Delete(car);

            if (!carDelete)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Collection));

        }



    }
}
