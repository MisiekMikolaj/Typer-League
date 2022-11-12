using AutoMapper;
using TyperLeague.ApplicationServices.API.Domain;
using TyperLeague.ApplicationServices.API.Domain.Models;

namespace TyperLeague.ApplicationServices.API.Mappings
{
    public class BetsProfile : Profile
    {
        public BetsProfile()
        {
            this.CreateMap<AddBetsRequest, TyperLeague.DataAccess.Entities.Bet>()
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.Info, y => y.MapFrom(z => z.Info))
                .ForMember(x => x.GameId, y => y.MapFrom(z => z.GameId))
                .ForMember(x => x.Deadline, y => y.MapFrom(z => z.Deadline))
                .ForMember(x => x.RealResult, y => y.MapFrom(z => "???"))
                .ForMember(x => x.UserPrediction, y => y.MapFrom(z => "???"))
                .ForMember(x => x.BetPoints, y => y.MapFrom(z => 0))
                .ForMember(x => x.User, y => y.MapFrom(z => z.User));

            this.CreateMap<TyperLeague.DataAccess.Entities.Bet, Bet>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.Info, y => y.MapFrom(z => z.Info))
                .ForMember(x => x.RealResult, y => y.MapFrom(z => z.RealResult))
                .ForMember(x => x.UserPrediction, y => y.MapFrom(z => z.UserPrediction))
                .ForMember(x => x.Deadline, y => y.MapFrom(z => z.Deadline))
                .ForMember(x => x.User, y => y.MapFrom(z => z.User))
                .ForMember(x => x.BetPoints, y => y.MapFrom(z => z.BetPoints))
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id));

            this.CreateMap<EditUserPredicionBetResultRequest, TyperLeague.DataAccess.Entities.Bet>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.BetId))
                .ForMember(x => x.UserPrediction, y => y.MapFrom(z => $"{z.FirstTeamPointsUserPrediction} : {z.SecondTeamPointsUserPrediction}"));
        }
    }
}
