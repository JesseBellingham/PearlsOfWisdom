using FluentValidation;

namespace PearlsOfWisdom.Application.PearlItems.Commands.CreatePearlItem
{
    public class CreatePearlListCommandValidator : AbstractValidator<CreatePearlItemCommand>
    {
        public CreatePearlListCommandValidator()
        {
            RuleFor(v => v.Title)
                .MaximumLength(200)
                .NotEmpty();
        }
    }
}