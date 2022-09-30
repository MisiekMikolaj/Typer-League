using AutoMapper;
using MediatR;
using TyperLeague.ApplicationServices.API.Domain;
using TyperLeague.DataAccess;
using TyperLeague.DataAccess.Entities;

namespace TyperLeague.ApplicationServices.API.Handlers
{
    public class GetBetsHandler : IRequestHandler<GetBetsRequest, GetBetsResponse>
    {
        private readonly IRepository<Bet> betRepository;
        IMapper mapper;

        public GetBetsHandler(IRepository<Bet> betRepository, IMapper mapper)
        {
            this.betRepository = betRepository;
            this.mapper = mapper;
        }

        public Task<GetBetsResponse> Handle(GetBetsRequest request, CancellationToken cancellationToken)
        {
            var bets = this.betRepository.GetAll();
            var mappedBets = this.mapper.Map<List<Domain.Models.Bet>>(bets);

            var response = new GetBetsResponse()
            {
                Data = mappedBets
            };
            return Task.FromResult(response);
        }
    }
}
