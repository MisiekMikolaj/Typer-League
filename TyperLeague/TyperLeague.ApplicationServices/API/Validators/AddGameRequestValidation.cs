using FluentValidation;
using TyperLeague.ApplicationServices.API.Domain;

namespace TyperLeague.ApplicationServices.API.Validators
{
    public class AddGameRequestValidation : AbstractValidator<AddGameRequest>
    {
        public AddGameRequestValidation()
        {
            this.RuleFor(x => x.FirstTeamName).NotEmpty().MaximumLength(100);
            this.RuleFor(x => x.SecondTeamName).NotEmpty().MaximumLength(100);
        }
    }
}
