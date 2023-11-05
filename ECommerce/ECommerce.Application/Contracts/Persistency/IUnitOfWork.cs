using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Contracts.Persistency
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepositiry ProductRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        Task Save();
    }
}
