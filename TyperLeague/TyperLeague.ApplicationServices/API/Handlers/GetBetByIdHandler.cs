using AutoMapper;
using MediatR;
using TyperLeague.ApplicationServices.API.Domain;
using TyperLeague.DataAccess.CQRS;
using TyperLeague.DataAccess.CQRS.Queries;

namespace TyperLeague.ApplicationServices.API.Handlers
{
    public class GetBetByIdHandler : IRequestHandler<GetBetByIdRequest, GetBetByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetBetByIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<GetBetByIdResponse> Handle(GetBetByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetBetQuery()
            {
                Id = request.BetId
            };
            var bet = await this.queryExecutor.Execute(query);
            var mappedBet = this.mapper.Map<Domain.Models.Bet>(bet);
            var response = new GetBetByIdResponse()
            {
                Data = mappedBet
            };
            return response;
        }
    }
}
