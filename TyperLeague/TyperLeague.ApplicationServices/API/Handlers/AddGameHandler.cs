using AutoMapper;
using MediatR;
using TyperLeague.ApplicationServices.API.Domain;
using TyperLeague.ApplicationServices.API.ErrorHandling;
using TyperLeague.DataAccess;
using TyperLeague.DataAccess.CQRS;
using TyperLeague.DataAccess.CQRS.Commands;
using TyperLeague.DataAccess.Entities;

namespace TyperLeague.ApplicationServices.API.Handlers
{
    public class AddGameHandler : IRequestHandler<AddGameRequest, AddGameResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;
        private readonly TyperLeagueStorageContext context;

        public AddGameHandler(ICommandExecutor commandExecutor, IMapper mapper, TyperLeagueStorageContext context)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
            this.context = context;
        }

        public async Task<AddGameResponse> Handle(AddGameRequest request, CancellationToken cancellationToken)
        {
            var nameToIdRequest = new AddGameRequest
            {
                Result = "???",
                FirstTeam = context.Teams.Where(x => x.Name == request.FirstTeamName).FirstOrDefault(),
                SecondTeam = context.Teams.Where(x => x.Name == request.SecondTeamName).FirstOrDefault()
            };

            if (nameToIdRequest.FirstTeam == null || nameToIdRequest.SecondTeam == null)
            {
                return new AddGameResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var game = this.mapper.Map<Game>(nameToIdRequest);
            var command = new AddGameCommand() { Parameter = game };
            var gameFromDb = await this.commandExecutor.Execute(command);
            return new AddGameResponse()
            {
                Data = this.mapper.Map<Domain.Models.Game>(gameFromDb)
            };
        }
    }
}
