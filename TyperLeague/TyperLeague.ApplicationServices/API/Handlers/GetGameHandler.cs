using AutoMapper;
using MediatR;
using TyperLeague.ApplicationServices.API.Domain;
using TyperLeague.ApplicationServices.API.ErrorHandling;
using TyperLeague.DataAccess.CQRS;
using TyperLeague.DataAccess.CQRS.Queries;

namespace TyperLeague.ApplicationServices.API.Handlers
{
    public class GetGameHandler : IRequestHandler<GetGameRequest, GetGameResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetGameHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<GetGameResponse> Handle(GetGameRequest request, CancellationToken cancellationToken)
        {
            var query = new GetGameQuery()
            {
                Id = request.GameId
            };
            var game = await this.queryExecutor.Execute(query);

            if (game == null)
            {
                return new GetGameResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var mappedGame = this.mapper.Map<Domain.Models.Game>(game);
            var response = new GetGameResponse()
            {
                Data = mappedGame
            };
            return response;
        }
    }
}
