using Cards.Data.Models;
using Cards.Models.Collection;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cards.Services.Cards
{


    public interface ICardsservice
    {
        Task<Tuple<bool, string>> GetKards(CardCollectionFormModel cards, string userId);



        Task Create(CardCollectionFormModel card, string userId);
        IEnumerable<CardCollectionFormModel> All();
        IEnumerable<Card> Collection(string userId);

        Card GetCard(string cardId);

        bool Delete(Card card);
    }
}
