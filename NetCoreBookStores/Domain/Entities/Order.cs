using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NetCoreBookStores.Models;

namespace NetCoreBookStores.Domain.Entities
{
    public class Order : BaseModel
    {
        public Order()
        {
            Cadastro = new Account();
        }

        public Order(Account cadastro)
        {
            Cadastro = cadastro;
        }

        public List<OrderItem> Itens { get; private set; } = new List<OrderItem>();

        [ForeignKey("FK_Pedido_Cadastro")]

        [Required]
        public virtual Account Cadastro { get; private set; }
    }
}
