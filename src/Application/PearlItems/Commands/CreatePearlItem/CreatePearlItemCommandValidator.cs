using FluentValidation;

namespace PearlsOfWisdom.Application.PearlItems.Commands.CreatePearlItem
{
    public class CreatePearlItemCommandValidator : AbstractValidator<CreatePearlItemCommand>
    {
        public CreatePearlItemCommandValidator()
        {
            RuleFor(v => v.Title)
                .MaximumLength(200)
                .NotEmpty();
        }
    }
}