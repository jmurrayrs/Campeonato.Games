using AutoMapper;
using Campeonato.Application.Models;
using Campeonato.Domain.Aggregates;

namespace Campeonato.Application.Profiles
{
    public class GameProfile : Profile
    {
        public GameProfile()
        {
            CreateMap<GameModel, Game>()
                .ForMember(dest => dest.BussinessRules, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}