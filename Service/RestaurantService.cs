using _10__dars.Modul;

namespace _10__dars.Service;

public class RestaurantService
{
    private List<Restaurant> listRestaurant;

    public RestaurantService()
    {
        listRestaurant = new List<Restaurant>();
    }

    public Restaurant AddRestaurant(Restaurant restaurant)
    {
        restaurant.Id = Guid.NewGuid();
        listRestaurant.Add(restaurant);
        return restaurant;
    }

    public Restaurant GetRestaurant(Guid id)
    {
        var restaurant = GetRestaurantById(id);
        if (restaurant == null)
        {
            throw new Exception("Restaurant not found");
        }

        return restaurant;
    }

    public Restaurant UpdateRestaurant(Guid id, Restaurant restaurant)
    {
        var restaurantToUpdate = GetRestaurantById(id);
        if (restaurantToUpdate == null)
        {
            throw new Exception("Restaurant not found");
        }

        restaurantToUpdate.Name = restaurant.Name;
        restaurantToUpdate.Location = restaurant.Location;
        restaurantToUpdate.Rating = restaurant.Rating;
        return restaurantToUpdate;
    }

    public Restaurant GetRestaurantById(Guid id)
    {
        foreach (var element in listRestaurant)
        {
            if (element.Id == id)
            {
                return element;
            }
        }

        return null;
    }

    public List<Restaurant> GetAll()
    {
        return listRestaurant;
    }

    public Restaurant GetTopRatedRestaurant()
    {
        var topRatedRestaurant = new Restaurant();
        foreach (var element in listRestaurant)
        {
            if (element.Rating > topRatedRestaurant.Rating)
            {
                topRatedRestaurant = element;
            }
        }

        return topRatedRestaurant;
    }

    public Restaurant GetRestaurantWithMostDishes()
    {
        var withRestaurant = new Restaurant();
        foreach (var restaurant in listRestaurant)
        {
            if (restaurant.DishList.Count > withRestaurant.DishList.Count)
            {
                withRestaurant = restaurant;
            }
        }

        return withRestaurant;
    }

    public List<double> GetAverageDishPriceByRestaurant()
    {
        var averageDishPriceByRestaurant = new List<double>();
        foreach (var restaurant in listRestaurant)
        {
            var averagePrice = 0.0;
            foreach (var dish in restaurant.DishList)
            {
                averagePrice += dish.Price;
            }

            averagePrice /= restaurant.DishList.Count;
            averageDishPriceByRestaurant.Add(averagePrice);
        }

        return averageDishPriceByRestaurant;
    }
   

    public static bool AssignDishToAnotherRestaurant(Guid dishId, Guid restaurantId, Guid newRestaurantId)
    {
       
        var nameDish = new Service.DishService().GetDishById(dishId);
        if (nameDish == null)
        {
            return false;
        }
        var nameRestaurant = new Service.RestaurantService().GetRestaurantById(restaurantId);
        var nameNewRestaurant = new Service.RestaurantService().GetRestaurantById(newRestaurantId);
        nameRestaurant.DishList.Remove(nameDish);
        nameNewRestaurant.DishList.Add(nameDish);
        return true;
    }

    public List<Restaurant> GetRestaurantsByLocation(string location)
    {
        var restaurantsByLocation = new List<Restaurant>();
        foreach (var restaurant in listRestaurant)
        {
            if (restaurant.Location ==location)
            {
                restaurantsByLocation.Add(restaurant);
            }
        }

        return restaurantsByLocation;
    }

    public Dish GetCheapestDishAcrossRestaurants(List<Dish> listDish)
    {
        var minPrice = int.MaxValue;
        var minDishPrice = new Dish();
        var cheapestDishAcrossRestaurants = new List<Dish>();
        foreach (var restaurant in listRestaurant)
        {
            foreach (var dish in listDish)
            {
                if (dish.Price<minPrice)
                {
                   dish.Price=minPrice;
                   minDishPrice=dish;
                }
            }
        }

        return minDishPrice;
    }

    
        

   
}