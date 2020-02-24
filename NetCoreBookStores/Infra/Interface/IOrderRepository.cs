using System.Threading.Tasks;
using NetCoreBookStores.Domain.Entities;
using NetCoreBookStores.Models;

namespace NetCoreBookStores.Infra.Interface
{
    public interface IOrderRepository
    {
        Task<Order> GetPedido();
        int? GetPedidoId();
        Task AddItem(string codigo);
        void SetPedidoId(int pedidoId);
        Task<UpdateQuantityResponse> UpdateQuantidade(OrderItem itemPedido);
        Task<Order> UpdateCadastro(Account cadastro);
    }
}
