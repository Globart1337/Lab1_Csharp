using lab1.Entities;
using lab1.ViewModels;

namespace lab1.Queries;

public class Queries
{
    private readonly MenuContext _menuContext;

    public Queries(MenuContext menuContext)
    {
        _menuContext = menuContext;
    }

    public IEnumerable<MenuWithDishes> GetAllMenus()
    {
        return _menuContext.Menus
            .GroupJoin(_menuContext.MenuItems,
                m => m.Id,
                i => i.MenuId,
                (menu, items) => new MenuWithDishes()
                {
                    Menu = menu,
                    Dishes = items.Join(_menuContext.Dishes,
                        i => i.DishId,
                        d => d.Id,
                        (item, dish) => new DishWithPrice()
                        {
                            Dish = dish,
                            Price = item.Price
                        })
                });
    }

    public MenuWithDishes? GetNewestMenu()
    {
        return GetAllMenus()
            .MaxBy(m => m.Menu.Date);
    }

    public IEnumerable<DishWithCalories> GetDishesWithCalories()
    {
        return _menuContext.Dishes
            .GroupJoin(_menuContext.Ingredients,
                d => d.Id,
                i => i.DishId,
                (dish, ingredients) => new DishWithCalories()
                {
                    Dish = dish,
                    Calories = ingredients.Join(_menuContext.Products,
                            i => i.ProductId,
                            p => p.Id,
                            (ingredient, product) => new
                            {
                                ingredient,
                                product
                            })
                        .Sum(r => r.ingredient.Grams * r.product.CaloriesPerGram)
                });
    }

    public IEnumerable<DishWithProducts> GetDishesWithIngredients()
    {
        return _menuContext.Dishes
            .GroupJoin(_menuContext.Ingredients,
                d => d.Id,
                i => i.DishId,
                (dish, ingredients) => new DishWithProducts()
                {
                    Dish = dish,
                    Products = ingredients.Join(_menuContext.Products,
                        i => i.ProductId,
                        p => p.Id,
                        (ingredient, product) => product)
                });
    }

    public Product? GetMostCaloricProduct()
    {
        return _menuContext.Products
            .MaxBy(p => p.CaloriesPer100Grams);
    }

    public IEnumerable<Dish> GetDishesSortedByMostExpensivePriceEver()
    {
        return _menuContext.MenuItems
            .Join(_menuContext.Dishes,
                i => i.DishId,
                d => d.Id,
                (item, dish) => new
                {
                    item,
                    dish
                })
            .OrderByDescending(r => r.item.Price)
            .Select(r => r.dish)
            .DistinctBy(d => d.Id);
    }

    public IEnumerable<Product> GetProductsSortedByUsages()
    {
        return _menuContext.Products
            .GroupJoin(_menuContext.Ingredients,
                p => p.Id,
                i => i.ProductId,
                (product, ingredients) => new
                {
                    product,
                    UsagesQuantity = ingredients.Count()
                })
            .OrderByDescending(r => r.UsagesQuantity)
            .Select(r => r.product);
    }

    public Dish? GetTheLeastCaloricDish()
    {
        return GetDishesWithCalories()
            .OrderBy(d => d.Calories)
            .Select(d => d.Dish)
            .FirstOrDefault();
    }

    public IEnumerable<Dish> GetDishesWithCaloriesLessThan(double calories)
    {
        return from dish in GetDishesWithCalories()
            where dish.Calories < calories
            select dish.Dish;
    }
    
    public IEnumerable<Dish> GetDishesSortedByName()
    {
        return from dish in _menuContext.Dishes
            orderby dish.Name
            select dish;
    }

    public IEnumerable<ProductWithDishes> GetProductsWithDishesWhereUsed()
    {
        return _menuContext.Ingredients
            .GroupBy(i => i.ProductId)
            .Select(r => new ProductWithDishes()
            {
                Product = _menuContext.Products.First(p => p.Id == r.Key),
                Dishes = r.Join(_menuContext.Dishes,
                    i => i.DishId,
                    d => d.Id,
                    (ingredient, dish) => dish)
            });
    }

    public IEnumerable<ProductWithSupplier> GetProductsWithSuppliers()
    {
        return from product in _menuContext.Products
            join supplier in _menuContext.Suppliers 
                on product.SupplierId equals supplier.Id 
            select new ProductWithSupplier()
            {
                Product = product,
                Supplier = supplier
            };
    }

    public Product? GetMostUsedProduct()
    {
        return GetProductsWithDishesWhereUsed()
            .OrderByDescending(p => p.Dishes.Count())
            .Select(p => p.Product)
            .FirstOrDefault();
    }

    public double GetAverageProductCalories()
    {
        return _menuContext.Products
                .Average(p => p.CaloriesPer100Grams);
    }

    public IEnumerable<MenuWithDishes> GetMenusCreatedAfter(DateTime dateTime)
    {
        return from menu in GetAllMenus()
            where menu.Menu.Date > dateTime
            select menu;
    }

    public Dish? GetDishWithLowestPriceEver()
    {
        return GetDishesSortedByMostExpensivePriceEver()
            .LastOrDefault();
    }
    
    public IEnumerable<string> GetProductAndSupplierNames()
    {
        return _menuContext.Products
            .Select(p => p.Name)
            .Concat(_menuContext.Suppliers
                .Select(s => s.Name));
    }
}