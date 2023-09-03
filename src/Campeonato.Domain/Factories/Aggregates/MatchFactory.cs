using Campeonato.Domain.Aggregates;

namespace Campeonato.Domain.Factories.Aggregates;

public static class MatchFactory
{
    public static Match Create(
        Game OpponentOne,
        Game OpponentTwo
    )
        => new(
            OpponentOne,
            OpponentTwo
        );
}