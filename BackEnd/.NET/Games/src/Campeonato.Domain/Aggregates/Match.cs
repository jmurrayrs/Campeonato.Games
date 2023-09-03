using Campeonato.Domain.Aggregates.Validators;
using Campeonato.Domain.Enums;
using Campeonato.Domain.Shared;

namespace Campeonato.Domain.Aggregates;

public sealed class Match
{
    public Game OpponentOne { get; private set; } = default!;
    public Game OpponentTwo { get; private set; } = default!;
    public Game Winner { get; private set; } = default!;
    public EnumWinConditions WinConditions { get; private set; }

    public Match()
    { }

    public Match(
        Game opponentOne,
        Game opponentTwo
    )
    {
        OpponentOne = opponentOne;
        OpponentTwo = opponentTwo;
    }
    public void StartMatch()
    {
        DisputeBetweenScores();
    }

    private void DisputeBetweenScores()
    {
        if (OpponentOne.Score > OpponentTwo.Score)
            Winner = OpponentOne;
        else if (OpponentOne.Score == OpponentTwo.Score)
        {
            DisputeBetweenYears();
            return;
        }
        else
            Winner = OpponentTwo;

        WinConditions = EnumWinConditions.DisputeBetweenScores;
    }

    private void DisputeBetweenYears()
    {
        if (OpponentOne.Year > OpponentTwo.Year)
            Winner = OpponentOne;
        else if (OpponentOne.Year == OpponentTwo.Year)
        {
            DisputeByName();
            return;
        }
        else
            Winner = OpponentTwo;

        WinConditions = EnumWinConditions.DisputeBetweenYears;
    }

    private void DisputeByName()
    {
        int result = string.Compare(OpponentOne.Title, OpponentTwo.Title, StringComparison.OrdinalIgnoreCase);

        Winner = result < 0 ? OpponentOne : OpponentTwo;

        WinConditions = EnumWinConditions.DisputeByName;
    }

}
