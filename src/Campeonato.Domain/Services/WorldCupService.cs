using Campeonato.Domain.Aggregates;
using Campeonato.Domain.Factories.Aggregates;
using Campeonato.Domain.Interfaces.Services;
using Campeonato.Domain.Services.Validators;
using Campeonato.Domain.Shared;
using FluentValidation.Results;

namespace Campeonato.Domain.Services;

public sealed class WorldCupService
    : DomainArtifactValidator<WorldCupServiceValidator, WorldCupService>, IWorldCupService
{
    private List<Game> _games = new();
    private readonly List<Confrontation> _confrontations = new();
    public IReadOnlyCollection<Game> Games => _games.AsReadOnly();
    public WorldCup WorldCup { get; private set; } = default!;

    public void GenerateAndPlayWorldCup(IEnumerable<Game> games)
    {
        _games = games.ToList();

        VerifyBussinessRules(new WorldCupServiceValidator(), this);

        if (BussinessRules.IsValid)
        {
            var matches = new List<Match>();

            var gameList = _games.OrderBy(x => x.Title).ToList();

            while (gameList.Count > 0)
            {

                var match = MatchFactory.Create(
                        gameList.First(),
                        gameList.Last()
                );

                matches.Add(match);
                gameList.Remove(gameList.First());
                gameList.Remove(gameList.Last());
            }

            var worldCup = WorldCupFactory.Create(matches);

            if (worldCup.BussinessRules.IsValid)
                StartConfrontations(worldCup.Matches);
            else
                BussinessRules.Errors.AddRange(worldCup.BussinessRules.Errors);

            worldCup.AddConfrontations(_confrontations);

            WorldCup = worldCup;
        }
    }

    private IEnumerable<Confrontation> StartConfrontations(IEnumerable<Match> matches, int phaseCount = 1)
    {
        string phaseName;

        if (matches.Count() == 1)
            phaseName = "Final";
        else if (matches.Count() == 2)
            phaseName = "Semifinals";
        else if (matches.Count() == 4)
            phaseName = "Quarterfinals";
        else
            phaseName = $"Phase {phaseCount}";

        var winnerGames = new List<Game>();

        foreach (var match in matches)
        {
            match.StartMatch();
            winnerGames.Add(match.Winner);
        }

        _confrontations.Add(ConfrontationFactory.Create(phaseName, matches));

        if (winnerGames.Count > 1)
        {
            var nextMatches = NextMatches(winnerGames);
            StartConfrontations(nextMatches, phaseCount++);
        }

        return _confrontations;
    }

    private static IEnumerable<Match> NextMatches(List<Game> games)
    {
        var listGames = games;

        var nextMatches = new List<Match>();

        while (listGames.Count > 0)
        {
            var nextMatchGames = listGames.Take(2);

            nextMatches.Add(MatchFactory.Create(
                    nextMatchGames.First(),
                    nextMatchGames.Last()
                )
            );
            listGames.Remove(nextMatchGames.First());
            listGames.Remove(nextMatchGames.Last());
        }

        return nextMatches;
    }
    public ValidationResult GetBussinessRules()
        => BussinessRules;
}
