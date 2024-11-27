namespace _10__dars.Modul;

public class Restaurant
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public string Location { get; set; }
    
    public double Rating { get; set; }
    
    
    public List<Dish> DishList { get; set; }
}