using BlazorWithMongo.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWithMongo.Server.Interface
{
    public interface IDish
    {
        public List<Dish> GetAllDishes();
        public void AddDish(Dish dish);
        public Dish GetDishData(string id);
        public void UpdateDish(Dish dish);
        public void DeleteDish(string id);
    }
}
