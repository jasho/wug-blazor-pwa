using CookBook.BL.Web.Facades;
using CookBook.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
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

        private ICollection<RecipeListModel> Recipes { get; set; } = new List<RecipeListModel>();

        protected override async Task OnInitializedAsync()
        {
            Recipes = await RecipeFacade.GetRecipesAsync();

            await base.OnInitializedAsync();
        }
    }
}