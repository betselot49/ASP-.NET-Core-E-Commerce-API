using ECommerce.Application.Constants;
using ECommerce.Application.Contracts.Persistency;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommercePersistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ECommerceDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private IProductRepositiry _productRepository;
        private ICategoryRepository _categoryRepository;

        public UnitOfWork(ECommerceDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }


        public IProductRepositiry ProductRepository => 
            _productRepository ??= new ProductsRepository(_context);

        public ICategoryRepository CategoryRepository => 
            _categoryRepository ??= new CategoryRepositiry(_context);


        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
            var username = _httpContextAccessor?.HttpContext?.User.FindFirst(CustomClaimTypes.Uid)?.Value;
            await _context.SaveChangesAsync(username);
        }
    }
}
