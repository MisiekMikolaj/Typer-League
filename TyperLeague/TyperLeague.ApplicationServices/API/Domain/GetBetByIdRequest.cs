using MediatR;

namespace TyperLeague.ApplicationServices.API.Domain
{
    public class GetBetByIdRequest : IRequest<GetBetByIdResponse>
    {
        public int BetId { get; set; }
    }
}
