using AutoMapper;
using TyperLeague.ApplicationServices.API.Domain;
using TyperLeague.ApplicationServices.API.Domain.Models;

namespace TyperLeague.ApplicationServices.API.Mappings
{
    public class GamesProfile : Profile
    {
        public GamesProfile()
        {
            this.CreateMap<AddGameRequest, TyperLeague.DataAccess.Entities.Game>()
                .ForMember(x => x.FirstTeamId, y => y.MapFrom(z => z.FirstTeam.Id))
                .ForMember(x => x.SecondTeamId, y => y.MapFrom(z => z.SecondTeam.Id))
                .ForMember(x => x.Result, y => y.MapFrom(z => z.Result))
                .ForPath(x => x.FirstTeam.Name, y => y.MapFrom(z => z.FirstTeam.Name))
                .ForPath(x => x.SecondTeam.Name, y => y.MapFrom(z => z.SecondTeam.Name))
                .ForMember(x => x.FirstTeam, y => y.MapFrom(z => z.FirstTeam))
                .ForMember(x => x.SecondTeam, y => y.MapFrom(z => z.SecondTeam));

            this.CreateMap<TyperLeague.DataAccess.Entities.Game, Game>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Result, y => y.MapFrom(z => z.Result))
                .ForMember(x => x.FirstTeamId, y => y.MapFrom(z => z.FirstTeamId))
                .ForMember(x => x.SecondTeamId, y => y.MapFrom(z => z.SecondTeamId))
                .ForMember(x => x.FirstTeamName, y => y.MapFrom(z => z.FirstTeam.Name))
                .ForMember(x => x.SecondTeamName, y => y.MapFrom(z => z.SecondTeam.Name));

            this.CreateMap<EditGamePointsRequest, TyperLeague.DataAccess.Entities.Game>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.GameId))
                .ForMember(x => x.Result, y => y.MapFrom(z => $"{z.FirstTeamPoints} : {z.SecondTeamPoints}"));
        }
    }
}
