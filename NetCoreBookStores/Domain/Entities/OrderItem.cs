using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NetCoreBookStores.Models;

namespace NetCoreBookStores.Domain.Entities
{
    public class OrderItem : BaseModel
    {
        public OrderItem()
        {
        }

        [Required]
        public Order Pedido { get; private set; }

        [Required]
        public Product Produto { get; private set; }

        [Required]
        [Column(TypeName = "int")]
        public int Quantidade { get; private set; }

        [Required]
        [Column(TypeName = "decimal")]
        public decimal PrecoUnitario { get; private set; }

        public OrderItem(Order pedido, Product produto, int quantidade, decimal precoUnitario)
        {
            Pedido = pedido;
            Produto = produto;
            Quantidade = quantidade;
            PrecoUnitario = precoUnitario;
        }

        internal void AtualizaQuantidade(int quantidade)
        {
            throw new NotImplementedException();
        }
    }
}
