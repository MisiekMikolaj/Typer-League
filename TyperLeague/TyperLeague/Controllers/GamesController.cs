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

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddGame([FromBody] AddGameRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpPut]
        [Route("{gameId},{firstTeamPoints},{secondTeamPoints}")]
        public async Task<IActionResult> EditGamePoints([FromRoute] int gameId, int firstTeamPoints, int secondTeamPoints)
        {
            var request = new EditGamePointsRequest
            {
                GameId = gameId,
                FirstTeamPoints = firstTeamPoints,
                SecondTeamPoints = secondTeamPoints

            };
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }
    }
}
