using CS412Final_Al_Goboori.Domain;
using CS412Final_Al_Goboori.Repositories;
using CS412Final_Al_Goboori.Repositories.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace CS412Final_Al_Goboori.DAL
{

    public static class BookingDAL
    {
        private readonly static IError _error = new Error();
        public static List<Booking> GetBooking(long userId = -1)
        {
            List<Booking> booking = new List<Booking>();
            string sql = "SELECT * FROM Booking";
            /*if (userId > -1)
            {
                sql += UserId=@UserId;
            }*/

            using (MySqlConnection conn = new MySqlConnection(WebConfigurationManager.AppSettings["connString"]))
            {
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    try
                    {
                        cmd.Connection.Open();
                        cmd.Parameters.AddWithValue("@UserId", userId);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    booking.Add(new Booking()
                                    {
                                        CustomerName = reader.GetString("CustomerName"),
                                        Id = reader.GetInt64("Id"),
                                        From = reader.GetString("LFrom"),
                                        To = reader.GetString("LTo"),
                                        DepartDate = reader.GetDateTime("DepartDate"),
                                        ReturnDate = reader.GetDateTime("ReturnDate"),
                                        UserById = reader.GetInt64("UserId")
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
            return booking;
        }
        public static Booking GetBookings(long bookingId)
        {
            Booking booking = null;
            string sql = "SELECT * FROM Booking WHERE Id=@BookingId";
            using (MySqlConnection conn = new MySqlConnection(WebConfigurationManager.AppSettings["connString"]))
            {
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    try
                    {
                        cmd.Connection.Open();
                        cmd.Parameters.AddWithValue("@BookingId", bookingId);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                if (reader.Read())
                                {
                                    booking = new Booking()
                                    {
                                        CustomerName = reader.GetString("CustomerName"),
                                        Id = reader.GetInt64("Id"),
                                        From = reader.GetString("LFrom"),
                                        To = reader.GetString("LTo"),
                                        DepartDate = reader.GetDateTime("DepartDate"),
                                        ReturnDate = reader.GetDateTime("ReturnDate"),
                                        UserById = reader.GetInt64("UserId")
                                    };
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
            return booking;
        }
        public static List<Booking> GetBookingByCustomerName(string partialName)
        {
            List<Booking> bookings = new List<Booking>();
            string sql = "SELECT * FROM Booking WHERE CustomerName LIKE CONCAT('%', @PartialName, '%')";
            using (MySqlConnection conn = new MySqlConnection(WebConfigurationManager.AppSettings["connString"]))
            {
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    try
                    {
                        cmd.Connection.Open();
                        cmd.Parameters.AddWithValue("@PartialName", partialName);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    bookings.Add(new Booking()
                                    {
                                        CustomerName = reader.GetString("CustomerName"),
                                        Id = reader.GetInt64("Id"),
                                        From = reader.GetString("LFrom"),
                                        To = reader.GetString("LTo"),
                                        DepartDate = reader.GetDateTime("DepartDate"),
                                        ReturnDate = reader.GetDateTime("ReturnDate"),
                                        UserById = reader.GetInt64("UserId")
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
            return bookings;
        }
        public static List<Booking> GetCompletedBooking()
        {
            List<Booking> bookings = new List<Booking>();
            string sql = "SELECT * FROM Booking WHERE DepartDate < NOW()";
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
                                    bookings.Add(new Booking()
                                    {
                                        CustomerName = reader.GetString("CustomerName"),
                                        Id = reader.GetInt64("Id"),
                                        From = reader.GetString("LFrom"),
                                        To = reader.GetString("LTo"),
                                        DepartDate = reader.GetDateTime("DepartDate"),
                                        ReturnDate = reader.GetDateTime("ReturnDate"),
                                        UserById = reader.GetInt64("UserId")
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
            return bookings;
        }
        public static bool DeleteBooking(long bookingId)
        {
            string sql = @"DELETE FROM Booking WHERE Id=@UserId";
            using (MySqlConnection conn = new MySqlConnection(WebConfigurationManager.AppSettings["connString"]))
            {
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    try
                    {
                        cmd.Connection.Open();
                        cmd.Parameters.AddWithValue("@UserId", bookingId);
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

        public static long GetBookingCount()
        {
            long count = 0;
            string sql = "SELECT COUNT(*) FROM Booking";
            using (MySqlConnection conn = new MySqlConnection(WebConfigurationManager.AppSettings["connString"]))
            {
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    try
                    {
                        cmd.Connection.Open();
                        count = (long)cmd.ExecuteScalar();
                    }
                    catch (Exception ex)
                    {
                        _error.Log(ex);
                    }
                }
            }
            return count;
        }
        public static Booking ModifyBooking(Booking booking)
        {
            string sql = @"update Booking SET (LFrom=@LFrom, LTo=@LTo,DepartDate=@DepartDate,ReturnDate=@ReturnDate) WHERE (Id=@Id)";
            using (MySqlConnection conn = new MySqlConnection(WebConfigurationManager.AppSettings["connString"]))
            {
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    try
                    {
                        cmd.Connection.Open();
                        cmd.Parameters.AddWithValue("@CustomerName", booking.CustomerName);
                        cmd.Parameters.AddWithValue("@LFrom", booking.From);
                        cmd.Parameters.AddWithValue("@LTo", booking.To);
                        cmd.Parameters.AddWithValue("@DepartDate", booking.DepartDate);
                        cmd.Parameters.AddWithValue("@ReturnDate", booking.ReturnDate);
                        if (booking.UserById > 0)
                        {
                            cmd.Parameters.AddWithValue("@UserId", booking.UserById);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@UserId", booking.UserId.Id);
                        }

                        string o = cmd.ExecuteScalar().ToString();
                        long id = 0;
                        long.TryParse(o, out id);
                        booking.Id = id;
                    }
                    catch (Exception ex)
                    {
                        _error.Log(ex);
                    }
                }
            }
            return booking;
        }
        public static Booking CreateBooking(Booking booking)
        {
            string sql = @"INSERT INTO Booking (CustomerName,LFrom, LTo,DepartDate,ReturnDate,UserId) VALUES (@CustomerName,@LFrom,@LTo, @DepartDate, @ReturnDate, @UserId);
                            SELECT LAST_INSERT_ID();";
            using (MySqlConnection conn = new MySqlConnection(WebConfigurationManager.AppSettings["connString"]))
            {
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    try
                    {
                        cmd.Connection.Open();
                        cmd.Parameters.AddWithValue("@CustomerName", booking.CustomerName);
                        cmd.Parameters.AddWithValue("@LFrom", booking.From);
                        cmd.Parameters.AddWithValue("@LTo", booking.To);
                        cmd.Parameters.AddWithValue("@DepartDate", booking.DepartDate);
                        cmd.Parameters.AddWithValue("@ReturnDate", booking.ReturnDate);
                        if (booking.UserById > 0)
                        {
                            cmd.Parameters.AddWithValue("@UserId", booking.UserById);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@UserId", booking.UserId.Id);
                        }

                        string o = cmd.ExecuteScalar().ToString();
                        long id = 0;
                        long.TryParse(o, out id);
                        booking.Id = id;
                    }
                    catch (Exception ex)
                    {
                        _error.Log(ex);
                    }
                }
            }
            return booking;
        }
        
    }
}