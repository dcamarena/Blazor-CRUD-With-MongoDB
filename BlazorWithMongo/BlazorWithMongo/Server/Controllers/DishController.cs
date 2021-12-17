using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorWithMongo.Server.Interface;
using BlazorWithMongo.Shared.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlazorWithMongo.Server.Controllers
{
    [Route("api/[controller]")]
    public class DishController : Controller
    {
        private readonly IDish objdish;

        public DishController(IDish _objdish)
        {
            objdish = _objdish;
        }

        [HttpGet]
        public IEnumerable<Dish> Get()
        {
            return objdish.GetAllDishes();
        }

        [HttpPost]
        public void Post([FromBody] Dish dish)
        {
            objdish.AddDish(dish);
        }

        [HttpGet("{id}")]
        public Dish Get(string id)
        {
            return objdish.GetDishData(id);
        }

        [HttpPut]
        public void Put([FromBody]Dish dish)
        {
            objdish.UpdateDish(dish);
        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            objdish.DeleteDish(id);
        }
    }
}
