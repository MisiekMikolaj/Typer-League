using MediatR;
using Microsoft.AspNetCore.Mvc;
using TyperLeague.ApplicationServices.API.Domain;
using TyperLeague.DataAccess;
using TyperLeague.DataAccess.Entities;

namespace TyperLeague.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BetsController : ControllerBase
    {
        private readonly IMediator mediator;
        public BetsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllBets([FromQuery] GetBetsRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }
    }
}
