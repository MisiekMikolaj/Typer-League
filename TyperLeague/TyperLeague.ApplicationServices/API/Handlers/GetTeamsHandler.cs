using AutoMapper;
using MediatR;
using TyperLeague.ApplicationServices.API.Domain;
using TyperLeague.DataAccess.CQRS;
using TyperLeague.DataAccess.CQRS.Queries;
using TyperLeague.DataAccess.Entities;

namespace TyperLeague.ApplicationServices.API.Handlers
{
    public class GetTeamsHandler : IRequestHandler<GetTeamsRequest, GetTeamsResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetTeamsHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<GetTeamsResponse> Handle(GetTeamsRequest request, CancellationToken cancellationToken)
        {
            var query = new GetTeamsQuery();
            var teams = await this.queryExecutor.Execute(query);
            var mappedTeams = this.mapper.Map<List<Domain.Models.Team>>(teams);

            var response = new GetTeamsResponse()
            {
                Data = mappedTeams
            };

            return response;
        }
    }
}
