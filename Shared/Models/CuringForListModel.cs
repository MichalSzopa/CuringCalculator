using CuringCalculator.Data.Models;

namespace CuringCalculator.Shared.Models;

public class CuringForListModel
{
    public int Id { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public string Comments { get; set; }

    public decimal MeatAmount { get; set; }

    public decimal SugarAmount { get; set; }

    public decimal SaltAmount { get; set; }

    public int Days { get; set; }

    public string MethodName { get; set; }

    public bool IsRowExpanded { get; set; }

    public CuringForListModel(Curing curing, string methodName)
    {
        Id = curing.Id;
        StartDate = curing.StartDate;
        EndDate = curing.EndDate;
        Comments = curing.Comments;
        MeatAmount = curing.MeatAmount;
        SugarAmount = curing.SugarAmount;
        SaltAmount = curing.SaltAmount;
        Days = curing.Days;
        MethodName = methodName;
        IsRowExpanded = false;
    }
}