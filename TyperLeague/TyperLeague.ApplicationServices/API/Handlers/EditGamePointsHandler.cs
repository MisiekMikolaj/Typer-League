using AutoMapper;
using MediatR;
using TyperLeague.ApplicationServices.API.Domain;
using TyperLeague.DataAccess.CQRS;
using TyperLeague.DataAccess.CQRS.Commands;
using TyperLeague.DataAccess.Entities;

namespace TyperLeague.ApplicationServices.API.Handlers
{
    public class EditGamePointsHandler : IRequestHandler<EditGamePointsRequest, EditGamePointsResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;

        public EditGamePointsHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
        }

        public async Task<EditGamePointsResponse> Handle(EditGamePointsRequest request, CancellationToken cancellationToken)
        {
            var editGamePoints = this.mapper.Map<Game>(request);
            var command = new EditGamePointsCommand()
            {
                Result = editGamePoints.Result,
                Id = editGamePoints.Id,
            };
            var gameFromDb = await this.commandExecutor.Execute(command);
            return new EditGamePointsResponse()
            {
                Data = this.mapper.Map<Domain.Models.Game>(gameFromDb)
            };
        }
    }
}
