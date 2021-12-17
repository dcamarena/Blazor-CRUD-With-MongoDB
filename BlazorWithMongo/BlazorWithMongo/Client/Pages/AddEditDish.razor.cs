using BlazorWithMongo.Shared.Models;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorWithMongo.Client.Pages
{
    public class AddEditDishModel : ComponentBase
    {
        [Inject]
        public HttpClient Http { get; set; }
        [Inject]
        public NavigationManager UrlNavigationManager { get; set; }
        [Parameter]
        public string DishID { get; set; }
        protected string Title = "Add";
        public Dish dish = new Dish();
        protected List<City> cityList = new List<City>();

        protected override async Task OnParametersSetAsync()
        {
            if (!string.IsNullOrEmpty(DishID))
            {
                Title = "Edit";
                dish = await Http.GetJsonAsync<Dish>("/api/Dish/" + DishID);
            }
        }

        protected async Task SaveDish()
        {
            if (dish.Id != null)
            {
                await Http.SendJsonAsync(HttpMethod.Put, "api/Dish/", dish);
            }
            else
            {
                await Http.SendJsonAsync(HttpMethod.Post, "/api/Dish/", dish);
            }
            Cancel();
        }

        public void Cancel()
        {
            UrlNavigationManager.NavigateTo("/dishrecords");
        }
    }
}
