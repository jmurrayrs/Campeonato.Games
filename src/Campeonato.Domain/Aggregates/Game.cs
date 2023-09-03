using Campeonato.Domain.Aggregates.Validators;
using Campeonato.Domain.Shared;

namespace Campeonato.Domain.Aggregates;
public sealed class Game
    : DomainArtifactValidator<GameValidator, Game>
{
    public string Id { get; private set; } = default!;
    public string Title { get; private set; } = default!;
    public string UrlImage { get; private set; } = default!;
    public double Score { get; private set; }
    public int Year { get; private set; }

    public Game()
    { }
    public Game(
        string id,
        string title,
        double score,
        int year,
        string urlImage
    )
    {
        Id = id;
        Title = title;
        Score = score;
        Year = year;
        UrlImage = urlImage;

        VerifyBussinessRules(new GameValidator(), this);
    }


}
