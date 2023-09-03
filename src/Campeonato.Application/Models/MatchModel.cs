using Campeonato.Application.Enums;

namespace Campeonato.Application.Models;
public sealed class MatchModel
{
    public GameModel OpponentOne { get; private set; } = default!;
    public GameModel OpponentTwo { get; private set; } = default!;
    public GameModel Winner { get; private set; } = default!;
    public EnumWinConditionsModel WinConditions { get; private set; } = default!;

}
