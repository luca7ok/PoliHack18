using PoliHack18.Models;
using PoliHack18.Services;

namespace PoliHack18.Repository;

public class TripRepository
{
    public void AddTrip(TripOption trip, Guid userID)
    {
        string query =
            "INSERT INTO \"SavedTrips\" (user_id, destination, \"destinationCode\", \"flightInfo\", \"hotelInfo\", \"pricePerPerson\", \"totalPrice\") " +
            "VALUES (@user_id, @destination, @destinationCode, @flightInfo, @hotelInfo, @pricePerPerson, @totalPrice)";
        var parameters = new Dictionary<string, object?>
        {
            { "@user_id", userID },
            { "@destination", trip.Destination },
            { "@destinationCode", trip.DestinationCode },
            { "@flightInfo", trip.FlightInfo },
            { "@hotelInfo", trip.HotelInfo },
            { "@pricePerPerson", (float)trip.PricePerPerson },
            { "@totalPrice", (float)trip.TotalPrice },
        };
        Database.ExecutaNonQuery(query, parameters);
    }
    
    public List<TripOption> GetTripsByUser(Guid userId)
    {
        string query = "SELECT * FROM \"SavedTrips\" WHERE user_id = @user_id ORDER BY created_at DESC";
    
        var parameters = new Dictionary<string, object?>
        {
            { "@user_id", userId }
        };

        System.Data.DataTable dt = Database.ExecutaQuery(query, parameters);
        var trips = new List<TripOption>();

        foreach (System.Data.DataRow row in dt.Rows)
        {
            trips.Add(new TripOption
            {
                Destination = row["destination"].ToString(),
                DestinationCode = row["destinationCode"].ToString(),
                FlightInfo = row["flightInfo"].ToString(),
                HotelInfo = row["hotelInfo"].ToString(),
                PricePerPerson = Convert.ToDecimal(row["pricePerPerson"]), 
                TotalPrice = Convert.ToDecimal(row["totalPrice"])
            });
        }

        return trips;
    }
}