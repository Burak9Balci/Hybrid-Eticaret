using Project.ENTITIES.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Repositories.Abstracts
{
    public interface IRepository<T> where T : IEntity
    {
         Task SaveAsync();
         Task AddAsync(T item);
         Task DeleteAsync(T item);
         Task UpdateAsync(T item);

         Task<ICollection<T>> GetAllAsync();    
         Task<ICollection<T>> GetPassiviesAsync();
         Task<ICollection<T>> GetActivesAsync();
         Task<ICollection<T>> GetModifiedsAsync();

         Task<bool> AnyAsync(Expression<Func<T,bool>> exp);
         Task<T> FindAsync(int id);
         Task<T> FirstOrDefaultAsync(Expression<Func<T,bool>> exp);
         IQueryable<X> Select<X>(Expression<Func<T,X>> exp);
         object Select(Expression<Func<T, object>> exp);
         Task<ICollection<T>> WhereAsync(Expression<Func<T, bool>> exp);

    }
}
