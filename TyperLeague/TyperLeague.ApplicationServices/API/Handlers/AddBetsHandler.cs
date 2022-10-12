using AutoMapper;
using MediatR;
using TyperLeague.ApplicationServices.API.Domain;
using TyperLeague.DataAccess;
using TyperLeague.DataAccess.CQRS;
using TyperLeague.DataAccess.CQRS.Commands;
using TyperLeague.DataAccess.Entities;

namespace TyperLeague.ApplicationServices.API.Handlers
{
    public class AddBetsHandler : IRequestHandler<AddBetsRequest, AddBetsResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;
        private readonly TyperLeagueStorageContext context;

        public AddBetsHandler(ICommandExecutor commandExecutor, IMapper mapper, TyperLeagueStorageContext context)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
            this.context = context;
        }

        public async Task<AddBetsResponse> Handle(AddBetsRequest request, CancellationToken cancellationToken)
        {
            List<AddBetsRequest> listRequest = new();

            foreach (var user in context.Users.ToList())
            {
                listRequest.Add(new AddBetsRequest 
                { 
                    Info = request.Info,
                    Deadline = request.Deadline,
                    Name = $"{request.FirstTeamName} : {request.SecondTeamName}",
                    GameId = context.Games.Where(x => x.FirstTeam.Name == request.FirstTeamName && x.SecondTeam.Name == request.SecondTeamName && x.Result == "???").Select(x => x.Id).FirstOrDefault(),
                    User = user
                });
            }

            var bet = this.mapper.Map<List<Bet>>(listRequest);
            var command = new AddBetsCommand() { Parameter = bet };
            var betFromDb = await this.commandExecutor.Execute(command);

            return new AddBetsResponse()
            {
                Data = this.mapper.Map<List<Domain.Models.Bet>>(betFromDb)
            };
        }
    }
}
