using Microsoft.EntityFrameworkCore;
using NetCoreBookStores.Models;

namespace NetCoreBookStores.Infra.Repositories
{
    public abstract class BaseRepository<T> where T : BaseModel
    {
        protected readonly ApplicationContext context;
        protected readonly DbSet<T> dbSet;

        public BaseRepository(ApplicationContext _context)
        {
            this.context = _context;
            dbSet = context.Set<T>();
        }
    }
}
