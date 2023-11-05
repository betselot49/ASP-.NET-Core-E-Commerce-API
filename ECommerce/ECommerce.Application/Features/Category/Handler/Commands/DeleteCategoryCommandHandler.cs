using ECommerce.Application.Contracts.Persistency;
using ECommerce.Application.Exceptions;
using ECommerce.Application.Features.Category.Request.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Category.Handler.Commands
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCategoryCommandHandler(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _unitOfWork.CategoryRepository.Get(request.Id);
            if (category == null) throw new NotFoundException(nameof(category), request.Id);

            await _unitOfWork.CategoryRepository.Delete(category);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
