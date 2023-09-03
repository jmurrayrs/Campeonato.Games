using AutoMapper;
using Campeonato.Application.Models;
using Campeonato.Domain.Aggregates;

namespace Campeonato.Application.Profiles
{
    public class MatchProfile : Profile
    {
        public MatchProfile()
        {
            CreateMap<MatchModel, Match>()
                .ReverseMap();
        }
    }
}