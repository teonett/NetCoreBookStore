using System.Threading.Tasks;
using NetCoreBookStores.Domain.Entities;

namespace NetCoreBookStores.Infra.Interface
{
    public interface IAccountRepository
    {
        Task<Account> Update(int cadastroId, Account novoCadastro);
    }
}
 