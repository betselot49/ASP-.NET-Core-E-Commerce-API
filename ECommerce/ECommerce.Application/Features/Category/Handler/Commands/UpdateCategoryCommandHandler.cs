using AutoMapper;
using ECommerce.Application.Contracts.Persistency;
using ECommerce.Application.DTOs.Category.Validators;
using ECommerce.Application.DTOs.Product.Validators;
using ECommerce.Application.Exceptions;
using ECommerce.Application.Features.Category.Request.Commands;
using ECommerce.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Category.Handler.Commands;

public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, BaseCommandResponse>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCategoryCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }


    public async Task<BaseCommandResponse> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseCommandResponse();
        var validator = new UpdateCategoryDtoValidator();
        var validationResult = await validator.ValidateAsync(request.Category);

        if (validationResult.IsValid == false)
        {
            response.Success = false;
            response.Message = "Category Updation Faild";
            response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
        }
        else
        {
            var category = await _unitOfWork.CategoryRepository.Get(request.Category.Id);

            if (category is null)
                throw new NotFoundException(nameof(category), request.Category.Id);

            _mapper.Map(request.Category, category);

            await _unitOfWork.CategoryRepository.Update(category);
            await _unitOfWork.Save();

            response.Success = true;
            response.Message = "Category Updation Successful";
            response.Id = category.Id;
        }
        //throw new ValidationException(validationResult);

        return response;
    }
}
