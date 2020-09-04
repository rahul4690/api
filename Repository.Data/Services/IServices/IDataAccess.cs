using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data.Services.IServices
{
    public interface IDataAccess<T> where T : class
    {
        Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null);
        Task<T> GetById(Guid id);
        Task Add(T entity);
        void Update(T entity);
        Task<int> GetUserCount();
    }
}
