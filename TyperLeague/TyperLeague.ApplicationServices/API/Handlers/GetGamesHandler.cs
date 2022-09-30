using AutoMapper;
using MediatR;
using TyperLeague.ApplicationServices.API.Domain;
using TyperLeague.DataAccess;
using TyperLeague.DataAccess.Entities;

namespace TyperLeague.ApplicationServices.API.Handlers
{
    public class GetGamesHandler : IRequestHandler<GetGamesRequest, GetGamesResponse>
    {
        private readonly IRepository<Game> gameRepository;
        private readonly IMapper mapper;
        public GetGamesHandler(IRepository<DataAccess.Entities.Game> gameRepository, IMapper mapper)
        {
            this.gameRepository = gameRepository;
            this.mapper = mapper;
        }
        public Task<GetGamesResponse> Handle(GetGamesRequest request, CancellationToken cancellationToken)
        {
            var games = this.gameRepository.GetAll();
            /*var domaingames = games.Select(x => new Domain.Models.Game
            {
                Id = x.Id,
                Result = x.Result,
                FirstTeamId = x.FirstTeamId,
                SecondTeamId = x.SecondTeamId
            });

            var response = new GetGamesResponse()
            {
                Data = domaingames.ToList()
            };*/
            var mappedgames = this.mapper.Map<List<Domain.Models.Game>>(games);

            var response = new GetGamesResponse()
            {
                Data = mappedgames
            };
            return Task.FromResult(response);

        }
    }
}
