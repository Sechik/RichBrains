using FluentValidation;
using RichBrains.Logic.Models;

namespace RichBrains.Logic.Validators
{
    public class UserValidator : AbstractValidator<UserDto>
    {
        public UserValidator()
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
                .Matches(@"^[+]*[(]{0,1}[0-9]{1,4}[)]{0,1}[-\s\./0-9]*$")
                .WithMessage("Invalid phone");
        }
    }
}
