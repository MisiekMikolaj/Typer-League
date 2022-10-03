using AutoMapper;
using MediatR;
using TyperLeague.ApplicationServices.API.Domain;
using TyperLeague.DataAccess;
using TyperLeague.DataAccess.CQRS.Queries;
using TyperLeague.DataAccess.Entities;

namespace TyperLeague.ApplicationServices.API.Handlers
{
    public class GetBetsHandler : IRequestHandler<GetBetsRequest, GetBetsResponse>
    {
       private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;


        public GetBetsHandler(IMapper mapper, IQueryExecutor queryExecutor )
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<GetBetsResponse> Handle(GetBetsRequest request, CancellationToken cancellationToken)
        {
            var query = new GetBetsQuery()
            {
            };
            var bets = await this.queryExecutor.Execute(query);
            var mappedBets = this.mapper.Map<List<Domain.Models.Bet>>(bets);

            var response = new GetBetsResponse()
            {
                Data = mappedBets
            };
            return response;
        }
    }
}
