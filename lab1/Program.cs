using lab1;
using lab1.Queries;

var context = new MenuContext();
context.Seed();

var queries = new Queries(context);
var printer = new QueriesPrinter(queries);

Console.WriteLine("1. All menus");
printer.PrintAllMenus();

Console.WriteLine("\n2. The newest menu\n");
printer.PrintNewestMenu();

Console.WriteLine("\n3. All dishes with calories\n");
printer.PrintDishesWithCalories();

Console.WriteLine("\n4. All dishes with ingredients\n");
printer.PrintDishesWithIngredients();

Console.WriteLine("\n5. The most caloric product\n");
printer.PrintMostCaloricProduct();

Console.WriteLine("\n6. All dishes are sorted by most expensive price ever\n");
printer.PrintDishesSortedByMostExpensivePriceEver();

Console.WriteLine("\n7. All products are sorted by usages\n");
printer.PrintProductsSortedByUsages();

Console.WriteLine("\n8. The least caloric dish\n");
printer.PrintTheLeastCaloricDish();

Console.WriteLine("\n9. All dishes with calories less than 100\n");
printer.PrintDishesWithCaloriesLessThan(100);

Console.WriteLine("\n10. All products with dishes where they are used\n");
printer.PrintProductsWithDishesWhereUsed();

Console.WriteLine("\n11. All products with suppliers\n");
printer.PrintProductsWithSuppliers();

Console.WriteLine("\n12. The most used product\n");
printer.PrintMostUsedProduct();

Console.WriteLine("\n13. The average product calories\n");
printer.PrintAverageProductCalories();

Console.WriteLine("\n14. All menus have been created since two weeks ago\n");
printer.PrintMenusCreatedAfter(DateTime.Now.Date.Subtract(TimeSpan.FromDays(14)));

Console.WriteLine("\n15. The dish with lowest price ever\n");
printer.PrintDishWithLowestPriceEver();

Console.WriteLine("\n16. All product and supplier names");
printer.PrintProductAndSupplierNames();

Console.WriteLine("\n17. All dishes sorted by name");
printer.PrintDishesSortedByName();