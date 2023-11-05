using ECommerce.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Contracts.Persistency
{
    public interface ICategoryRepository : IGenericRepository<Categories>
    {
    }

}
