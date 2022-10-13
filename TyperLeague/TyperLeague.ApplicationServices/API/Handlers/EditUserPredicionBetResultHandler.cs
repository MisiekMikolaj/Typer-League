using AutoMapper;
using MediatR;
using TyperLeague.ApplicationServices.API.Domain;
using TyperLeague.DataAccess.CQRS;
using TyperLeague.DataAccess.CQRS.Commands;
using TyperLeague.DataAccess.Entities;

namespace TyperLeague.ApplicationServices.API.Handlers
{
    public class EditUserPredicionBetResultHandler : IRequestHandler<EditUserPredicionBetResultRequest, EditUserPredicionBetResultResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;

        public EditUserPredicionBetResultHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
        }

        public async Task<EditUserPredicionBetResultResponse> Handle(EditUserPredicionBetResultRequest request, CancellationToken cancellationToken)
        {
            var editBetUserPrediction = this.mapper.Map<Bet>(request);
            var command = new EditUserPredictionBetResultCommand() 
            { 
                UserPrediction = editBetUserPrediction.UserPrediction,
                Id = editBetUserPrediction.Id,
            };
            var betFromDb = await this.commandExecutor.Execute(command);
            return new EditUserPredicionBetResultResponse()
            {
                Data = this.mapper.Map<Domain.Models.Bet>(betFromDb)
            };
        }
    }
}
