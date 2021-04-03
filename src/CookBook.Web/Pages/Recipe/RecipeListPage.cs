using CookBook.BL.Web.Facades;
using CookBook.DAL.Web;
using CookBook.DAL.Web.Repositories;
using CookBook.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CookBook.Web.Pages
{
    public partial class RecipeListPage
    {
        [Inject]
        private IJSRuntime jsRuntime { get; set; }

        [Inject]
        private RecipesFacade RecipeFacade { get; set; }

        [Inject]
        private LocalDb LocalDb { get; set; }

        [Inject]
        private RecipeRepository recipeRepository { get; set; }

        private ICollection<RecipeListModel> Recipes { get; set; } = new List<RecipeListModel>();

        protected override async Task OnInitializedAsync()
        {
            await LocalDb.Initialize();

            var id = Guid.NewGuid();
            await recipeRepository.InsertAsync(new RecipeDetailModel
            {
                Id = id,
                Name = "Test name",
                Description = "Test description"
            });

            var detailModel = await recipeRepository.GetByIdAsync(id);

            Recipes = await RecipeFacade.GetRecipesAsync();

            await base.OnInitializedAsync();
        }
    }
}