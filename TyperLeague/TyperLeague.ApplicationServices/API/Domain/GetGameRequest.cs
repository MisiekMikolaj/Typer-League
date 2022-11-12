using MediatR;

namespace TyperLeague.ApplicationServices.API.Domain
{
    public class GetGameRequest : BaseRequest, IRequest<GetGameResponse>
    {
        public int GameId { get; set; }
    }
}
