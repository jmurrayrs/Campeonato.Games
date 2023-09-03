using Campeonato.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Notificator.Interfaces;

namespace Campeonato.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WorldCupController : ControllerBase
    {

        private readonly IMediator _mediator;
        private readonly INotificationContext _notificationContext;

        public WorldCupController(
            IMediator mediator,
            INotificationContext notificationContext
        )
        {
            _mediator = mediator;
            _notificationContext = notificationContext;
        }

        [HttpPost("/create")]
        public async Task<JsonResult> Post(GenerateWorldCupCommand command)
        {
            var response = await _mediator.Send(command);

            if (_notificationContext.HasNotifications())
            {
                return new JsonResult(_notificationContext.GetNotifications())
                {
                    StatusCode = 400
                };
            }

            return new JsonResult(response)
            {
                StatusCode = 200
            };
        }
    }
}