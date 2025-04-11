using Microsoft.EntityFrameworkCore;
using WebUniversity.DataLayer.Entity;
using WebUniversity.DataLayer.UnitOfWork.Repository;

namespace WebUniversity.DataLayer.UnitOfWork
{
    public interface IUnitOfWork<T> where T : DbContext
    {
        public Repository<T1> GetRepository<T1>() where T1 : class, IEntity;
    }
}
