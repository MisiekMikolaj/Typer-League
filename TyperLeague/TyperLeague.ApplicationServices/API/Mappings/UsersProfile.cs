using AutoMapper;
using TyperLeague.ApplicationServices.API.Domain.Models;

namespace TyperLeague.ApplicationServices.API.Mappings
{
    public class UsersProfile : Profile
    {
        public UsersProfile()
        {
            this.CreateMap<TyperLeague.DataAccess.Entities.User, User>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.Points, y => y.MapFrom(z => z.Points))
                .ForMember(x => x.IsAdmin, y => y.MapFrom(z => z.IsAdmin));
        }
    }
}
