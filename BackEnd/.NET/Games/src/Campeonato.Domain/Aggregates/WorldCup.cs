using Campeonato.Domain.Aggregates.Validators;
using Campeonato.Domain.Shared;

namespace Campeonato.Domain.Aggregates;

public class WorldCup
    : DomainArtifactValidator<WorldCupValidator, WorldCup>
{
    private readonly List<Match> _matches = new();
    private readonly List<Confrontation> _confrontations = new();
    public IReadOnlyCollection<Match> Matches => _matches.AsReadOnly();
    public IReadOnlyCollection<Confrontation> Confrontations => _confrontations.AsReadOnly();

    public WorldCup()
    { }

    public WorldCup(IEnumerable<Match> matches)
    {
        _matches = matches.ToList();

        VerifyBussinessRules(new WorldCupValidator(), this);
    }

    public void AddConfrontations(IEnumerable<Confrontation> confrontations)
        => _confrontations.AddRange(confrontations);
}


