using ECommerce.Application.Contracts.Persistency;
using ECommerce.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommercePersistence.Repositories
{
    public class CategoryRepositiry : GenericRepository<Categories>, ICategoryRepository
    {
        private readonly ECommerceDbContext _dbContext;

        public CategoryRepositiry(ECommerceDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
