using MediatR;

namespace TyperLeague.ApplicationServices.API.Domain
{
    public class GetTeamsRequest : BaseRequest, IRequest<GetTeamsResponse>
    {
    }
}
