using MediatR;
using TyperLeague.ApplicationServices.API.Domain;
using TyperLeague.DataAccess;
using TyperLeague.DataAccess.Entities;

namespace TyperLeague.ApplicationServices.API.Handlers
{
    public class GetTeamsHandler : IRequestHandler<GetTeamsRequest, GetTeamsResponse>
    {
        private readonly IRepository<Team> teamsRepository;

        public GetTeamsHandler(DataAccess.IRepository<Team> teamsRepository)
        {
            this.teamsRepository = teamsRepository;
        }

        public Task<GetTeamsResponse> Handle(GetTeamsRequest request, CancellationToken cancellationToken)
        {
            var teams = teamsRepository.GetAll();
            var domainTeams = teams.Select(t => new Domain.Models.Team()
            {
                Id = t.Id,
                Name = t.Name
            });

            var response = new GetTeamsResponse()
            {
                Data = domainTeams.ToList()
            };

            return Task.FromResult(response);
        }
    }
}
