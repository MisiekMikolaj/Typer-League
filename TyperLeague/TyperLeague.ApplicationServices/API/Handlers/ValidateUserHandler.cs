using AutoMapper;
using MediatR;
using TyperLeague.ApplicationServices.API.Domain;
using TyperLeague.DataAccess;
using TyperLeague.DataAccess.CQRS;
using TyperLeague.DataAccess.CQRS.Commands;

namespace TyperLeague.ApplicationServices.API.Handlers
{
    public class ValidateUserHandler : IRequestHandler<ValidateUserRequest, ValidateUserResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;
        private readonly TyperLeagueStorageContext context;

        public ValidateUserHandler(IMapper mapper, ICommandExecutor commandExecutor, TyperLeagueStorageContext context)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
            this.context = context;
        }
        public async Task<ValidateUserResponse> Handle(ValidateUserRequest request, CancellationToken cancellationToken)
        {
            Domain.Models.User user = null;

            if (context.Users.Where(x => x.Name == request.Username).FirstOrDefault().Password == request.Password)
            {
                user = new Domain.Models.User()
                {
                    Id = 0,
                    Name = "",
                    Points = 0,
                    IsAdmin = false
                };
            }

            var response = new ValidateUserResponse()
            {
                Data = user
            };

            return response;
        }
    }
}
