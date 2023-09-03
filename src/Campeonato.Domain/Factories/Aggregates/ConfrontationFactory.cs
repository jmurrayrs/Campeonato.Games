using Campeonato.Domain.Aggregates;

namespace Campeonato.Domain.Factories.Aggregates
{
    public static class ConfrontationFactory
    {
        public static Confrontation Create(
            string phaseName,
            IEnumerable<Match> matches
        ) => new(phaseName, matches);
    }
}