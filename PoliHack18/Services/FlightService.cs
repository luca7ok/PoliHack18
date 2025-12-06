using PoliHack18.Models;
using amadeus;
using amadeus.resources;
using Microsoft.Extensions.Configuration;

namespace PoliHack18.Services
{

    public class FlightService : IFlightService
    {
        private readonly amadeus.Amadeus _amadeusClient;

        public FlightService(IConfiguration configuration)
        {
            var clientID = configuration["AmadeusApiKey"];
            var clientSecret = configuration["AmadeusApiSecret"];
            
            if (string.IsNullOrWhiteSpace(clientID) || string.IsNullOrWhiteSpace(clientSecret))
            {
                Console.WriteLine("Amadeus keys are missing from configuration.");
            }

            _amadeusClient = amadeus.Amadeus
                .builder(clientID, clientSecret)
                .build();
        }
        
        public TripOption? GetRandomFlight(string origin, decimal maxPrice, DateTime date)
        {
            try
            {
                FlightDestination[] flightDestinations =  _amadeusClient.shopping.flightDestinations.get(
                    Params.with("origin", origin.ToUpper())
                        .and("maxPrice", maxPrice.ToString())
                        .and("departureDate", date.ToString("yyyy-MM-dd"))
                );

                if (flightDestinations != null && flightDestinations.Length > 0)
                {
                    var random = new Random();
                    var randomFlight = flightDestinations[random.Next(flightDestinations.Length)];

                    return new TripOption
                    {
                        Destination = randomFlight.destination,
                        FlightInfo = $"Departing {randomFlight.departureDate}",
                        PricePerPerson = (decimal)randomFlight.price.total,
                        TotalPrice = (decimal)randomFlight.price.total, 
                    };
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Amadeus Error: {ex.Message}");
            }

            return null;
        }
            
    }
}