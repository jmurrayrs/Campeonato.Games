using AutoMapper;
using Campeonato.Application.Models;
using Campeonato.Domain.Aggregates;

namespace Campeonato.Application.Profiles
{
    public class ConfrontarionProfile : Profile
    {
        public ConfrontarionProfile()
        {
            CreateMap<ConfrontationModel, Confrontation>()
                .ReverseMap();
        }
    }
}