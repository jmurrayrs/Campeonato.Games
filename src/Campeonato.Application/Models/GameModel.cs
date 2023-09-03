namespace Campeonato.Application.Models;
public class GameModel
{
    public string Id { get; set; } = default!;
    public string Title { get; set; } = default!;
    public string UrlImage { get; set; } = default!;
    public double Score { get; set; }
    public int Year { get; set; }

    public GameModel() { }
    public GameModel(
        string id,
        string title,
        double score,
        int year,
        string urlImage
    )
    {
        Id = id;
        Title = title;
        UrlImage = urlImage;
        Score = score;
        Year = year;
    }

}