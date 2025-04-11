using WebUniversity.DataLayer.Entity;

namespace WebUniversity.DataLayer.UnitOfWork.Repository
{
    public interface IRepository<T> where T : class, IEntity
    {
        IQueryable<T> GetAll();

        IEnumerable<T> GetAll(Func<T, bool> predicate);

        bool Insert(T entity);

        bool Update(T entity);

        bool Delete(T entity);

        T Find(int id);
    }
}
