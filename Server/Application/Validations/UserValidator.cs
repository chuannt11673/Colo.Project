using Application.Models;
using FluentValidation;

namespace Application.Validations
{
    public class UserValidator : AbstractValidator<UserModel>
    {
        public UserValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email cannot be null or empty");            
        }
    }
}
