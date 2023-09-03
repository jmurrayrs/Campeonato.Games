using Campeonato.Application.Models;
using Campeonato.Domain.Aggregates;

namespace Campeonato.Tests.Helpers
{
    public class GameHelper
    {
        private readonly Random _random = new();
        public IEnumerable<Game> GenerateRandomicGameList(int gameQuantitity = 8, bool sortListByName = false)
        {
            var gamelist = new List<Game>()
                {
                    new(
                        "/nintendo-64/the-legend-of-zelda-ocarina-of-time",
                        "The Legend of Zelda: Ocarina of Time (N64)",
                        99.9,
                        1998,
                        "https://l3-processoseletivo.azurewebsites.net/api/CapaJogo/nintendo-64/the-legend-of-zelda-ocarina-of-time"
                    ),
                    new (
                        "/playstation/tony-hawks-pro-skater-2",
                        "Tony Hawk's Pro Skater 2 (PS)",
                        98.9,
                        2000,
                        "https://l3-processoseletivo.azurewebsites.net/api/CapaJogo/playstation/tony-hawks-pro-skater-2"
                    ),
                    new(
                        "/playstation-3/grand-theft-auto-iv",
                        "Grand Theft Auto IV (PS3)",
                        98.9,
                        2008,
                        "https://l3-processoseletivo.azurewebsites.net/api/CapaJogo/playstation-3/grand-theft-auto-iv"
                    ),
                    new(
                        "/dreamcast/soulcalibur",
                        "SoulCalibur (DC)",
                        98.9,
                        1999,
                        "https://l3-processoseletivo.azurewebsites.net/api/CapaJogo/dreamcast/soulcalibur"
                    ),
                    new(
                        "/xbox-360/grand-theft-auto-iv",
                        "Grand Theft Auto IV (X360)",
                        98.9,
                        2008,
                        "https://l3-processoseletivo.azurewebsites.net/api/CapaJogo/xbox-360/grand-theft-auto-iv"
                    ),
                    new(
                        "/wii/super-mario-galaxy",
                        "Super Mario Galaxy (WII)",
                        97.9,
                        2007,
                        "https://l3-processoseletivo.azurewebsites.net/api/CapaJogo/wii/super-mario-galaxy"
                    ),
                    new(
                        "/wii/super-mario-galaxy-2",
                        "Super Mario Galaxy 2 (WII)",
                        97.9,
                        2010,
                        "https://l3-processoseletivo.azurewebsites.net/api/CapaJogo/wii/super-mario-galaxy-2"
                    ),
                    new(
                        "/xbox-one/red-dead-redemption-2",
                        "Red Dead Redemption 2 (XONE)",
                        97.9,
                        2018,
                        "https://l3-processoseletivo.azurewebsites.net/api/CapaJogo/xbox-one/red-dead-redemption-2"
                    ),
                    new(
                        "/xbox-one/grand-theft-auto-v",
                        "Grand Theft Auto V (XONE)",
                        97.9,
                        2014,
                        "https://l3-processoseletivo.azurewebsites.net/api/CapaJogo/xbox-one/grand-theft-auto-v"
                    ),
                    new(
                        "/playstation-3/grand-theft-auto-v",
                        "Grand Theft Auto V (PS3)",
                        97.9,
                        2013,
                        "https://l3-processoseletivo.azurewebsites.net/api/CapaJogo/playstation-3/grand-theft-auto-v"
                    ),
                    new(
                        "/xbox-360/grand-theft-auto-v",
                        "Grand Theft Auto V (X360)",
                        97.0,
                        2013,
                        "https://l3-processoseletivo.azurewebsites.net/api/CapaJogo/xbox-360/grand-theft-auto-v"
                    ),
                    new(
                        "/dreamcast/tony-hawks-pro-skater-2",
                        "Tony Hawk's Pro Skater 2 (DC)",
                        97.0,
                        2000,
                        "https://l3-processoseletivo.azurewebsites.net/api/CapaJogo/dreamcast/tony-hawks-pro-skater-2"
                    ),
                    new(
                        "/switch/the-legend-of-zelda-breath-of-the-wild",
                        "The Legend of Zelda: Breath of the Wild (Switch)",
                        97.8,
                        2017,
                        "https://l3-processoseletivo.azurewebsites.net/api/CapaJogo/switch/the-legend-of-zelda-breath-of-the-wild"
                    ),
                    new(
                        "/playstation-2/tony-hawks-pro-skater-3",
                        "Tony Hawk's Pro Skater 3 (PS2)",
                        97.8,
                        2001,
                        "https://l3-processoseletivo.azurewebsites.net/api/CapaJogo/playstation-2/tony-hawks-pro-skater-3"
                    ),
                    new(
                        "/nintendo-64/perfect-dark",
                        "Perfect Dark (N64)",
                        97.8,
                        2000,
                        "https://l3-processoseletivo.azurewebsites.net/api/CapaJogo/nintendo-64/perfect-dark"
                    ),
                    new(
                        "/playstation-4/red-dead-redemption-2",
                        "Red Dead Redemption 2 (PS4)",
                        97.8,
                        2018,
                        "https://l3-processoseletivo.azurewebsites.net/api/CapaJogo/playstation-4/red-dead-redemption-2"
                    ),
                    new(
                        "/playstation-4/grand-theft-auto-v",
                        "Grand Theft Auto V (PS4)",
                        97.8,
                        2014,
                        "https://l3-processoseletivo.azurewebsites.net/api/CapaJogo/playstation-4/grand-theft-auto-v"
                    ),
                    new(
                        "/game-cube/metroid-prime",
                        "Metroid Prime (GC)",
                        97.8,
                        2002,
                        "https://l3-processoseletivo.azurewebsites.net/api/CapaJogo/game-cube/metroid-prime"
                    )
                };

            return gamelist
                .OrderBy(item => _random.Next())
                .Take(gameQuantitity)
                .OrderBy(item => sortListByName ? item.Title : "")
                .ToList();
        }

