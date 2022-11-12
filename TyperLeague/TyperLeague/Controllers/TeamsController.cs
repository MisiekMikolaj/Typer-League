using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TyperLeague.ApplicationServices.API.Domain;

namespace TyperLeague.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[Controller]")]
    public class TeamsController : ApiControllerBase
    {
        public TeamsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [Route("")]
        public Task<IActionResult> GetAllTeams([FromQuery] GetTeamsRequest request)
        {
            return this.HandleRequest<GetTeamsRequest, GetTeamsResponse>(request);
        }

        [Authorize(Policy = "IsAdmin")]
        [HttpPost]
        [Route("")]
        public Task<IActionResult> AddTeam([FromBody] AddTeamRequest request)
        {
            return this.HandleRequest<AddTeamRequest, AddTeamResponse>(request);
        }
    }
}
