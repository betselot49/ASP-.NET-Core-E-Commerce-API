using AutoMapper;
using ECommerce.Application.Contracts.Persistency;
using ECommerce.Application.DTOs.Product.Validators;
using ECommerce.Application.Features.Product.Request.Commands;
using ECommerce.Application.Responses;
using ECommerce.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Product.Handler.Commands
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateProductHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateProductValidator();
            var validatorResult = await validator.ValidateAsync(request.ProductDto);

            if (validatorResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Product Creation Faild";
                response.Errors = validatorResult.Errors.Select(q => q.ErrorMessage).ToList();
            }

            else
            {
                var product = _mapper.Map<Products>(request.ProductDto);

                product = await _unitOfWork.ProductRepository.Add(product);
                await _unitOfWork.Save();

                response.Success = true;
                response.Message = "Product Creation Successful";
                response.Id = product.Id;
            }

            return response;
        }
    }
}
