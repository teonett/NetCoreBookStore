using System.Collections.Generic;
using System.Linq;
using NetCoreBookStores.Domain.Entities;

namespace NetCoreBookStores.Models
{
    public class CartViewModel
    {
        public CartViewModel(IList<OrderItem> itens)
        {
            Itens = itens;
        }

        public IList<OrderItem> Itens { get; }

        public decimal Total => Itens.Sum(i => i.Quantidade * i.PrecoUnitario);
    }
}
