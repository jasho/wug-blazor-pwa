using CookBook.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CookBook.DAL.Web.Repositories
{
    public class RecipeRepository : IWebRepository<RecipeDetailModel>
    {
        private readonly LocalDb localDb;

        public RecipeRepository(LocalDb localDb)
        {
            this.localDb = localDb;
        }

        public async Task InsertAsync(RecipeDetailModel entity)
        {
            await localDb.InsertAsync(entity);
        }

        public Task<IList<RecipeDetailModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<RecipeDetailModel> GetByIdAsync(Guid id)
        {
            return await localDb.GetById<RecipeDetailModel>(id);
        }

        public Task RemoveAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}