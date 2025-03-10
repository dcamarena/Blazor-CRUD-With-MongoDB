﻿using BlazorWithMongo.Shared.Models;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorWithMongo.Client.Pages
{
    public class AddEditEmployeeModel : ComponentBase
    {
        [Inject]
        public HttpClient Http { get; set; }
        [Inject]
        public NavigationManager UrlNavigationManager { get; set; }
        [Parameter]
        public string EmpID { get; set; }
        protected string Title = "Add";
        public Employee emp = new Employee();
        protected List<City> cityList = new List<City>();

        protected override async Task OnInitializedAsync()
        {
            await GetCityList();
        }

        protected override async Task OnParametersSetAsync()
        {
            if (!string.IsNullOrEmpty(EmpID))
            {
                Title = "Edit";
                emp = await Http.GetJsonAsync<Employee>("/api/Employee/" + EmpID);
            }
        }

        protected async Task GetCityList()
        {
            cityList = await Http.GetJsonAsync<List<City>>("api/Employee/GetCities");
        }
        protected async Task SaveEmployee()
        {
            if (emp.Id != null)
            {
                await Http.SendJsonAsync(HttpMethod.Put, "api/Employee/", emp);
            }
            else
            {
                await Http.SendJsonAsync(HttpMethod.Post, "/api/Employee/", emp);
            }
            Cancel();
        }

        public void Cancel()
        {
            UrlNavigationManager.NavigateTo("/employeerecords");
        }
    }
}
