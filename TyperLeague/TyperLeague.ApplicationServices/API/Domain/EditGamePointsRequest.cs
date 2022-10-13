using MediatR;

namespace TyperLeague.ApplicationServices.API.Domain
{
    public class EditGamePointsRequest : IRequest<EditGamePointsResponse>
    {
        public int GameId { get; set; }
        public int FirstTeamPoints { get; set; }
        public int SecondTeamPoints { get; set; }
    }
}
