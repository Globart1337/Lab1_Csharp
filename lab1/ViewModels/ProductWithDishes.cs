using lab1.Entities;

namespace lab1.ViewModels;

public class ProductWithDishes
{
    public Product Product { get; set; }
    public IEnumerable<Dish> Dishes { get; set; }
}