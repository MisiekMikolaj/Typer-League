using AutoMapper;
using TyperLeague.ApplicationServices.API.Domain;
using TyperLeague.ApplicationServices.API.Domain.Models;

namespace TyperLeague.ApplicationServices.API.Mappings
{
    public class TeamsProfile : Profile
    {
        public TeamsProfile()
        {
            this.CreateMap<AddTeamRequest, TyperLeague.DataAccess.Entities.Team>()
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name));

            this.CreateMap<TyperLeague.DataAccess.Entities.Team, Team>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name));
        }
    }
}
