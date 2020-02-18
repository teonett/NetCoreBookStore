using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCoreBookStores.Domain.Entities
{
    public class Product : Models.BaseModel
    {
        public Product()
        {
        }

        [Required]
        [Column(TypeName = "varchar(10)")]
        public string Code { get; private set; }

        [Required]
        [Column(TypeName = "varchar(80)")]
        public string Name { get; private set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Author { get; private set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; private set; }

        public Product(string code, string name, string author, decimal price)
        {
            this.Code = code;
            this.Name = name;
            this.Author = author;
            this.Price = price;
        }
    }
}
