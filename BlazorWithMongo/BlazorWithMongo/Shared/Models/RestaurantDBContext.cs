using MongoDB.Driver;

namespace BlazorWithMongo.Shared.Models
{
    public class RestaurantDBContext
    {
        private readonly IMongoDatabase _mongoDatabase;
        public RestaurantDBContext()
        {
            var client = new MongoClient("mongodb+srv://restaurantAdmin:vbnErypKGZM6eGm@restaurantcluster.scuuj.mongodb.net/Restaurant?authSource=admin&replicaSet=atlas-iej4oa-shard-0&w=majority&readPreference=primary&appname=RestaurantBlazorApp&retryWrites=true&ssl=true");
            _mongoDatabase = client.GetDatabase("EmployeeDB");
        }
        public IMongoCollection<Employee> EmployeeRecord
        {
            get
            {
                return _mongoDatabase.GetCollection<Employee>("Employees");
            }
        }
        public IMongoCollection<City> CityRecord
        {
            get
            {
                return _mongoDatabase.GetCollection<City>("Cities");
            }
        }

        public IMongoCollection<Dish> DishRecord
        {
            get
            {
                return _mongoDatabase.GetCollection<Dish>("Dishes");
            }
        }
    }

}
