namespace Cards.Infrastructure
{
    using AutoMapper;
    using Cards.Data.Models;
    using Cards.Models.Collection;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<CardCollectionFormModel, Card>()
                .ReverseMap();
                

        }
    }
}
