using Microsoft.EntityFrameworkCore;
using Project.DAL.ContextClasses;
using Project.DAL.Repositories.Abstracts;
using Project.ENTITIES.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Repositories.Concretes
{
    public class BaseRepository<T> : IRepository<T> where T : class, IEntity
    {
        MyContext _db;
        public BaseRepository(MyContext db)
        {
            _db = db;
        }

        public async Task AddAsync(T item)
        {
           await _db.Set<T>().AddAsync(item);
            await SaveAsync();
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> exp)
        {
            return await _db.Set<T>().AnyAsync(exp);
        }

        public async Task DeleteAsync(T item)
        {
            item.DeletedDate = DateTime.Now;
            item.Status = ENTITIES.Enums.DataStatus.Deleted;
            await SaveAsync();
        }

        public async Task<T> FindAsync(int id)
        {
            return await _db.Set<T>().FindAsync(id);
        }

        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> exp)
        {
            return await _db.Set<T>().FirstOrDefaultAsync(exp);
        }

        public async Task<ICollection<T>> GetActivesAsync()
        {
            return await _db.Set<T>().Where(x =>x.Status == ENTITIES.Enums.DataStatus.Inserted).ToListAsync();
        }

        public async Task<ICollection<T>> GetAllAsync()
        {
           return await _db.Set<T>().ToListAsync();
        }

        public async Task<ICollection<T>> GetModifiedsAsync()
        {
            return await _db.Set<T>().Where(x => x.Status == ENTITIES.Enums.DataStatus.Updated).ToListAsync();

        }

        public async Task<ICollection<T>> GetPassiviesAsync()
        {
            return await _db.Set<T>().Where(x => x.Status == ENTITIES.Enums.DataStatus.Deleted).ToListAsync();
        }

        public async Task SaveAsync()
        {
          await _db.SaveChangesAsync();
        }

        public IQueryable<X> Select<X>(Expression<Func<T, X>> exp)
        {
            return _db.Set<T>().Select(exp);
        }

        public object Select(Expression<Func<T, object>> exp)
        {
            return _db.Set<T>().Select(exp);
        }

        public async Task UpdateAsync(T item)
        {
            item.Status = ENTITIES.Enums.DataStatus.Updated;
            item.ModifiedDate = DateTime.Now;
            T toBeUpdated = await _db.Set<T>().FindAsync(item.ID);
            _db.Entry(toBeUpdated).CurrentValues.SetValues(item);
            await SaveAsync();
        }

        public async Task<ICollection<T>> WhereAsync(Expression<Func<T, bool>> exp)
        {
           return await _db.Set<T>().Where(exp).ToListAsync();
        }
    }
}
