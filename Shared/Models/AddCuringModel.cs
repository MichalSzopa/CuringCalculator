namespace CuringCalculator.Shared.Models;

public class AddCuringModel
{
    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public string Comments { get; set; }

    public decimal MeatAmount { get; set; }

    public decimal SugarAmount { get; set; }

    public decimal SaltAmount { get; set; }

    public int Days { get; set; }

    public int MethodId { get; set; }
}