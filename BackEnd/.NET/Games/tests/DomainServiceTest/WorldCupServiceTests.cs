using Campeonato.Domain.Aggregates;
using Campeonato.Domain.Factories.Services;
using Campeonato.Tests.Helpers;

namespace Campeonato.Tests.DomainServiceTest
{
    public class WorldCupServiceTests
    {
        [Fact]
        public void ShouldCreateWorldCupWithFourMatches()
        {
            var games = new GameHelper().GenerateRandomicGameList(sortListByName: true);

            var worldCupService = WorldCupServiceFactory.Create();

            worldCupService.GenerateAndPlayWorldCup(games);

            Assert.True(worldCupService.BussinessRules.IsValid);

            Assert.True(worldCupService.WorldCup.Matches.Count == 4);

            Assert.True(VerifyGamesInMatches(
                games,
                worldCupService.WorldCup.Matches
            ));
        }

        [Fact]
        public void ShouldValidateWorldCupService()
        {
            var games = new GameHelper().GenerateRandomicGameList(7);

            var worldCupService = WorldCupServiceFactory.Create();

            worldCupService.GenerateAndPlayWorldCup(games);

            Assert.False(worldCupService.BussinessRules.IsValid);

        }

        [Theory]
        [InlineData(8)]
        [InlineData(16)]
        public void ShouldCreateMatchesWithMultiplesOfEight(int gameQuantitity)
        {
            var games = new GameHelper().GenerateRandomicGameList(gameQuantitity);

            var MatchesCount = gameQuantitity / 2;

            var worldCupService = WorldCupServiceFactory.Create();

            worldCupService.GenerateAndPlayWorldCup(games);

            Assert.True(worldCupService.BussinessRules.IsValid);
            Assert.True(worldCupService.WorldCup.Matches.Count == MatchesCount);
            Assert.True(games.Count() == gameQuantitity);

        }
        private static bool VerifyGamesInMatches(
            IEnumerable<Game> games,
            IEnumerable<Match> Matches
        )
        {
            var matchList = Matches.ToList();
            var gameList = games.ToList();

            while (gameList.Count > 0)
            {

                var match = matchList.First();

                if (match.OpponentOne != gameList.First() &&
                    match.OpponentTwo != gameList.Last())
                    return false;

                gameList.Remove(gameList.First());
                gameList.Remove(gameList.Last());
                matchList.Remove(match);
            }
            return true;
        }
    }
}