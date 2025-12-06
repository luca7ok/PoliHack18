namespace PoliHack18.Models;

public class TripOption
{
    public string Destination { get; set; } = string.Empty;
    public string FlightInfo { get; set; } = string.Empty;
    public string HotelName { get; set; } = string.Empty;
    public decimal PricePerPerson { get; set; }
    public decimal TotalPrice { get; set; }
}