using FluentValidation;

namespace Campeonato.Domain.Aggregates.Validators;

public sealed class GameValidator
    : AbstractValidator<Game>
{
    public GameValidator()
    {
        RuleFor(x => x.Id)
            .NotNull()
            .NotEmpty()
            .WithMessage("Id is necessary");

        RuleFor(x => x.Score)
            .NotNull()
            .GreaterThan(0)
            .WithMessage("Score is necessary");

        RuleFor(x => x.Title)
            .NotNull()
            .NotEmpty()
            .WithMessage("Title is necessary");

        RuleFor(x => x.Year)
            .NotNull()
            .GreaterThan(0)
            .WithMessage("Year is necessary");
    }
}
