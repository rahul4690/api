using Microsoft.EntityFrameworkCore;
using Repository.Data.Context;
using Repository.Data.Services.IServices;
using Repository.Models.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data.Services
{
    public class DataAccess<T> : IDataAccess<T> where T : class
    {
        private readonly ApplicationDbContext _applicationDbContext;
        internal DbSet<T> dbset;
        public DataAccess(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            dbset = _applicationDbContext.Set<T>();
        }

        public async Task<T> GetById(Guid id)
        {
            return await dbset.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null)
        {
            IQueryable<T> query = dbset;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }
            return await query.ToListAsync();
        }

        public async Task Add(T entity)
        {
            await dbset.AddAsync(entity);
        }

        public void Update(T entity)
        {
            dbset.Update(entity);
        }

        #region //Analytics

        public async Task<int> GetUserCount()
        {
            IQueryable<T> query = dbset;
            var _query = await query.ToListAsync();
            return _query.Count();
        }

        #endregion

    }
}
