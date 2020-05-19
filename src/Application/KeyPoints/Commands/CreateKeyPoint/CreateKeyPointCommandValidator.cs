using FluentValidation;

namespace PearlsOfWisdom.Application.KeyPoints.Commands.CreateKeyPoint
{
    public class CreateKeyPointCommandValidator : AbstractValidator<CreateKeyPointCommand>
    {
        public CreateKeyPointCommandValidator()
        {
            RuleFor(_ => _.Text)
                .NotEmpty();
        }
    }
}