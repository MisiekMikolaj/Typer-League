using FluentValidation;
using TyperLeague.ApplicationServices.API.Domain;

namespace TyperLeague.ApplicationServices.API.Validators
{
    public class EditGamePointsRequestValidation : AbstractValidator<EditGamePointsRequest>
    {
        public EditGamePointsRequestValidation()
        {
            this.RuleFor(x => x.FirstTeamPoints).NotNull().GreaterThan(-1);
            this.RuleFor(x => x.SecondTeamPoints).NotNull().GreaterThan(-1);
            //this.RuleFor(x => x.GameId).NotNull().GreaterThan(0);
        }
    }
}
