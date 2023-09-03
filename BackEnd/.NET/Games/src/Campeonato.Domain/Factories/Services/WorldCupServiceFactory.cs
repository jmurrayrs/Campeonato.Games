using Campeonato.Domain.Aggregates;
using Campeonato.Domain.Services;

namespace Campeonato.Domain.Factories.Services
{
    public static class WorldCupServiceFactory
    {
        public static WorldCupService Create()
            => new();

    }
}