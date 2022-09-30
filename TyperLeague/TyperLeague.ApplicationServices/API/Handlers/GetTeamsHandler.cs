using AutoMapper;
using MediatR;
using TyperLeague.ApplicationServices.API.Domain;
using TyperLeague.DataAccess;
using TyperLeague.DataAccess.Entities;

namespace TyperLeague.ApplicationServices.API.Handlers
{
    public class GetTeamsHandler : IRequestHandler<GetTeamsRequest, GetTeamsResponse>
    {
        private readonly IRepository<Team> teamsRepository;
        private readonly IMapper mapper;

        public GetTeamsHandler(DataAccess.IRepository<Team> teamsRepository, IMapper mapper)
        {
            this.teamsRepository = teamsRepository;
            this.mapper = mapper;
        }

        public Task<GetTeamsResponse> Handle(GetTeamsRequest request, CancellationToken cancellationToken)
        {
            var teams = teamsRepository.GetAll();
            var mappedTeams = this.mapper.Map<List<Domain.Models.Team>>(teams);

            var response = new GetTeamsResponse()
            {
                Data = mappedTeams
            };

            return Task.FromResult(response);
        }
    }
}
