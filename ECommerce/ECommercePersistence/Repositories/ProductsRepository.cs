using ECommerce.Application.Contracts.Persistency;
using ECommerce.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommercePersistence.Repositories
{
    public class ProductsRepository : GenericRepository<Products>, IProductRepositiry
    {
        private readonly ECommerceDbContext _dbContext;

        public ProductsRepository(ECommerceDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        } 
    }
}
