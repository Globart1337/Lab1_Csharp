using lab1.Entities;
using lab1.ViewModels;

namespace lab1.Queries;

public class QueriesPrinter
{
    private readonly Queries _queries;

    public QueriesPrinter(Queries queries)
    {
        _queries = queries;
    }

    public void PrintAllMenus()
    {
        PrintMenus(_queries.GetAllMenus());
    }

    public void PrintProductAndSupplierNames()
    {
        var collection = _queries.GetProductAndSupplierNames();
        foreach (var element in collection)
        {
            Console.WriteLine(element);
        }
    }

    public void PrintDishesSortedByName()
    {
        PrintDishes(_queries.GetDishesSortedByName());
    }

    public void PrintNewestMenu()
    {
        var menu = _queries.GetNewestMenu();
        if (menu is not null)
        {
            Console.WriteLine(menu.Menu);
            foreach (var dish in menu.Dishes)
            {
                Console.WriteLine($"{dish.Dish} - {dish.Price}");
            }
        }
    }

    public void PrintDishesWithCalories()
    {
        var dishes = _queries.GetDishesWithCalories();
        foreach (var dish in dishes)
        {
            Console.WriteLine($"{dish.Dish} - {dish.Calories.ToString(".##")}");
        }
    }

    public void PrintDishesWithIngredients()
    {
        var dishes = _queries.GetDishesWithIngredients();
        foreach (var dish in dishes)
        {
            Console.WriteLine("Dish:");
            Console.WriteLine(dish.Dish);
            Console.WriteLine("Ingredients:");
            foreach (var product in dish.Products)
            {
                Console.WriteLine(product);
            }
        }
    }

    public void PrintMostCaloricProduct()
    {
        Console.WriteLine(_queries.GetMostCaloricProduct());
    }

    public void PrintDishesSortedByMostExpensivePriceEver()
    {
        PrintDishes(_queries.GetDishesSortedByMostExpensivePriceEver());
    }

    public void PrintProductsSortedByUsages()
    {
        var products = _queries.GetProductsSortedByUsages();
        foreach (var product in products)
        {
            Console.WriteLine(product);
        }
    }

    public void PrintTheLeastCaloricDish()
    {
        Console.WriteLine(_queries.GetTheLeastCaloricDish());
    }

    public void PrintDishesWithCaloriesLessThan(double calories)
    {
        PrintDishes(_queries.GetDishesWithCaloriesLessThan(calories));
    }

    public void PrintProductsWithDishesWhereUsed()
    {
        var products = _queries.GetProductsWithDishesWhereUsed();
        foreach (var product in products)
        {
            Console.WriteLine("Product:");
            Console.WriteLine(product.Product);
            Console.WriteLine("Dishes:");
            foreach (var dish in product.Dishes)
            {
                Console.WriteLine(dish);
            }
        }
    }

    public void PrintProductsWithSuppliers()
    {
        var products = _queries.GetProductsWithSuppliers();
        foreach (var product in products)
        {
            Console.WriteLine(product.Product);
            Console.WriteLine($"Supplier: {product.Supplier}");
        }
    }

    public void PrintMostUsedProduct()
    {
        Console.WriteLine(_queries.GetMostUsedProduct());
    }

    public void PrintAverageProductCalories()
    {
        try
        {
            Console.WriteLine(_queries.GetAverageProductCalories());
        }
        catch (InvalidOperationException)
        {
            Console.WriteLine("It's not possible to calculate average product calories without products");
        }
    }

    public void PrintMenusCreatedAfter(DateTime dateTime)
    {
        PrintMenus(_queries.GetMenusCreatedAfter(dateTime));
    }

    public void PrintDishWithLowestPriceEver()
    {
        Console.WriteLine(_queries.GetDishWithLowestPriceEver());
    }

    private void PrintMenus(IEnumerable<MenuWithDishes> menus)
    {
        foreach (var menu in menus)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine(menu.Menu);
            foreach (var dish in menu.Dishes)
            {
                Console.WriteLine($"{dish.Dish} - {dish.Price}");
            }
        }
    }

    private void PrintDishes(IEnumerable<Dish> dishes)
    {
        foreach (var dish in dishes)
        {
            Console.WriteLine(dish);
        }
    }
}