using FluentValidation;

namespace Campeonato.Domain.Aggregates.Validators;

public class MatchValidator
    : AbstractValidator<Match>
{
    public MatchValidator()
    {
        RuleFor(x => x.OpponentOne)
            .NotNull()
            .WithMessage("Game GameOpponent One is necessary");

        RuleFor(x => x.OpponentTwo)
            .NotNull()
            .WithMessage("Game GameOpponent Two is necessary");
    }
}
