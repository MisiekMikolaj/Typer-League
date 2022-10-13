using MediatR;

namespace TyperLeague.ApplicationServices.API.Domain
{
    public class EditUserPredicionBetResultRequest : IRequest<EditUserPredicionBetResultResponse>
    {
        public int BetId { get; set; }
        public int FirstTeamPointsUserPrediction { get; set; }
        public int SecondTeamPointsUserPrediction { get; set; }
    }
}
