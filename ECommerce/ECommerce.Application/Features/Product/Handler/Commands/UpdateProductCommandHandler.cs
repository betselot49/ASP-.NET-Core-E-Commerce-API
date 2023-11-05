using AutoMapper;
using ECommerce.Application.Contracts.Persistency;
using ECommerce.Application.DTOs.Product.Validators;
using ECommerce.Application.Exceptions;
using ECommerce.Application.Features.Product.Request.Commands;
using ECommerce.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Product.Handler.Commands
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, BaseCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateProductCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<BaseCommandResponse> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new UpdateProductDtoValidator();
            var validationResult = await validator.ValidateAsync(request.ProductsDto);

            if ( validationResult.IsValid == false )
            {
                response.Success = false;
                response.Message = "Product Updation Faild";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var product = await _unitOfWork.ProductRepository.Get(request.ProductsDto.Id);

                if (product is null)
                    throw new NotFoundException(nameof(product), request.ProductsDto.Id);

                var category = await _unitOfWork.CategoryRepository.Get(request.ProductsDto.CategoryId);

                if (category is null) 
                    throw new NotFoundException(nameof(category), request.ProductsDto.CategoryId);

                _mapper.Map(request.ProductsDto, product);

                await _unitOfWork.ProductRepository.Update(product);
                await _unitOfWork.Save();

                response.Success = true;
                response.Message = "Product Updation Successful";
                response.Id = product.Id;
            }
                //throw new ValidationException(validationResult);

            return response;
        }
    }
}
