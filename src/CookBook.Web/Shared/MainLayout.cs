using CookBook.BL.Web.Facades;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace CookBook.Web.Shared
{
    public partial class MainLayout
    {
        [Inject]
        public RecipesFacade RecipesFacade { get; set; }

        public async Task OnlineStatusChangedAsync(bool isOnline)
        {
            if (isOnline)
            {
                await RecipesFacade.SynchronizeLocalDataAsync();
            }
        }
    }
}