namespace Campeonato.Application.Models;
public class ConfrontationModel
{
    public string PhaseName { get; set; } = default!;
    public IEnumerable<MatchModel> Matches { get; set; } = default!;
}
