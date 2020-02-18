using System;
namespace NetCoreBookStores.Domain.Entities
{
    public class Book
    {
        public Book()
        {
        }

        public string Code { get; set; }

        public string Name { get; set; }

        public string Author { get; set; }

        public decimal Price { get; set; }
    }
}
