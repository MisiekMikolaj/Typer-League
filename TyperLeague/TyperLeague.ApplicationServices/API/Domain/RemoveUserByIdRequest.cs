using MediatR;

namespace TyperLeague.ApplicationServices.API.Domain
{
    public class RemoveUserByIdRequest : BaseRequest, IRequest<RemoveUserByIdResponse>
    {
        public int UserId { get; set; }
    }
}
