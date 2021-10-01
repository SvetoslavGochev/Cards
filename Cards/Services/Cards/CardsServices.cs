
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Cards.Data;
using Cards.Data.Models;
using Cards.Models.Collection;
using Cards.Services.Cards;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;

namespace Cards.Services
{

    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    public class CardsServices : Controller, ICardsservice
    {
        private readonly ApplicationDbContext data;
        private readonly IMapper mapper;
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signManager;
        public CardsServices(ApplicationDbContext data,
            IMapper mapper,
            UserManager<User> userManager,
            SignInManager<User> signManager)
        {
            this.data = data;
            this.mapper = mapper;
            this.userManager = userManager;
            this.signManager = signManager;
        }

        public IEnumerable<CardCollectionFormModel> All()
        {
            return this.data
                    .Cards.ProjectTo<CardCollectionFormModel>(this.mapper.ConfigurationProvider)
                    .ToList();
        }

        public IEnumerable<Card> Collection(string userId)
        {

            var colectionId = this.data
                .UsersCards
                .Where(c => c.UserId == userId)
                .Select(u => u.CardId)
                .ToList();

            var myCards = new List<Card>();

            foreach (var cardId in colectionId)
            {
                var myCard = this.data
                 .Cards
                 .Where(c => c.Id == cardId)
                 .FirstOrDefault();

                myCards.Add(myCard);
            }

            return myCards;
        }

        public async Task Create(CardCollectionFormModel card, string userId)
        {
            var newcard = new Card
            {
                Name = card.Name,
                ImageUrl = card.Image,
                Attack = card.Attack,
                Health = card.Health,
                Description = card.Description,
                Keyword = card.Keyword
            };


            await this.data.Cards.AddAsync(newcard);

            await this.data.UsersCards.AddAsync(new UserCard
            {
                UserId = userId,
                CardId = newcard.Id
            });
            await this.data.SaveChangesAsync();
        }

        public bool Delete(Card card)
        {
            try
            {
                this.data.Cards.Remove(card);

                this.data.SaveChanges();

            }
            catch (System.Exception)
            {

                return false;
            }

            return true;
        }

        public Card GetCard(string cardId)
             => this.data.Cards
                .FirstOrDefault(c => c.Id == cardId);




    }
}
