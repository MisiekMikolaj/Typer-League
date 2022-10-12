using MediatR;
using Microsoft.AspNetCore.Mvc;
using TyperLeague.ApplicationServices.API.Domain;

namespace TyperLeague.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class TeamsController : ControllerBase
    {
        private readonly IMediator mediator;

        public TeamsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllTeams([FromQuery] GetTeamsRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddTeam([FromBody] AddTeamRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }
    }
}
