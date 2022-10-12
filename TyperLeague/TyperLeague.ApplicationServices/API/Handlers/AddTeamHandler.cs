using AutoMapper;
using MediatR;
using TyperLeague.ApplicationServices.API.Domain;
using TyperLeague.DataAccess.CQRS;
using TyperLeague.DataAccess.CQRS.Commands;
using TyperLeague.DataAccess.Entities;

namespace TyperLeague.ApplicationServices.API.Handlers
{
    public class AddTeamHandler : IRequestHandler<AddTeamRequest, AddTeamResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private IMapper mapper;

        public AddTeamHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
        }

        public async Task<AddTeamResponse> Handle(AddTeamRequest request, CancellationToken cancellationToken)
        {
            var team = this.mapper.Map<Team>(request);
            var command = new AddTeamCommand() { Parameter = team };
            var teamFromDb = await this.commandExecutor.Execute(command);
            return new AddTeamResponse()
            {
                Data = this.mapper.Map<Domain.Models.Team>(teamFromDb)
            };
        }
    }
}
