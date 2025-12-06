namespace PoliHack18.Models;

public class TripSearchCriteria
{
    public string Origin { get; set; } = String.Empty;
    public decimal MaxBudget { get; set; } = 1000;
    public DateTime? StartDate { get; set; } = DateTime.Today.AddDays(1);
    public DateTime? EndDate { get; set; } = DateTime.Today.AddDays(7);
    public int NumberOfPeople { get; set; } = 1;
}

