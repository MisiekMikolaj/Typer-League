using FluentValidation;
using TyperLeague.ApplicationServices.API.Domain;

namespace TyperLeague.ApplicationServices.API.Validators
{
    public class EditUserPredictionBetResultRequestValidator : AbstractValidator<EditUserPredicionBetResultRequest>
    {
        public EditUserPredictionBetResultRequestValidator()
        {
            this.RuleFor(x => x.FirstTeamPointsUserPrediction).NotNull().GreaterThan(-1);
            this.RuleFor(x => x.SecondTeamPointsUserPrediction).NotNull().GreaterThan(-1);
            //this.RuleFor(x => x.BetId).NotNull().GreaterThan(0);
        }
    }
}
