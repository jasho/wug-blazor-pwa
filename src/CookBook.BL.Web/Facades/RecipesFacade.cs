using AutoMapper;
using CookBook.ApiClients;
using CookBook.DAL.Web.Repositories;
using CookBook.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace CookBook.BL.Web.Facades
{
    public class RecipesFacade : FacadeBase
    {
        private readonly IRecipeClient recipeClient;
        private readonly RecipeRepository recipeRepository;
        private readonly IMapper mapper;

        public RecipesFacade(
            IRecipeClient recipeClient,
            RecipeRepository recipeRepository,
            IMapper mapper)
        {
            this.recipeClient = recipeClient;
            this.recipeRepository = recipeRepository;
            this.mapper = mapper;
        }

        public async Task<ICollection<RecipeListModel>> GetRecipesAsync()
        {
            var recipesFromApi = await recipeClient.RecipeGetAsync(apiVersion, culture);
            var recipesLocal = await recipeRepository.GetAllAsync();

            var recipesAll = new List<RecipeListModel>();
            recipesAll.AddRange(recipesFromApi);
            recipesAll.AddRange(mapper.Map<IList<RecipeListModel>>(recipesLocal));

            return recipesAll;
        }

        public async Task<RecipeDetailModel> GetRecipeAsync(Guid id)
        {
            return await recipeClient.RecipeGetAsync(id, apiVersion, culture);
        }

        public async Task SaveAsync(RecipeDetailModel data)
        {
            try
            {
                if (data.Id == Guid.Empty)
                {
                    await recipeClient.RecipePostAsync(apiVersion, culture, data);
                }
                else
                {
                    await recipeClient.RecipePutAsync(apiVersion, culture, data);
                }
            }
            catch (HttpRequestException exception) when (exception.Message.Contains("Failed to fetch"))
            {
                await recipeRepository.InsertAsync(data);
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            await recipeClient.RecipeDeleteAsync(id, apiVersion, culture);
        }

        public async Task SynchronizeLocalDataAsync()
        {
            var localItems = await recipeRepository.GetAllAsync();
            foreach (var localItem in localItems)
            {
                await SaveAsync(localItem);
                await recipeRepository.RemoveAsync(localItem.Id);
            }
        }
    }
}