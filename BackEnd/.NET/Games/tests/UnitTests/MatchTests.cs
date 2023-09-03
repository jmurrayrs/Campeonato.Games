using Campeonato.Domain.Aggregates;
using Campeonato.Tests.Helpers;

namespace Campeonato.Tests.UnitTests;

public class MatchTests
{
    [Fact]
    public void ShoulGenerateAmatch()
    {
        var games = new GameHelper().GenerateRandomicGameList(2);

        var match = new Match(
            games.ElementAt(0),
            games.ElementAt(1)
        );

        Assert.Equal(match.OpponentOne, games.ElementAt(0));
        Assert.Equal(match.OpponentTwo, games.ElementAt(1));
    }


}
