using System.Linq;
using OdeToFood.Core;
using System.Collections.Generic;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
        Restaurant GetById(int id);
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant { Id = 1, Name = "Scott's Pizza", Location = "Maryland", Cuisine=CuisineType.Indian },
                new Restaurant { Id = 2, Name = "Mama's Drain", Location = "New York", Cuisine = CuisineType.Indian },
                new Restaurant { Id = 3, Name = "Cetenamon", Location = "Los Angeles", Cuisine = CuisineType.Mexican },
            };
        }

        public Restaurant GetById(int id)
            => restaurants.SingleOrDefault(r => r.Id == id);

        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
            => from r in restaurants
               where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;

    }

}
