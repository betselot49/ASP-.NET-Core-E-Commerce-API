using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.DTOs.Category.Validators
{
    public class ICategoryDtoValidator : AbstractValidator<ICategoryDto>
    {
        public ICategoryDtoValidator() 
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} can not be greate than {ComparisonValue} characters.");
          
        }
    }
}
