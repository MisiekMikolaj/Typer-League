using FluentValidation;
using TyperLeague.ApplicationServices.API.Domain;

namespace TyperLeague.ApplicationServices.API.Validators
{
    public class AddTeamValidation : AbstractValidator<AddTeamRequest>
    {
        public AddTeamValidation()
        {
            this.RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
        }
    }
}
