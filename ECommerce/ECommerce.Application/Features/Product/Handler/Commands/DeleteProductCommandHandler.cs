using AutoMapper;
using ECommerce.Application.Contracts.Persistency;
using ECommerce.Application.Exceptions;
using ECommerce.Application.Features.Product.Request.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Product.Handler.Commands
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteProductCommandHandler(IMapper mapper, IUnitOfWork unitOfWork) 
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.ProductRepository.Get(request.Id);
            if (product == null) throw new NotFoundException(nameof(product), request.Id);

            await _unitOfWork.ProductRepository.Delete(product);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
