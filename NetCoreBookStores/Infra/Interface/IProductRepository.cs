using System.Collections.Generic;
using System.Threading.Tasks;
using NetCoreBookStores.Domain.Entities;

namespace NetCoreBookStores.Infra.Interface
{
    public interface IProductRepository
    {
        Task Save(List<Book> books);

        Task<IList<Product>> GetAll();
    }
}
