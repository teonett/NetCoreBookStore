using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NetCoreBookStores.Domain.Entities;
using NetCoreBookStores.Infra.Interface;
using NetCoreBookStores.Models;

namespace NetCoreBookStores.Infra.Repositories
{
    public class AccountRepository : BaseRepository<Account>, IAccountRepository
    {
        public AccountRepository(ApplicationContext context) : base(context)
        {
        }

        public async Task<Account> Update(int cadastroId, Account novoCadastro)
        {
            var cadastroDB =
                await dbSet.Where(c => c.Id == cadastroId)
                .SingleOrDefaultAsync();

            if (cadastroDB == null)
            {
                throw new ArgumentNullException("cadastro");
            }

            cadastroDB.Update(novoCadastro);
            await context.SaveChangesAsync();
            return cadastroDB;
        }
    }
}
