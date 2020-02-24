using System;
using System.Threading.Tasks;
using NetCoreBookStores.Domain.Entities;
using NetCoreBookStores.Infra.Interface;

namespace NetCoreBookStores.Infra.Repositories
{
    public class OrderItemRepository : IOrderItemRepository
    {
        public OrderItemRepository()
        {
        }

        public Task<OrderItem> GetItemPedido(int itemPedidoId)
        {
            throw new NotImplementedException();
        }

        public Task RemoveItemPedido(int itemPedidoId)
        {
            throw new NotImplementedException();
        }
    }
}
