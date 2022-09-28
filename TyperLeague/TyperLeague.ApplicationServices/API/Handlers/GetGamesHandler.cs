using MediatR;
using TyperLeague.ApplicationServices.API.Domain;
using TyperLeague.DataAccess;
using TyperLeague.DataAccess.Entities;

namespace TyperLeague.ApplicationServices.API.Handlers
{
    public class GetGamesHandler : IRequestHandler<GetGamesRequest, GetGamesResponse>
    {
        private readonly IRepository<Game> gameRepository;
        public GetGamesHandler(IRepository<DataAccess.Entities.Game> gameRepository)
        {
            this.gameRepository = gameRepository;
        }
        public Task<GetGamesResponse> Handle(GetGamesRequest request, CancellationToken cancellationToken)
        {
            var games = this.gameRepository.GetAll();
            var domainGames = games.Select(g => new Domain.Models.Game()
            {
                Id = g.Id,
                Result = g.Result
            });

            var response = new GetGamesResponse()
            {
                Data = domainGames.ToList()
            };
            return Task.FromResult(response);

        }
    }
}
