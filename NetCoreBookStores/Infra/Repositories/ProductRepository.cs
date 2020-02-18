using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NetCoreBookStores.Domain.Entities;
using NetCoreBookStores.Infra.Interface;
using NetCoreBookStores.Models;

namespace NetCoreBookStores.Infra.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationContext context) : base(context)
        {
        }

        public async Task<IList<Product>> GetAll()
        {
            return await dbSet.ToListAsync();
        }

        public async Task Save(List<Book> books)
        {
            foreach(var item in books)
            {
                if(!await dbSet.Where(x => x.Code == item.Code).AnyAsync())
                {
                    await dbSet.AddAsync(new Product(item.Code, item.Name, item.Author, item.Price));
                }
            }

            await context.SaveChangesAsync();
        }
    }
}
