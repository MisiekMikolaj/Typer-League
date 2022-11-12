using MediatR;

namespace TyperLeague.ApplicationServices.API.Domain
{
    public class ValidateUserRequest : BaseRequest, IRequest<ValidateUserResponse>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
