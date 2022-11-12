using MediatR;

namespace TyperLeague.ApplicationServices.API.Domain
{
    public class AddTeamRequest : BaseRequest, IRequest<AddTeamResponse>
    {
        public string Name { get; set; }
    }
}
