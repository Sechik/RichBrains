using FluentValidation;
using RichBrains.Logic.Models;

namespace RichBrains.Logic.Validators
{
    public class UserValidator : AbstractValidator<UserDto>
    {
        public UserValidator()
        {
            RuleSet("UserPreValidation", () =>
            {
                RuleFor(u => u.LastName)
                    .Length(2, 30)
                    .WithMessage("Invalid Lastname");
                RuleFor(u => u.FirstName)
                    .Length(2, 30)
                    .WithMessage("Invalid Firstname");
                RuleFor(u => u.Email)
                    .EmailAddress()
                    .WithMessage("Invalid email");
                RuleFor(u => u.Phone)
                    .Matches(@"^\+[0-9]{7,}$")
                    .WithMessage("Invalid phone");
            });
        }
    }
}
