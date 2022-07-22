using CandidateManagement.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement.Infra.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        
        protected readonly CandidateManagementDBContext _context;

        protected DbSet<TEntity> _dbSet
        {
            get
            {
                return _context.Set<TEntity>();
            }
        }


        public Repository(CandidateManagementDBContext context)
        {
            _context = context;
        }

        public bool Update(TEntity model)
        {
            try
            {
                var entry = _context.Entry(model);

                _dbSet.Attach(model);

                entry.State = EntityState.Modified;

                return Save() > 0;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Update(List<TEntity> models)
        {
            try
            {
                foreach (var registro in models)
                {
                    var entry = _context.Entry(registro);
                    _dbSet.Attach(registro);
                    entry.State = EntityState.Modified;
                }

                return Save() > 0;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public TEntity Create(TEntity model)
        {
            try
            {
                _dbSet.Add(model);
                Save();
                return model;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<TEntity> Create(List<TEntity> model)
        {
            try
            {
                _dbSet.AddRange(model);
                Save();
                return model;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool Delete(TEntity model)
        {
            try
            {
                var _entry = _context.Entry(model);
                _dbSet.Remove(model);
                _entry.State = EntityState.Deleted;
                return Save() > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Delete(params object[] Keys)
        {
            try
            {
                var model = _dbSet.Find(Keys);
                return (model != null) && Delete(model);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Delete(Expression<Func<TEntity, bool>> where)
        {
            try
            {
                var model = _dbSet.Where<TEntity>(where).FirstOrDefault<TEntity>();

                return (model != null) && Delete(model);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int Save()
        {
            try
            {
                return _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public TEntity Find(params object[] Keys)
        {
            try
            {
                return _dbSet.Find(Keys);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public TEntity Find(Expression<Func<TEntity, bool>> where)
        {
            try
            {
                return _dbSet.AsNoTracking().FirstOrDefault(where);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public TEntity Find(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, object> includes)
        {
            try
            {
                IQueryable<TEntity> _query = _dbSet;

                if (includes != null)
                    _query = includes(_query) as IQueryable<TEntity>;

                return _query.SingleOrDefault(predicate);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> where)
        {
            try
            {
                return _dbSet.Where(where);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, object> includes)
        {
            try
            {
                IQueryable<TEntity> _query = _dbSet;

                if (includes != null)
                    _query = includes(_query) as IQueryable<TEntity>;

                return _query.Where(predicate).AsQueryable();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<TEntity> GetAsync(params object[] Keys)
        {
            try
            {
                return await _dbSet.FindAsync(Keys);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> where)
        {
            try
            {
                return await _dbSet.AsNoTracking().FirstOrDefaultAsync(where);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<TEntity> CreateAsync(TEntity model)
        {
            try
            {
                _dbSet.Add(model);
                await SaveAsync();
                return model;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> UpdateAsync(TEntity model)
        {
            try
            {
                var entry = _context.Entry(model);

                _dbSet.Attach(model);

                entry.State = EntityState.Modified;

                return await SaveAsync() > 0;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> DeleteAsync(TEntity model)
        {
            try
            {
                var entry = _context.Entry(model);

                _dbSet.Attach(model);

                entry.State = EntityState.Deleted;

                return await SaveAsync() > 0;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> DeleteAsync(params object[] Keys)
        {
            try
            {
                var model = _dbSet.Find(Keys);
                return (model != null) && await DeleteAsync(model);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> DeleteAsync(Expression<Func<TEntity, bool>> where)
        {
            try
            {
                var model = _dbSet.FirstOrDefault(where);

                return (model != null) && await DeleteAsync(model);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<int> SaveAsync()
        {
            try
            {
                return await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Dispose()
        {
            try
            {
                if (_context != null)
                    _context.Dispose();
                GC.SuppressFinalize(this);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
