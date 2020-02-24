using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NetCoreBookStores.Models;

namespace NetCoreBookStores.Domain.Entities
{
    public class Account : BaseModel
    {
        public Account()
        {
        }

        public virtual Order Pedido { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Nome { get; set; } = "";

        [Required]
        [Column(TypeName = "varchar(200)")]
        public string Email { get; set; } = "";

        [Required]
        [Column(TypeName = "varchar(20)")]
        public string Telefone { get; set; } = "";

        [Required]
        [Column(TypeName = "varchar(200)")]
        public string Endereco { get; set; } = "";

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Complemento { get; set; } = "";

        internal void Update(Account novoCadastro)
        {
            throw new NotImplementedException();
        }

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Bairro { get; set; } = "";

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Municipio { get; set; } = "";

        [Required]
        [Column(TypeName = "varchar(2)")]
        public string UF { get; set; } = "";

        [Required]
        [Column(TypeName = "varchar(10)")]
        public string CEP { get; set; } = "";
    }
}
