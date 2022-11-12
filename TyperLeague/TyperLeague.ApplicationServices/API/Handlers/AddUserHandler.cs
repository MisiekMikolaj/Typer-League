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
    public class AddUserHandler : IRequestHandler<AddUserRequest, AddUserResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;
        private readonly TyperLeagueStorageContext context;

        public AddUserHandler(IMapper mapper, ICommandExecutor commandExecutor, TyperLeagueStorageContext context)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
            this.context = context;
        }

        public async Task<AddUserResponse> Handle(AddUserRequest request, CancellationToken cancellationToken)
        {
            var user = this.mapper.Map<User>(request);

            if (context.Users.ToList().Where(x => x.Name == user.Name).FirstOrDefault() != null)
            {
                return new AddUserResponse()
                {
                    Error = new ErrorModel("This user name exist")
                };
            }

            var command = new AddUserCommand() { Parameter = user };
            var userFromDb = await this.commandExecutor.Execute(command);
            return new AddUserResponse()
            {
                Data = this.mapper.Map<Domain.Models.User>(userFromDb)
            };
        }
    }
}
