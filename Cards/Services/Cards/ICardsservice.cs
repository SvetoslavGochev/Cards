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

        Task<Tuple<bool, string>> Create(CardCollectionFormModel card, string userId);

        Task<Tuple<bool, List<CardCollectionFormModel>>> All();

        Task<Tuple<bool, List<Card>>> MyCollection(string userId);

        Card GetCard(string cardId);

        bool Delete(Card card);
    }
}
