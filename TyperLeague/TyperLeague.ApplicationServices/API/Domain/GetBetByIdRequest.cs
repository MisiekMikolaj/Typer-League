using MediatR;

namespace TyperLeague.ApplicationServices.API.Domain
{
    public class GetBetByIdRequest : BaseRequest, IRequest<GetBetByIdResponse>
    {
        public int BetId { get; set; }
    }
}
