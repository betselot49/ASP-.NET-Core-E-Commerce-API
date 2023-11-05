using AutoMapper;
using ECommerce.Application.Contracts.Persistency;
using ECommerce.Application.DTOs.Category.Validators;
using ECommerce.Application.Features.Category.Request.Commands;
using ECommerce.Application.Responses;
using ECommerce.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Category.Handler.Commands
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, BaseCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateCategoryCommandHandler(IMapper mapper, IUnitOfWork unitOfWork) 
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }


        public async Task<BaseCommandResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateCategoryDtoValidator();
            var validatorResult = await validator.ValidateAsync(request.CategoryDto);

            if (validatorResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Category Creation Faild";
                response.Errors = validatorResult.Errors.Select(q => q.ErrorMessage).ToList();
            }

            else
            {
                var category = _mapper.Map<Categories>(request.CategoryDto);

                category = await _unitOfWork.CategoryRepository.Add(category);
                await _unitOfWork.Save();

                response.Success = true;
                response.Message = "Category Creation Successful";
                response.Id = category.Id;
            }

            return response;
        }
    }
}
