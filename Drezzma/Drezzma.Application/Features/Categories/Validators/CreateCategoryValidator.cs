using Drezzma.Application.Features.Categories.DTOs;
using FluentValidation;

namespace Drezzma.Application.Features.Categories.Validators
{
    public class CreateCategoryValidator
    : AbstractValidator<CreateCategoryDto>
    {
        public CreateCategoryValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.DisplayOrder)
                .GreaterThanOrEqualTo(0);
        }
    }
}
