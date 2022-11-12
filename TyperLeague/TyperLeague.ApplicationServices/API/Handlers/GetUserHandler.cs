using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TyperLeague.ApplicationServices.API.Domain;
using TyperLeague.DataAccess.CQRS;
using TyperLeague.DataAccess.CQRS.Queries;

namespace TyperLeague.ApplicationServices.API.Handlers
{
    public class GetUserHandler : IRequestHandler<GetUserRequest, GetUserResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetUserHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }
        public async Task<GetUserResponse> Handle(GetUserRequest request, CancellationToken cancellationToken)
        {
            var query = new GetUserQuery()
            {
                Name = request.UserName
            };
            var user = await this.queryExecutor.Execute(query);

            var mappedUser = this.mapper.Map<Domain.Models.User>(user);
            var response = new GetUserResponse()
            {
                Data = mappedUser
            };
            return response;
        }
    }
}
