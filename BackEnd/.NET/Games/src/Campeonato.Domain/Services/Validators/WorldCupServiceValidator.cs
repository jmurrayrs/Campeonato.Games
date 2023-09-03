using FluentValidation;

namespace Campeonato.Domain.Services.Validators
{
    public class WorldCupServiceValidator
        : AbstractValidator<WorldCupService>
    {
        public WorldCupServiceValidator()
        {
            RuleFor(x => x.Games)
                .Must(games => games.Count >= 8)
                .WithMessage("The rules of this e-sports world cup require that there be a minimum of 8 games.");

            RuleFor(x => x.Games)
                .Must(games => games.Count % 8 == 0)
                .WithMessage("For this World Cup, it is necessary to have the number of teams be a multiple of eight.");
        }
    }
}