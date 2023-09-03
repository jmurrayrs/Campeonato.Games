using AutoMapper;
using AutoMapper.Extensions.EnumMapping;
using Campeonato.Application.Enums;
using Campeonato.Application.Models;
using Campeonato.Domain.Aggregates;
using Campeonato.Domain.Enums;

namespace Campeonato.Application.Profiles
{
    public class WorldCupProfile : Profile
    {
        public WorldCupProfile()
        {
            CreateMap<WorldCupModel, WorldCup>()
                .ReverseMap();

            CreateMap<EnumWinConditionsModel, EnumWinConditions>()
                .ConvertUsingEnumMapping(opt => opt.MapByName())
                .ReverseMap();
        }
    }
}