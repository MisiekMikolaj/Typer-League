using AutoMapper;
using MediatR;
using TyperLeague.ApplicationServices.API.Domain;
using TyperLeague.ApplicationServices.API.ErrorHandling;
using TyperLeague.DataAccess;
using TyperLeague.DataAccess.CQRS;
using TyperLeague.DataAccess.CQRS.Commands;

namespace TyperLeague.ApplicationServices.API.Handlers
{
    public class RemoveUserByIdHandler : IRequestHandler<RemoveUserByIdRequest, RemoveUserByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;
        private readonly TyperLeagueStorageContext context;

        public RemoveUserByIdHandler(IMapper mapper, ICommandExecutor commandExecutor, TyperLeagueStorageContext context)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
            this.context = context;
        }
        public async Task<RemoveUserByIdResponse> Handle(RemoveUserByIdRequest request, CancellationToken cancellationToken)
        {
            var command = new RemoveUserByIdCommand()
            {
                Id = request.UserId
            };

            if (context.Users.Where(x => x.Id == command.Id).FirstOrDefault() == null)
            {
                return new RemoveUserByIdResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var removeUserFromDb = await this.commandExecutor.Execute(command);

            return new RemoveUserByIdResponse()
            {
                Data = this.mapper.Map<Domain.Models.User>(removeUserFromDb)
            };
        }
    }
}
