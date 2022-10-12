using AutoMapper;
using MediatR;
using TyperLeague.ApplicationServices.API.Domain;
using TyperLeague.DataAccess.CQRS;
using TyperLeague.DataAccess.CQRS.Queries;
using TyperLeague.DataAccess.Entities;

namespace TyperLeague.ApplicationServices.API.Handlers
{
    public class GetUsersHandler : IRequestHandler<GetUsersRequest, GetUsersResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetUsersHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<GetUsersResponse> Handle(GetUsersRequest request, CancellationToken cancellationToken)
        {
            var query = new GetUsersQuery();
            var users = await this.queryExecutor.Execute(query);
            var mappedUsers = this.mapper.Map<List<Domain.Models.User>>(users);

            var response = new GetUsersResponse()
            {
                Data = mappedUsers
            };

            return response;
        }
    }
}
