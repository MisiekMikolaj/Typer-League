using MediatR;

namespace TyperLeague.ApplicationServices.API.Domain
{
    public class AddUserRequest : BaseRequest, IRequest<AddUserResponse>
    {
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
