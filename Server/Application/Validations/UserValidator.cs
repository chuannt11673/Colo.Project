using Application.Models;
using FluentValidation;

namespace Application.Validations
{
    public class UserValidator : AbstractValidator<UserModel>
    {
        public UserValidator()
        {
        }
    }
}
