using MediatR;
using TyperLeague.ApplicationServices.API.Domain;
using TyperLeague.DataAccess;
using TyperLeague.DataAccess.Entities;

namespace TyperLeague.ApplicationServices.API.Handlers
{
    public class GetUsersHandler : IRequestHandler<GetUsersRequest, GetUsersResponse>
    {
        private readonly IRepository<User> userRepository;

        public GetUsersHandler(IRepository<User> userRepository)
        {
            this.userRepository = userRepository;
        }

        public Task<GetUsersResponse> Handle(GetUsersRequest request, CancellationToken cancellationToken)
        {
            var users = userRepository.GetAll();
            var domainUsers = users.Select(u => new Domain.Models.User()
            {
                Id = u.Id,
                Name = u.Name,
                Points = u.Points,
                IsAdmin = u.IsAdmin
            });

            var response = new GetUsersResponse()
            {
                Data = domainUsers.ToList()
            };

            return Task.FromResult(response);
        }
    }
}
