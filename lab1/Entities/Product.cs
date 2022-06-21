namespace lab1.Entities;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public double CaloriesPer100Grams { get; set; }
    public double CaloriesPerGram => CaloriesPer100Grams / 100;
    public int SupplierId { get; set; }
    
    public override string ToString()
    {
        return $"Name: {Name}\n" +
               $"Calories per 100 grams: {CaloriesPer100Grams}";
    }
}