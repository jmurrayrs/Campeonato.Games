using AutoMapper;
using Campeonato.Application.Models;
using Campeonato.Domain.Aggregates;
using Campeonato.Domain.Interfaces.Services;
using MediatR;
using Notificator.Interfaces;

namespace Campeonato.Application.Commands
{
    public class GenerateWorldCupCommandHandler
        : IRequestHandler<GenerateWorldCupCommand, GenerateWorldCupCommandResult>
    {
        private readonly IWorldCupService _worldCupService;
        private readonly IMapper _mapper;
        private readonly INotificationContext _notificationContext;

        public GenerateWorldCupCommandHandler(
            IWorldCupService worldCupService,
            IMapper mapper,
            INotificationContext notificationContext
        )
        {
            _worldCupService = worldCupService;
            _mapper = mapper;
            _notificationContext = notificationContext;
        }

        public async Task<GenerateWorldCupCommandResult> Handle(
            GenerateWorldCupCommand request,
            CancellationToken cancellationToken
        )
        {
            IEnumerable<Game> games = _mapper.Map<GameModel[], IEnumerable<Game>>(request.Games.ToArray());

            _worldCupService.GenerateAndPlayWorldCup(games);

            var bussinesRules = _worldCupService.GetBussinessRules();

            if (bussinesRules.IsValid)
            {
                return await Task.Run(
                    () =>
                    {
                        var model = _mapper.Map<WorldCup, WorldCupModel>(_worldCupService.WorldCup);
                        return new GenerateWorldCupCommandResult(model);
                    }
                );
            }
            else
            {
                await _notificationContext.AddNotificationsAsync(
                    bussinesRules.Errors.Select(x => x.ErrorMessage).ToList()
                );

                return default;
            }



        }
    }
}