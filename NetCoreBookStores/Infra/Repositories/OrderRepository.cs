 using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using NetCoreBookStores.Domain.Entities;
using NetCoreBookStores.Infra.Interface;
using NetCoreBookStores.Models;

namespace NetCoreBookStores.Infra.Repositories
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        private readonly ApplicationContext applicationContext;
        private readonly IHttpContextAccessor contextAccessor;
        private readonly IOrderItemRepository itemPedidoRepository;
        private readonly IAccountRepository cadastroRepository;

        public OrderRepository(ApplicationContext context,
            IHttpContextAccessor contextAccessor,
            IOrderItemRepository itemPedidoRepository,
            IAccountRepository cadastroRepository) : base(context)
        {
            this.applicationContext = context;
            this.contextAccessor = contextAccessor;
            this.itemPedidoRepository = itemPedidoRepository;
            this.cadastroRepository = cadastroRepository;
        }

        public async Task<Order> GetPedido()
        {
            var pedidoId = GetPedidoId();
            var pedido =
                await dbSet
                .Include(p => p.Itens)
                    .ThenInclude(i => i.Produto)
                .Include(p => p.Cadastro)
                .Where(p => p.Id == pedidoId)
                .SingleOrDefaultAsync();

            if (pedido == null)
            {
                pedido = new Order();
                dbSet.Add(pedido);
                await applicationContext.SaveChangesAsync();
                SetPedidoId(pedido.Id);
            }

            return pedido;
        }

        public int? GetPedidoId()
        {
            return contextAccessor.HttpContext.Session.GetInt32("pedidoId");
        }

        public async Task AddItem(string codigo)
        {
            var produto = await applicationContext.Set<Product>()
                            .Where(p => p.Code == codigo)
                            .SingleOrDefaultAsync();

            if (produto == null)
            {
                throw new ArgumentException("Produto não encontrado");
            }

            var pedido = await GetPedido();

            var itemPedido = await applicationContext.Set<OrderItem>()
                                .Where(i => i.Produto.Code == codigo
                                        && i.Pedido.Id == pedido.Id)
                                .SingleOrDefaultAsync();

            if (itemPedido == null)
            {
                itemPedido = new OrderItem(pedido, produto, 1, produto.Price);

                await applicationContext.Set<OrderItem>()
                    .AddAsync(itemPedido);

                await applicationContext.SaveChangesAsync();
            }
        }

        public void SetPedidoId(int pedidoId)
        {
            contextAccessor.HttpContext.Session.SetInt32("pedidoId", pedidoId);
        }

        public async Task<Order> UpdateCadastro(Account cadastro)
        {
            var pedido = await GetPedido();
            await cadastroRepository.Update(pedido.Cadastro.Id, cadastro);
            return pedido;
        }

        public async Task<UpdateQuantityResponse> UpdateQuantidade(OrderItem itemPedido)
        {
            var itemPedidoDB = await itemPedidoRepository.GetItemPedido(itemPedido.Id);

            if (itemPedidoDB != null)
            {
                itemPedidoDB.AtualizaQuantidade(itemPedido.Quantidade);

                if (itemPedido.Quantidade == 0)
                {
                    await itemPedidoRepository.RemoveItemPedido(itemPedido.Id);
                }

                await applicationContext.SaveChangesAsync();

                var pedido = await GetPedido();
                var carrinhoViewModel = new CartViewModel(pedido.Itens);

                return new UpdateQuantityResponse(itemPedidoDB, carrinhoViewModel);
            }

            throw new ArgumentException("ItemPedido não encontrado");
        }
    }
}
