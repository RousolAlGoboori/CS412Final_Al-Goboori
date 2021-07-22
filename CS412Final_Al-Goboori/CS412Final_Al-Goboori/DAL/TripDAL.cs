using CS412Final_Al_Goboori.Domain;
using CS412Final_Al_Goboori.Repositories;
using CS412Final_Al_Goboori.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using MySql.Data.MySqlClient;

namespace CS412Final_Al_Goboori.DAL
{
    public static class TripDAL
    {
        private readonly static IError _error = new Error();
        private static List<Trip> _trips = new List<Trip>() {
            new Trip() {
                Id = 1,
                Name = "Round trip",
               
                Price = 1000
            },
            new Trip() {
                Id = 2,
                Name = "One way",
               
                Price = 500
            },
            new Trip() {
                 Id = 3,
                Name = "Multi-city",
               
                Price = 1500
            }
        };
      
        public static List<Trip> GetTrips()
        {
            List<Trip> trips = new List<Trip>();
            string sql = "SELECT * FROM Trips";
            using (MySqlConnection conn = new MySqlConnection(WebConfigurationManager.AppSettings["connString"]))
            {
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    try
                    {
                        cmd.Connection.Open();
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    trips.Add(new Trip()
                                    {
                                        Id = reader.GetInt64("Id"),
                                        Name = reader.GetString("Name"),
                                        Price = reader.GetDecimal("Price")
                                    });
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        _error.Log(ex);
                    }
                }
            }
            return trips;
        }
        public static bool DeleteBookingTrip(long bookingId)
        {
            string sql = @"DELETE FROM BookingTrips WHERE BookingId=@BookingID";
            using (MySqlConnection conn = new MySqlConnection(WebConfigurationManager.AppSettings["connString"]))
            {
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    try
                    {
                        cmd.Connection.Open();
                        cmd.Parameters.AddWithValue("@BookingID",bookingId);
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        _error.Log(ex);
                        return false;
                    }
                }
            }
            return true;
        }

        public static List<BookingTrips> GetBookingTrips(List<long> bookingIds)
        {
            List<BookingTrips> bookingTrips = new List<BookingTrips>();

            string sql = @"SELECT a.*, b.BookingId
                            FROM Trips a
                            INNER JOIN BookingTrips b ON a.Id=b.TripId
                            WHERE b.BookingId IN (#BOOKINGIDS)
                            ";
            sql = sql.Replace("#BOOKINGIDS", string.Join(", ", bookingIds));
            using (MySqlConnection connection = new MySqlConnection(WebConfigurationManager.AppSettings["connString"]))
            {
                using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                {
                    try
                    {
                        cmd.Connection.Open();
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    bookingTrips.Add(new BookingTrips()
                                    {
                                        BookingId = reader.GetInt64("BookingId"),
                                        Trip = new Trip()
                                        {
                                            Id = reader.GetInt64("Id"),
                                            Name = reader.GetString("Name"),
                                            Price = reader.GetDecimal("Price")
                                        }
                                    });
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        _error.Log(ex);
                    }
                }
            }

            return bookingTrips;
        }
        public static Trip CreateTrip(Trip trip)
        {
            string sql = @"INSERT INTO Trips (Name, Price) VALUES (@Name, @Price);
                            SELECT LAST_INSERT_ID();";
            using (MySqlConnection conn = new MySqlConnection(WebConfigurationManager.AppSettings["connString"]))
            {
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    try
                    {
                        cmd.Connection.Open();
                        cmd.Parameters.AddWithValue("@Name", trip.Name);
                        cmd.Parameters.AddWithValue("@Price", trip.Price);

                        string o = cmd.ExecuteScalar().ToString();
                        long id = 0;
                        long.TryParse(o, out id);
                        trip.Id = id;
                    }
                    catch (Exception ex)
                    {
                        _error.Log(ex);
                    }
                }
            }
            return trip;
        }
        public static void AssociateBookingToTrips(long bookingId, List<long> tripIds)
        {
            string sql = @"INSERT INTO BookingTrips (BookingId, TripId) VALUES #TRIPS";
            List<string> values = new List<string>();
            foreach (long tripId in tripIds)
            {
                values.Add($"({bookingId}, {tripId})");
            }
            sql = sql.Replace("#TRIPS", string.Join(", ", values));
            using (MySqlConnection conn = new MySqlConnection(WebConfigurationManager.AppSettings["connString"]))
            {
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    try
                    {
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        _error.Log(ex);
                    }
                }
            }
        }

    }
}