        public IEnumerable<GameModel> GenerateRandomicGameModelList(int gameQuantitity = 8, bool sortListByName = false)
        {
            var gamelist = new List<GameModel>()
                {
                    new (
                        "/nintendo-64/the-legend-of-zelda-ocarina-of-time",
                        "The Legend of Zelda: Ocarina of Time (N64)",
                        99.9,
                        1998,
                        "https://l3-processoseletivo.azurewebsites.net/api/CapaJogo/nintendo-64/the-legend-of-zelda-ocarina-of-time"
                    ),
                    new (
                        "/playstation/tony-hawks-pro-skater-2",
                        "Tony Hawk's Pro Skater 2 (PS)",
                        98.9,
                        2000,
                        "https://l3-processoseletivo.azurewebsites.net/api/CapaJogo/playstation/tony-hawks-pro-skater-2"
                    ),
                    new(
                        "/playstation-3/grand-theft-auto-iv",
                        "Grand Theft Auto IV (PS3)",
                        98.9,
                        2008,
                        "https://l3-processoseletivo.azurewebsites.net/api/CapaJogo/playstation-3/grand-theft-auto-iv"
                    ),
                    new(
                        "/dreamcast/soulcalibur",
                        "SoulCalibur (DC)",
                        98.9,
                        1999,
                        "https://l3-processoseletivo.azurewebsites.net/api/CapaJogo/dreamcast/soulcalibur"
                    ),
                    new(
                        "/xbox-360/grand-theft-auto-iv",
                        "Grand Theft Auto IV (X360)",
                        98.9,
                        2008,
                        "https://l3-processoseletivo.azurewebsites.net/api/CapaJogo/xbox-360/grand-theft-auto-iv"
                    ),
                    new(
                        "/wii/super-mario-galaxy",
                        "Super Mario Galaxy (WII)",
                        97.9,
                        2007,
                        "https://l3-processoseletivo.azurewebsites.net/api/CapaJogo/wii/super-mario-galaxy"
                    ),
                    new(
                        "/wii/super-mario-galaxy-2",
                        "Super Mario Galaxy 2 (WII)",
                        97.9,
                        2010,
                        "https://l3-processoseletivo.azurewebsites.net/api/CapaJogo/wii/super-mario-galaxy-2"
                    ),
                    new(
                        "/xbox-one/red-dead-redemption-2",
                        "Red Dead Redemption 2 (XONE)",
                        97.9,
                        2018,
                        "https://l3-processoseletivo.azurewebsites.net/api/CapaJogo/xbox-one/red-dead-redemption-2"
                    ),
                    new(
                        "/xbox-one/grand-theft-auto-v",
                        "Grand Theft Auto V (XONE)",
                        97.9,
                        2014,
                        "https://l3-processoseletivo.azurewebsites.net/api/CapaJogo/xbox-one/grand-theft-auto-v"
                    ),
                    new(
                        "/playstation-3/grand-theft-auto-v",
                        "Grand Theft Auto V (PS3)",
                        97.9,
                        2013,
                        "https://l3-processoseletivo.azurewebsites.net/api/CapaJogo/playstation-3/grand-theft-auto-v"
                    ),
                    new(
                        "/xbox-360/grand-theft-auto-v",
                        "Grand Theft Auto V (X360)",
                        97.0,
                        2013,
                        "https://l3-processoseletivo.azurewebsites.net/api/CapaJogo/xbox-360/grand-theft-auto-v"
                    ),
                    new(
                        "/dreamcast/tony-hawks-pro-skater-2",
                        "Tony Hawk's Pro Skater 2 (DC)",
                        97.0,
                        2000,
                        "https://l3-processoseletivo.azurewebsites.net/api/CapaJogo/dreamcast/tony-hawks-pro-skater-2"
                    ),
                    new(
                        "/switch/the-legend-of-zelda-breath-of-the-wild",
                        "The Legend of Zelda: Breath of the Wild (Switch)",
                        97.8,
                        2017,
                        "https://l3-processoseletivo.azurewebsites.net/api/CapaJogo/switch/the-legend-of-zelda-breath-of-the-wild"
                    ),
                    new(
                        "/playstation-2/tony-hawks-pro-skater-3",
                        "Tony Hawk's Pro Skater 3 (PS2)",
                        97.8,
                        2001,
                        "https://l3-processoseletivo.azurewebsites.net/api/CapaJogo/playstation-2/tony-hawks-pro-skater-3"
                    ),
                    new(
                        "/nintendo-64/perfect-dark",
                        "Perfect Dark (N64)",
                        97.8,
                        2000,
                        "https://l3-processoseletivo.azurewebsites.net/api/CapaJogo/nintendo-64/perfect-dark"
                    ),
                    new(
                        "/playstation-4/red-dead-redemption-2",
                        "Red Dead Redemption 2 (PS4)",
                        97.8,
                        2018,
                        "https://l3-processoseletivo.azurewebsites.net/api/CapaJogo/playstation-4/red-dead-redemption-2"
                    ),
                    new(
                        "/playstation-4/grand-theft-auto-v",
                        "Grand Theft Auto V (PS4)",
                        97.8,
                        2014,
                        "https://l3-processoseletivo.azurewebsites.net/api/CapaJogo/playstation-4/grand-theft-auto-v"
                    ),
                    new(
                        "/game-cube/metroid-prime",
                        "Metroid Prime (GC)",
                        97.8,
                        2002,
                        "https://l3-processoseletivo.azurewebsites.net/api/CapaJogo/game-cube/metroid-prime"
                    )
                };

            return gamelist
                .OrderBy(item => _random.Next())
                .Take(gameQuantitity)
                .OrderBy(item => sortListByName ? item.Title : "")
                .ToList();
        }
    }
}