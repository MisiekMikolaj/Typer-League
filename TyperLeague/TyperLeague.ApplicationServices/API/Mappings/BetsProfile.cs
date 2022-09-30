using AutoMapper;
using TyperLeague.ApplicationServices.API.Domain.Models;

namespace TyperLeague.ApplicationServices.API.Mappings
{
    public class BetsProfile : Profile
    {
        public BetsProfile()
        {
            this.CreateMap<TyperLeague.DataAccess.Entities.Bet, Bet>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.Info, y => y.MapFrom(z => z.Info))
                .ForMember(x => x.RealResult, y => y.MapFrom(z => z.RealResult))
                .ForMember(x => x.UserPrediction, y => y.MapFrom(z => z.UserPrediction))
                .ForMember(x => x.Deadline, y => y.MapFrom(z => z.Deadline));
        }
    }
}
