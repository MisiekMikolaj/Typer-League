using MediatR;

namespace TyperLeague.ApplicationServices.API.Domain
{
    public class GetGamesRequest : IRequest<GetGamesResponse>
    {
        public string? teamName { get; set; }
    }
}
