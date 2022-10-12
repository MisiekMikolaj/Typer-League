using AutoMapper;
using MediatR;
using TyperLeague.ApplicationServices.API.Domain;
using TyperLeague.DataAccess.CQRS;
using TyperLeague.DataAccess.CQRS.Commands;
using TyperLeague.DataAccess.Entities;

namespace TyperLeague.ApplicationServices.API.Handlers
{
    public class AddUserHandler : IRequestHandler<AddUserRequest, AddUserResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;

        public AddUserHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
        }

        public async Task<AddUserResponse> Handle(AddUserRequest request, CancellationToken cancellationToken)
        {
            var user = this.mapper.Map<User>(request);
            var command = new AddUserCommand() { Parameter = user };
            var userFromDb = await this.commandExecutor.Execute(command);
            return new AddUserResponse()
            {
                Data = this.mapper.Map<Domain.Models.User>(userFromDb)
            };
        }
    }
}
