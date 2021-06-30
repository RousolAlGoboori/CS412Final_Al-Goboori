using CS412Final_Al_Goboori.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CS412Final_Al_Goboori.DAL
{
    public static class BookingDAL
    {
        private static readonly List<Booking> _book = new List<Booking>() {
            new Booking() {
                Id = 1,
                Customer = new User() {
                    Id = 1,
                    First = "Rousol",
                    Last = "Al Goboori",
                    
                },
                DepartDate = DateTime.Now.AddDays(-1),
                ReturnDate = DateTime.Now.AddDays(10),

                Trips = new List<Trip>() {
                    new Trip() {
                         Id = 1,
                         Name = "Multi-city",
                         From = "Chicago",
                         To = "New York",
                         Price = 1500
                    },

                }
            },
            new Booking() {
                Id = 2,
                Customer = new User() {
                    Id = 1,
                    First = "Rousol",
                    Last = "Al Goboori"
                },
                DepartDate = DateTime.Now.AddDays(-15),
                ReturnDate = DateTime.Now.AddDays(13),
                Trips = new List<Trip>() {
                    new Trip() {
                         Id = 1,
                         Name = "One way",
                         From = "Chicago",
                         To = "Turkish",
                         Price = 500
                    }
                }
            },
            new Booking() {
                Id = 3,
                Customer = new User() {
                    Id = 1,
                    First = "Rousol",
                    Last = "Al Goboori"
                },
                DepartDate = DateTime.Now.AddDays( 1),
                ReturnDate = DateTime.Now.AddDays(18),
                Trips = new List<Trip>() {
                    new Trip() {
                         Id = 2,
                         Name = "Round trip",
                         From = "Chicago",
                         To = "Texas",
                         Price = 1000
                    }
                }
            }
        };
        public static List<Booking> GetBooking()
        {
            return _book;
        }
    }
}