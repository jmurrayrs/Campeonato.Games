using Campeonato.Domain.Aggregates;

namespace Campeonato.Tests.UnitTests;
public class GameTest
{
    [Theory]
    [InlineData("/nintendo-64/the-legend-of-zelda-ocarina-of-time",
                "The Legend of Zelda: Ocarina of Time (N64)",
                99.9,
                1998,
                "https://l3-processoseletivo.azurewebsites.net/api/CapaJogo/nintendo-64/the-legend-of-zelda-ocarina-of-time")]
    public void ShouldCreateAGame(
        string id,
        string title,
        double score,
        int year,
        string urlImage)
    {
        var game = new Game(id,
                            title,
                            score,
                            year,
                            urlImage);


        Assert.True(
            game.Id == id &&
            game.Title == title &&
            game.Score == score &&
            game.Year == year &&
            game.UrlImage == urlImage &&
            game.BussinessRules.IsValid);
    }

    [Theory]
    [InlineData("", "", 0, 0, "")]
    [InlineData(null, null, -1, -1, null)]

    public void ShoulValidateGame(
        string id,
        string title,
        double score,
        int year,
        string urlImage)
    {
        var game = new Game(id,
                            title,
                            score,
                            year,
                            urlImage);

        Assert.False(game.BussinessRules.IsValid);
    }
}
