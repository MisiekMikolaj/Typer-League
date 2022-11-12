using MediatR;

namespace TyperLeague.ApplicationServices.API.Domain
{
    public class GetBetsRequest : BaseRequest, IRequest<GetBetsResponse>
    {
    }
}
