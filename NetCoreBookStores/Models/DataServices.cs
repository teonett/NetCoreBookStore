using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NetCoreBookStores.Domain.Entities;
using NetCoreBookStores.Infra.Interface;
using NetCoreBookStores.Models.Interface;
using Newtonsoft.Json;

namespace NetCoreBookStores.Models
{
    public class DataServices : IDataServices
    {
        private readonly ApplicationContext context;
        private readonly IProductRepository productRepository;

        public DataServices(ApplicationContext _context, IProductRepository _productRepository)
        {
            this.context = _context;
            this.productRepository = _productRepository;
        }

        public async Task StartDB()
        {
            await context.Database.MigrateAsync();
            List<Book> books = await GetBooks();
            await productRepository.Save(books);

        }

        private static async Task<List<Book>> GetBooks()
        {
            var fileResult = await File.ReadAllTextAsync("./books.json");
            List<Book> result = JsonConvert.DeserializeObject<List<Book>>(fileResult.ToString());
            return result;
        }
    }
}
