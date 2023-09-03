using Campeonato.Domain.Aggregates;

namespace Campeonato.Domain.Factories.Aggregates
{
    public static class WorldCupFactory
    {
        public static WorldCup Create(
            IEnumerable<Match> Matches
        )
            => new(Matches);
    }
}