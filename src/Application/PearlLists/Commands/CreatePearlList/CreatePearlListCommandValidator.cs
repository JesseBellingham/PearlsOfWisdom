using FluentValidation;

namespace PearlsOfWisdom.Application.PearlLists.Commands.CreatePearlList
{
    public class CreatePearlListCommandValidator : AbstractValidator<CreatePearlListCommand>
    {
        public CreatePearlListCommandValidator()
        {
            RuleFor(v => v.Title)
                .MaximumLength(200)
                .NotEmpty();
        }
    }
}