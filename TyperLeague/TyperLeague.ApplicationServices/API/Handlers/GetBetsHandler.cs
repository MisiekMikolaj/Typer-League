using MediatR;
using TyperLeague.ApplicationServices.API.Domain;
using TyperLeague.DataAccess;
using TyperLeague.DataAccess.Entities;

namespace TyperLeague.ApplicationServices.API.Handlers
{
    public class GetBetsHandler : IRequestHandler<GetBetsRequest, GetBetsResponse>
    {
        private readonly IRepository<Bet> betRepository;

        public GetBetsHandler(IRepository<Bet> betRepository)
        {
            this.betRepository = betRepository;
        }

        public Task<GetBetsResponse> Handle(GetBetsRequest request, CancellationToken cancellationToken)
        {
            var bets = this.betRepository.GetAll();
            var domainBets = bets.Select(b => new Domain.Models.Bet()
            {
                Id = b.Id,
                Name = b.Name,
                Info = b.Info,
                RealResult = b.RealResult,
                UserPrediction = b.UserPrediction,
                Deadline = b.Deadline
            });

            var response = new GetBetsResponse()
            {
                Data = domainBets.ToList()
            };
            return Task.FromResult(response);
        }
    }
}
