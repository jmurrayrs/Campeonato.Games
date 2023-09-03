namespace Campeonato.Application.Models;

public class WorldCupModel
{
    public IEnumerable<MatchModel> Matches { get; set; } = default!;
    public IEnumerable<ConfrontationModel> Confrontations { get; set; } = default!;

}


