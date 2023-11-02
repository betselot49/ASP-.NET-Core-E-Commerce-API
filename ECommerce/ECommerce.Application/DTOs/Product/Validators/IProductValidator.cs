using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.DTOs.Product.Validators
{
    public class IProductValidator : AbstractValidator<IProductDto>
    {
        public IProductValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} can not be greate than {ComparisonValue} characters.");

            RuleFor(p => p.Price)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .GreaterThanOrEqualTo(0).WithMessage("{PropertyName} must be at least 0.");

            RuleFor(p => p.StockQuantity)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .GreaterThanOrEqualTo(0).WithMessage("{PropertyName} must be at least 0.");

             RuleFor(p => p.CategoryId)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull();
        }
    }
}
