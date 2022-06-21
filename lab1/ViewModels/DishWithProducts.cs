using lab1.Entities;

namespace lab1.ViewModels;

public class DishWithProducts
{
    public Dish Dish { get; set; }
    public IEnumerable<Product> Products { get; set; }
}