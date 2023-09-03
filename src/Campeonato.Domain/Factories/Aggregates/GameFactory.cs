using Campeonato.Domain.Aggregates;

namespace Campeonato.Domain.Factories.Aggregates
{
    public static class GameFactory
    {
        public static Game Create(
            string id,
            string title,
            double score,
            int year,
            string urlImage
        )
        {
            return new(
                id,
                title,
                score,
                year,
                urlImage
            );
        }
    }
}