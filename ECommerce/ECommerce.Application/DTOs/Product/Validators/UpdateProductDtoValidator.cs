using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.DTOs.Product.Validators;

public class UpdateProductDtoValidator : AbstractValidator<ProductsDto>
{
    public UpdateProductDtoValidator()
    {
        Include(new IProductValidator());

        RuleFor(p => p.Id)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .WithMessage("{PropertyName} must pe provided");
    }
}
