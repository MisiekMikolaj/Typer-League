using MediatR;
using Microsoft.AspNetCore.Mvc;
using TyperLeague.ApplicationServices.API.Domain;

namespace TyperLeague.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator mediator;

        public UsersController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllUsers([FromQuery] GetUsersRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }
    }
}
