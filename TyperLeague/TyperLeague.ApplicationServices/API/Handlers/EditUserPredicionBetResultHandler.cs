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
    public class EditUserPredicionBetResultHandler : IRequestHandler<EditUserPredicionBetResultRequest, EditUserPredicionBetResultResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;
        private readonly TyperLeagueStorageContext context;

        public EditUserPredicionBetResultHandler(IMapper mapper, ICommandExecutor commandExecutor, TyperLeagueStorageContext context)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
            this.context = context;
        }

        public async Task<EditUserPredicionBetResultResponse> Handle(EditUserPredicionBetResultRequest request, CancellationToken cancellationToken)
        {
            var editBetUserPrediction = this.mapper.Map<Bet>(request);

            if (context.Bets.Where(x => x.Id == editBetUserPrediction.Id).FirstOrDefault() == null)
            {
                return new EditUserPredicionBetResultResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            else if (context.Bets.Where(x => x.Id == editBetUserPrediction.Id).FirstOrDefault().UserId != request.userIdClaim)
            {
                return new EditUserPredicionBetResultResponse()
                {
                    Error = new ErrorModel(ErrorType.Unauthorized + " You Cant changdze bets that is not yours")
                };
            }
            else if (context.Bets.Where(x => x.Id == editBetUserPrediction.Id).FirstOrDefault().Deadline < DateTime.UtcNow)
            {
                return new EditUserPredicionBetResultResponse()
                {
                    Error = new ErrorModel(ErrorType.Unauthorized + " dedline is over")
                };
            }

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
