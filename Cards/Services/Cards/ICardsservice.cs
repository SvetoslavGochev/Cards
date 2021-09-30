using Cards.Models.Collection;
using System.Threading.Tasks;

namespace Cards.Services.Cards
{


    public interface ICardsservice
    {
        Task Create(AddCardCollectionFormModel card);
    }
}
