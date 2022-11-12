using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TyperLeague.ApplicationServices.API.Domain;

namespace TyperLeague.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class GamesController : ApiControllerBase
    {
        public GamesController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [Route("")]
        public Task<IActionResult> GetAllGames([FromQuery] GetGamesRequest request)
        {
            return this.HandleRequest<GetGamesRequest, GetGamesResponse>(request);
        }

        [Authorize(Policy = "IsAdmin")]
        [HttpPost]
        [Route("")]
        public Task<IActionResult> AddGame([FromBody] AddGameRequest request)
        {
            return this.HandleRequest<AddGameRequest, AddGameResponse>(request);
        }

        [Authorize(Policy = "IsAdmin")]
        [HttpPut]
        [Route("{id}")]
        public Task<IActionResult> EditGamePoints([FromRoute] int id, [FromBody] EditGamePointsRequest request)
        {
            request = new EditGamePointsRequest()
            {
                GameId = id,
                FirstTeamPoints = request.FirstTeamPoints,
                SecondTeamPoints = request.SecondTeamPoints
            };
            return this.HandleRequest<EditGamePointsRequest, EditGamePointsResponse>(request);
        }

        [HttpGet]
        [Route("{id}")]
        public Task<IActionResult> GetGame([FromRoute] int id)
        {
            var request = new GetGameRequest()
            {
                GameId = id
            };
            return this.HandleRequest<GetGameRequest, GetGameResponse>(request);
        }
    }
}
