using BlazorWithMongo.Server.Interface;
using BlazorWithMongo.Shared.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace BlazorWithMongo.Server.DataAccess
{
    public class DishDataAccessLayer : IDish
    {
        private readonly RestaurantDBContext db;

        public DishDataAccessLayer(RestaurantDBContext _db)
        {
            db = _db;
        }

        //To Get all dishes details       
        public List<Dish> GetAllDishes()
        {
            try
            {
                return db.DishRecord.Find(_ => true).ToList();
            }
            catch
            {
                throw;
            }
        }

        //To Add new dish record       
        public void AddDish(Dish dish)
        {
            try
            {
                db.DishRecord.InsertOne(dish);
            }
            catch
            {
                throw;
            }
        }


        //Get the details of a particular dish      
        public Dish GetDishData(string id)
        {
            try
            {
                FilterDefinition<Dish> filterDishData = Builders<Dish>.Filter.Eq("Id", id);

                return db.DishRecord.Find(filterDishData).FirstOrDefault();
            }
            catch
            {
                throw;
            }
        }

        //To Update the records of a particluar dish      
        public void UpdateDish(Dish dish)
        {
            try
            {
                db.DishRecord.ReplaceOne(filter: g => g.Id == dish.Id, replacement: dish);
            }
            catch
            {
                throw;
            }
        }

        //To Delete the record of a particular dish      
        public void DeleteDish(string id)
        {
            try
            {
                FilterDefinition<Dish> dishData = Builders<Dish>.Filter.Eq("Id", id);
                db.DishRecord.DeleteOne(dishData);
            }
            catch
            {
                throw;
            }
        }
    }
}
