using AutoMapper;
using TyperLeague.ApplicationServices.API.Domain.Models;

namespace TyperLeague.ApplicationServices.API.Mappings
{
    public class GamesProfile : Profile
    {
        public GamesProfile()
        {
            this.CreateMap<TyperLeague.DataAccess.Entities.Game, Game>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Result, y => y.MapFrom(z => z.Result))
                .ForMember(x => x.FirstTeamId, y => y.MapFrom(z => z.FirstTeamId))
                .ForMember(x => x.SecondTeamId, y => y.MapFrom(z => z.SecondTeamId));

        }
    }
}
