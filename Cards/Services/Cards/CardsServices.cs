
using Cards.Data;
using Cards.Data.Models;
using Cards.Models.Collection;
using Cards.Services.Cards;
using System.Threading.Tasks;

namespace Cards.Services
{


    public class CardsServices : ICardsservice
    {
        private readonly ApplicationDbContext data;

        public CardsServices(ApplicationDbContext data)
        {
            this.data = data;
        }

        public async Task Create(AddCardCollectionFormModel card)
        {
            var newcard = new Card
            {
                Name = card.Name,
                Description = card.Description,
                Attack = card.Attack,
                Health = card.Health,
                ImageUrl = card.ImageUrl,
                Keyword = card.Keyword,
            };

            await this.data.AddAsync(newcard);
            await this.data.SaveChangesAsync();
        }
    }
}
