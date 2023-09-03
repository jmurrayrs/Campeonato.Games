using FluentValidation;

namespace Campeonato.Domain.Aggregates.Validators
{
    public sealed class WorldCupValidator
        : AbstractValidator<WorldCup>
    {
        public WorldCupValidator()
        {
            RuleFor(x => x.Matches)
                .Must(x => x.Count > 0)
                .WithMessage("It's necessary Matches. Please check if the games were created.");

            RuleFor(x => x.Matches)
                .Must(x => x.Count % 2 == 0)
                .WithMessage("It takes more times to create a World Cup. This quantity must be a multiple of four.");
        }
    }
}