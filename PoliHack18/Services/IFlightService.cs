namespace PoliHack18.Services;
using PoliHack18.Models;

public interface IFlightService
{
    TripOption? GetRandomFlight(string origin, decimal maxPrice, DateTime date);
}