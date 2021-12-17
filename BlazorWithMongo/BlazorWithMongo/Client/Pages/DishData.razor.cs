using BlazorWithMongo.Shared.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorWithMongo.Client.Pages
{
    public class DishDataModel : ComponentBase
    {
        [Inject]
        public HttpClient Http { get; set; }
        protected List<Dish> dishList = new List<Dish>();
        protected Dish dish = new Dish();
        protected string SearchString { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await GetDishList();
        }

        protected async Task GetDishList()
        {
            dishList = await Http.GetJsonAsync<List<Dish>>("api/Dish");
        }
        protected async Task SearchDish()
        {
            await GetDishList();
            if (!string.IsNullOrEmpty(SearchString))
            {
                dishList = dishList.Where(x => x.Name.IndexOf(SearchString, StringComparison.OrdinalIgnoreCase) != -1).ToList();
            }
        }

        protected void DeleteConfirm(string ID)
        {
            dish = dishList.FirstOrDefault(x => x.Id == ID);
        }

        protected async Task DeleteDish(string dishID)
        {
            await Http.DeleteAsync("api/Dish/" + dishID);
            await GetDishList();
        }
    }
}
