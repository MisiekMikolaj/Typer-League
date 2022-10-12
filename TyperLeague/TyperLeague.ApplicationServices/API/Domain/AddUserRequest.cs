using MediatR;

namespace TyperLeague.ApplicationServices.API.Domain
{
    public class AddUserRequest : IRequest<AddUserResponse>
    {
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
