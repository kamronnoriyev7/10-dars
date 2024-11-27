using _10__dars.Modul;

namespace _10__dars.Service;

public class DishService
{
    private List<Dish> listDish;

    public DishService()
    {
        listDish = new List<Dish>();
    }

    public Dish AddDish(Dish dish)
    {
        dish.Id = Guid.NewGuid();
        listDish.Add(dish);
        return dish;
    }

    public Dish GetDish(Guid id)
    {
        var dish = GetDishById(id);
        if (dish == null)
        {
            throw new Exception("Dish not found");
        }

        return dish;
    }

    public Dish UpdateDish(Guid id, Dish dish)
    {
        var dishToUpdate = GetDishById(id);
        if (dishToUpdate == null)
        {
            throw new Exception("Dish not found");
        }

        dishToUpdate.Name = dish.Name;
        dishToUpdate.Price = dish.Price;
        dishToUpdate.Description = dish.Description;
        return dishToUpdate;
    }

    public Dish DeleteDish(Guid id)
    {
        var dishToDelete = GetDishById(id);
        if (dishToDelete == null)
        {
            throw new Exception("Dish not found");
        }

        listDish.Remove(dishToDelete);
        return dishToDelete;
    }

    public Dish GetDishById(Guid Id)
    {
        foreach (var element in listDish)
        {
            if (element.Id == Id)
            {
                return element;
            }
        }

        return null;
    }

    public Dish GetMostExpensiveDishByRestaurant()
    {
        var mostExpensiveDish = new Dish();
        foreach (var element in listDish)
        {
            if (element.Price > mostExpensiveDish.Price)
            {
                mostExpensiveDish = element;
            }
        }

        return mostExpensiveDish;
    }

    public List<Dish> GetAllDishesUnderPrice(double price)
    {
        var dishesUnderPrice = new List<Dish>();
        foreach (var element in listDish)
        {
            if (element.Price < price)
            {
                dishesUnderPrice.Add(element);
            }
        }

        return dishesUnderPrice;
    }

    public Dish SearchDishByName(string dishName)
    {
        var dishByName = new Dish();
        foreach (var dish in listDish)
        {
            if (dish.Name==dishName)
            {
                dishByName=dish;
            }
        }

        return dishByName;
    }

   



}