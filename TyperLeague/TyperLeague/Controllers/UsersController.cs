using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TyperLeague.ApplicationServices.API.Domain;

namespace TyperLeague.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[Controller]")]
    public class UsersController : ApiControllerBase
    {
        public UsersController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [Route("")]
        public Task<IActionResult> GetAllUsers([FromQuery] GetUsersRequest request)
        {
            return this.HandleRequest<GetUsersRequest, GetUsersResponse>(request);
        }

        [HttpGet]
        [Route("{userName}")]
        public Task<IActionResult> GetUser([FromRoute] string userName)
        {
            var request = new GetUserRequest()
            {
                UserName = userName
            };
            return this.HandleRequest<GetUserRequest, GetUserResponse>(request);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("")]
        public Task<IActionResult> AddUser([FromBody] AddUserRequest request)
        {
            return this.HandleRequest<AddUserRequest, AddUserResponse>(request);
        }

        [Authorize(Policy = "IsAdmin")]
        [HttpDelete]
        [Route("{id}")]
        public Task<IActionResult> RemoveUserById([FromRoute] int id)
        {
            var request = new RemoveUserByIdRequest()
            {
                UserId = id
            };
            return this.HandleRequest<RemoveUserByIdRequest, RemoveUserByIdResponse>(request);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("authenticate")]
        public Task<IActionResult> Post([FromBody] ValidateUserRequest request)
        {
            return this.HandleRequest<ValidateUserRequest, ValidateUserResponse>(request);
        }
    }
}
