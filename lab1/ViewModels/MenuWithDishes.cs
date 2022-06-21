using lab1.Entities;

namespace lab1.ViewModels;

public class MenuWithDishes
{
    public Menu Menu { get; set; }
    public IEnumerable<DishWithPrice> Dishes { get; set; }
}