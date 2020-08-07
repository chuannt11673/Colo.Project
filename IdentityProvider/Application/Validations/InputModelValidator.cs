using Application.Models;
using FluentValidation;

namespace Application.Validations
{
    public class InputModelValidator : AbstractValidator<InputModel>
    {
        public InputModelValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.DOB).NotEmpty();
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Phone).NotEmpty().Matches(@"^\+(?:[0-9]●?){6,14}[0-9]$");
            RuleFor(x => x.Password).NotEmpty();
            RuleFor(x => x.ConfirmPassword).NotEmpty().Equal(x => x.Password).WithMessage("'Confirm Password' must be equal to 'Password'");
        }
    }
}
