﻿using CookBook.BL.Web.Facades;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace CookBook.Web.Shared
{
    public partial class MainLayout
    {
        [Inject]
        public RecipeFacade RecipeFacade { get; set; }

        [Inject]
        public IngredientFacade IngredientFacade { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }


        public async Task OnlineStatusChangedAsync(bool isOnline)
        {
            if (isOnline)
            {
                var dataChanged = false;
                dataChanged = dataChanged || await IngredientFacade.SynchronizeLocalDataAsync();
                dataChanged = dataChanged || await RecipeFacade.SynchronizeLocalDataAsync();

                if (dataChanged)
                {
                    NavigationManager.NavigateTo(NavigationManager.Uri, true);
                }
            }
        }
    }
}