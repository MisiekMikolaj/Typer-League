using MediatR;

namespace TyperLeague.ApplicationServices.API.Domain
{
    public class GetUserRequest : BaseRequest, IRequest<GetUserResponse>
    {
        public string UserName { get; set; }
    }
}
