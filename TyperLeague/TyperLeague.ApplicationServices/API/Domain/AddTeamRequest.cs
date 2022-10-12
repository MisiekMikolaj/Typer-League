using MediatR;

namespace TyperLeague.ApplicationServices.API.Domain
{
    public class AddTeamRequest : IRequest<AddTeamResponse>
    {
        public string Name { get; set; }
    }
}
