using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TyperLeague.ApplicationServices.API.Domain;
using TyperLeague.DataAccess;
using TyperLeague.DataAccess.Entities;

namespace TyperLeague.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class BetsController : ApiControllerBase
    {
        public BetsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [Route("")]
        public Task<IActionResult> GetAllBets([FromQuery] GetBetsRequest request)
        {
            return this.HandleRequest<GetBetsRequest, GetBetsResponse>(request);

        }

        [HttpGet]
        [Route("{betId}")]
        public Task<IActionResult> GetBetById([FromRoute] int betId)
        {
            var request = new GetBetByIdRequest()
            {
                BetId = betId
            };
            return this.HandleRequest<GetBetByIdRequest, GetBetByIdResponse>(request);
        }

        [Authorize(Policy = "IsAdmin")]
        [HttpPost]
        [Route("/addBet/{gameId}")]
        public Task<IActionResult> AddBeats([FromBody] AddBetsRequest request, [FromRoute] int gameId)
        {
            request = new AddBetsRequest()
            {
                GameId = gameId,
                Info = request.Info,
                Deadline = request.Deadline
            };

            return this.HandleRequest<AddBetsRequest, AddBetsResponse>(request);
        }

        [HttpPut]
        [Route("{id}")]
        public Task<IActionResult> EditUserPredicionBetResult([FromBody] EditUserPredicionBetResultRequest request, [FromRoute] int id)
        {
            request = new EditUserPredicionBetResultRequest()
            {
                BetId = id,
                FirstTeamPointsUserPrediction = request.FirstTeamPointsUserPrediction,
                SecondTeamPointsUserPrediction = request.SecondTeamPointsUserPrediction
            };

            return this.HandleRequest<EditUserPredicionBetResultRequest, EditUserPredicionBetResultResponse>(request);
        }
    }
}
