using AutoMapper;
using MediatR;
using TyperLeague.ApplicationServices.API.Domain;
using TyperLeague.DataAccess;
using TyperLeague.DataAccess.CQRS.Queries;
using TyperLeague.DataAccess.Entities;

namespace TyperLeague.ApplicationServices.API.Handlers
{
    public class GetGamesHandler : IRequestHandler<GetGamesRequest, GetGamesResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;
        public GetGamesHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }
        public async Task<GetGamesResponse> Handle(GetGamesRequest request, CancellationToken cancellationToken)
        {
            var query = new GetGamesQuery();
            var games = await this.queryExecutor.Execute(query);
            var mappedgames = this.mapper.Map<List<Domain.Models.Game>>(games);

            var response = new GetGamesResponse()
            {
                Data = mappedgames
            };
            return response;

        }
    }
}
