using FluentValidation;

namespace Application.Homes.Commands.Validators;

public class CreateHomeCommandValidator : AbstractValidator<CreateHomeCommand>
{
    public CreateHomeCommandValidator()
    {
        RuleFor(a => a.Home).NotNull();
        RuleFor(a => a.Home.Name).NotEmpty();
        RuleFor(a => a.Home.UserId).NotEmpty();
        RuleFor(a => a.Home.Rooms).NotEmpty().NotNull();
        RuleForEach(a => a.Home.Rooms).ChildRules(room =>
        {
            room.RuleFor(r => r.Name).NotEmpty();
        });
    }
}
