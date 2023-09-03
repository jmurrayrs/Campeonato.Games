using Campeonato.Application.JsonResolver;
using Campeonato.Application.Models;
using Campeonato.Domain.Aggregates;
using Newtonsoft.Json;

namespace Campeonato.Application.Commands
{
    public sealed class GenerateWorldCupCommandResult
    {

        public WorldCupModel WorldCup { get; private set; }

        public GenerateWorldCupCommandResult(WorldCupModel worldCup)
        {
            WorldCup = worldCup;

            JsonConvert.SerializeObject(
                WorldCup,
                Formatting.Indented
            );
        }
    }
}