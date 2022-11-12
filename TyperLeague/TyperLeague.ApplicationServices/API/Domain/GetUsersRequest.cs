using MediatR;

namespace TyperLeague.ApplicationServices.API.Domain
{
    public class GetUsersRequest : BaseRequest, IRequest<GetUsersResponse>
    {
    }
}
