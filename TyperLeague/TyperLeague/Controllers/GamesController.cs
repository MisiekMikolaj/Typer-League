using MediatR;
using Microsoft.AspNetCore.Mvc;
using TyperLeague.ApplicationServices.API.Domain;

namespace TyperLeague.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GamesController : ControllerBase
    {
        private readonly IMediator mediator;
        public GamesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllGames([FromQuery] GetGamesRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }
    }
}
