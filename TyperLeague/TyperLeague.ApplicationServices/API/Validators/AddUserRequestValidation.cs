using FluentValidation;
using TyperLeague.ApplicationServices.API.Domain;

namespace TyperLeague.ApplicationServices.API.Validators
{
    public class AddUserRequestValidation : AbstractValidator<AddUserRequest>
    {
        public AddUserRequestValidation()
        {
            this.RuleFor(x => x.Name).NotEmpty().MaximumLength(50);
            this.RuleFor(x => x.Password).NotEmpty().MaximumLength(50);;
        }
    }
}
