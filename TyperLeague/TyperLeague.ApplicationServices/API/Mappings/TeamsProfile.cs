using AutoMapper;
using TyperLeague.ApplicationServices.API.Domain.Models;

namespace TyperLeague.ApplicationServices.API.Mappings
{
    public class TeamsProfile : Profile
    {
        public TeamsProfile()
        {
            this.CreateMap<TyperLeague.DataAccess.Entities.Team, Team>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name));
        }
    }
}
