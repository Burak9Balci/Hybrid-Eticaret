using Project.BLL.Managers.Abstracts;
using Project.DAL.Repositories.Abstracts;
using Project.ENTITIES.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Managers.Concretes
{
    public class BaseManager<T> : IManager<T> where T : class, IEntity
    {
        IRepository<T> _iRep;
        public BaseManager(IRepository<T> iRep)
        {
            _iRep = iRep;
        }
        public async Task AddAsync(T item)
        {
           await _iRep.AddAsync(item);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> exp)
        {
            return await _iRep.AnyAsync(exp);
        }

        public async Task DeleteAsync(T item)
        {
            await _iRep.DeleteAsync(item);
        }

        public async Task<T> FindAsync(int id)
        {
            return await _iRep.FindAsync(id);
        }
        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> exp)
        {
            return await _iRep.FirstOrDefaultAsync(exp) ;
        }

        public async Task<ICollection<T>> GetActivesAsync()
        {
            return await _iRep.GetActivesAsync();
        }

        public async Task<ICollection<T>> GetAllAsync()
        {
            return await _iRep.GetAllAsync();
        }

        public async Task<ICollection<T>> GetModifiedsAsync()
        {
            return await _iRep.GetModifiedsAsync();
        }

        public async Task<ICollection<T>> GetPassiviesAsync()
        {
            return await _iRep.GetPassiviesAsync();
        }

        public IQueryable<X> Select<X>(Expression<Func<T, X>> exp)
        {
            return _iRep.Select(exp);
        }

        public object Select(Expression<Func<T, object>> exp)
        {
            return _iRep.Select(exp); ;
        }

        public async Task UpdateAsync(T item)
        {
            await _iRep.UpdateAsync(item) ;
        }

        public async Task<ICollection<T>> WhereAsync(Expression<Func<T, bool>> exp)
        {
            return await _iRep.WhereAsync(exp);
        }
    }
}
