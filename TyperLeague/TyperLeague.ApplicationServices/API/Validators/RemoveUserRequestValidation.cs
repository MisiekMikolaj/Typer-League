using FluentValidation;
using TyperLeague.ApplicationServices.API.Domain;

namespace TyperLeague.ApplicationServices.API.Validators
{
    internal class RemoveUserRequestValidation : AbstractValidator<RemoveUserByIdRequest>
    {
        public RemoveUserRequestValidation()
        {
            this.RuleFor(x => x.UserId).NotNull().GreaterThan(0);
        }
    }
}
