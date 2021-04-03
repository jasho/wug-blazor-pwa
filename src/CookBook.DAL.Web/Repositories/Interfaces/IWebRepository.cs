using CookBook.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CookBook.DAL.Web.Repositories
{
    public interface IWebRepository<TEntity>
        where TEntity : IId
    {
        Task<IList<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(Guid id);
        Task InsertAsync(TEntity entity);
        Task RemoveAsync(Guid id);
    }
}