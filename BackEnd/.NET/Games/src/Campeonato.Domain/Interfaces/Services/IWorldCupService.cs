using Campeonato.Domain.Aggregates;
using FluentValidation.Results;

namespace Campeonato.Domain.Interfaces.Services;

public interface IWorldCupService
{
    WorldCup WorldCup { get; }
    IReadOnlyCollection<Game> Games { get; }
    void GenerateAndPlayWorldCup(IEnumerable<Game> games);
    ValidationResult GetBussinessRules();

}