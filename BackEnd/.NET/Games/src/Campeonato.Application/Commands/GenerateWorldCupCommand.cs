using Campeonato.Application.Models;
using MediatR;

namespace Campeonato.Application.Commands
{
    public class GenerateWorldCupCommand
        : IRequest<GenerateWorldCupCommandResult>
    {
        public IEnumerable<GameModel> Games { get; set; } = default!;
    }
}