using CS412Final_Al_Goboori.BLL.Interfaces;
using CS412Final_Al_Goboori.Domain;
using CS412Final_Al_Goboori.Repositories;
using CS412Final_Al_Goboori.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CS412Final_Al_Goboori.BLL
{
    public class TripBLL : ITripBLL
    {
        public readonly ITripRepository _tripRepository;
        public TripBLL()
        {
            _tripRepository = new TripRepository();
        }

        public Trip CreateTrip(Trip trip)
        {
            return _tripRepository.CreateTrip(trip);
        }

        public List<Trip> GetTrips()
        {
           return _tripRepository.GetTrips();

        }
    }
}