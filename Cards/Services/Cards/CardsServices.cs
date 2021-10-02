

using AutoMapper;
using AutoMapper.QueryableExtensions;
using Cards.Data;
using Cards.Data.Models;
using Cards.Models.Collection;
using Cards.Services.Cards;
using System.Collections.Generic;

namespace Cards.Services
{

    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public class CardsServices : ICardsservice
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

        public async Task<Tuple<bool, List<CardCollectionFormModel>>> All()
        {
            try
            {
                var result = await this.data
                       .Cards.ProjectTo<CardCollectionFormModel>(this.mapper.ConfigurationProvider)
                       .ToListAsync();

                return Tuple.Create(true, result);
            }
            catch (Exception ex)
            {

                return Tuple.Create(false, new List<CardCollectionFormModel>());
            }


        }

        public async Task<Tuple<bool, string>> Create(CardCollectionFormModel card, string userId)
        {

            try
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

                return Tuple.Create(true, "Suucefuly create new card");
            }
            catch (Exception ex)
            {

                return Tuple.Create(false, ex.Message);
            }
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

        public async Task<Tuple<bool, string>> GetKards(CardCollectionFormModel card, string userId)
        {

            try
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

                return Tuple.Create(true, "Successfully add a new Location");

            }
            catch (Exception ex)
            {

                return Tuple.Create(false, ex.Message);
            }
        }

        public async Task<Tuple<bool, List<Card>>> MyCollection(string userId)
        {
            var colectionId = this.data
                .UsersCards
                .Where(c => c.UserId == userId)
                .Select(u => u.CardId)
                .ToList();

            if (colectionId != null)
            {

                var myCards = new List<Card>();

                foreach (var cardId in colectionId)
                {
                    var myCard = await this.data
                     .Cards
                     .FirstOrDefaultAsync(c => c.Id == cardId);


                    myCards.Add(myCard);
                }

                return Tuple.Create(true, myCards);
            }

            return Tuple.Create(false, new List<Card>());
        }


    }
}
