using NetCoreBookStores.Domain.Entities;

namespace NetCoreBookStores.Models
{
    public class UpdateQuantityResponse
    {
        public UpdateQuantityResponse(OrderItem itemPedido, CartViewModel carrinhoViewModel)
        {
            ItemPedido = itemPedido;
            CarrinhoViewModel = carrinhoViewModel;
        }

        public OrderItem ItemPedido { get; }
        public CartViewModel CarrinhoViewModel { get; }
    }
}
