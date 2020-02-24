using System.Threading.Tasks;
using NetCoreBookStores.Domain.Entities;

namespace NetCoreBookStores.Infra.Interface
{
    public interface IOrderItemRepository
    {
        Task<OrderItem> GetItemPedido(int itemPedidoId);
        Task RemoveItemPedido(int itemPedidoId);
    }
}
