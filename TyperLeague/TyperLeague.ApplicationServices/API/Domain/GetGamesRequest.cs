using MediatR;

namespace TyperLeague.ApplicationServices.API.Domain
{
    public class GetGamesRequest : BaseRequest, IRequest<GetGamesResponse>
    {
        public string? teamName { get; set; }
    }
}
