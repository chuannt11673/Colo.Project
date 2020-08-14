using Application.Models;
using FluentValidation;

namespace Application.Validations
{
    public class InputModelValidator : AbstractValidator<InputModel>
    {
        public InputModelValidator()
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Password).NotEmpty();
            RuleFor(x => x.ConfirmPassword).NotEmpty().Equal(x => x.Password).WithMessage("'Confirm Password' must be equal to 'Password'");
        }
    }
}
