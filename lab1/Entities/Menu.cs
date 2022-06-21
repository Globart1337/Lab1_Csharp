namespace lab1.Entities;

public class Menu
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public override string ToString()
    {
        return $"Date: {Date.ToShortDateString()}";
    }
}