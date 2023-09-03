using Campeonato.Domain.Aggregates;

namespace Campeonato.Tests.UnitTests
{
    public class WorldCupTest
    {
        [Fact]
        public void ShouldCreateWorldCup()
        {
            var worldCup = new WorldCup(
                new List<Match>()
                {
                    new Match(
                        new Game(
                            "123456",
                            "teste 1",
                            123,
                            2000,
                            "imagem 1"
                        ),
                        new Game(
                            "456789",
                            "teste",
                            123,
                            2000,
                            "imagem"
                        )
                    ),
                    new Match(
                        new Game(
                            "987654",
                            "teste 5555",
                            123,
                            2000,
                            "imagem"
                        ),
                        new Game(
                            "456789",
                            "teste",
                            123,
                            2000,
                            "imagem"
                        )
                    )
                }
            );

            Assert.True(worldCup.BussinessRules.IsValid);
        }

        [Fact]
        public void ShouldValidateWorldCup()
        {
            var worldCup = new WorldCup(
                new List<Match>()
            );

            Assert.False(worldCup.BussinessRules.IsValid);
        }
    }
}