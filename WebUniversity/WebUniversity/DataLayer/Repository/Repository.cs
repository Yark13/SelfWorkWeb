using Microsoft.EntityFrameworkCore;
using System.Data;
using WebUniversity.DataLayer.Entity;

namespace WebUniversity.DataLayer.UnitOfWork.Repository
{
    public class Repository<T> : IRepository<T> where T : class, IEntity
    {
        private DbContext _context;
        protected DbSet<T> _dbSet = default!;

        private DbSet<T> Entities
        {
            get
            {
                if (_dbSet == null)
                {
                    _dbSet = _context.Set<T>() ?? throw new ArgumentNullException("Undefined DB set");
                }
                return _dbSet;
            }
        }

        public Repository(DbContext context)
        {
            _context = context;
        }

        public IQueryable<T> GetAll()
        {
            return from e in Entities select e;

        }

        public IEnumerable<T> GetAll(Func<T, bool> predicate)
        {
            return GetAll().Where(predicate);
        }

        public bool Insert(T entity)
        {
            try
            {
                _context.Set<T>().Add(entity);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Update(T entity)
        {
            try
            {
                var excistingEntity = _context.Set<T>().Find(entity.Id);
                if (excistingEntity != null)
                {
                    _context.Entry(excistingEntity).CurrentValues.SetValues(entity);
                    _context.SaveChanges();
                    return true;
                }

                throw new Exception();
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Delete(T entity)
        {
            try
            {
                _context.Remove(entity);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public T Find(int id)
        {
            return _context.Find<T>(id);
        }
    }
}
