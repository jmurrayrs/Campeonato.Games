using Campeonato.Application.JsonContracts;
using Newtonsoft.Json;

namespace Campeonato.Application.JsonResolver
{
    public static class WorldCupResolver
    {
        public static JsonSerializerSettings ResolveSerialization(
            string fieldToIgnoreSerialization
        )
        {
            return new JsonSerializerSettings
            {
                ContractResolver = new IgnorePropertiesContractResolver(fieldToIgnoreSerialization),
                Formatting = Formatting.Indented
            };
        }
    }
}