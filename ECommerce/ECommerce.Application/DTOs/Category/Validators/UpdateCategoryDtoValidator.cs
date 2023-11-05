using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.DTOs.Category.Validators
{
    public class UpdateCategoryDtoValidator : AbstractValidator<CategoryDto>
    {
        public UpdateCategoryDtoValidator()
        {
            Include(new ICategoryDtoValidator());

            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .WithMessage("{PropertyName} must pe provided");

        }
    }
}
