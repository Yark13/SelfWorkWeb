using Microsoft.EntityFrameworkCore;
using WebUniversity.DataLayer.UnitOfWork.Repository;

namespace WebUniversity.DataLayer.UnitOfWork
{
    public class UnitOfWork<TContext> : IUnitOfWork<TContext> where TContext : DbContext
    {
        private readonly DbContext _context;

        public UnitOfWork(TContext context)
        {
            _context = context;
        }

        Repository<TEntity> IUnitOfWork<TContext>.GetRepository<TEntity>()
        {
            return new Repository<TEntity>(_context);
        }
    }
}
