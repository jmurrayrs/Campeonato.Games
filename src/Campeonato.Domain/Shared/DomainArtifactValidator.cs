using FluentValidation;
using FluentValidation.Results;

namespace Campeonato.Domain.Shared
{
    public abstract class DomainArtifactValidator<TValidator, TDomainArtifact>
        where TValidator : IValidator<TDomainArtifact>
    {
        public ValidationResult BussinessRules { get; protected set; } = default!;

        public virtual void VerifyBussinessRules(
            TValidator validator,
            TDomainArtifact domainArtifact
        )
        {
            BussinessRules = validator.Validate(domainArtifact);
        }
    }
}