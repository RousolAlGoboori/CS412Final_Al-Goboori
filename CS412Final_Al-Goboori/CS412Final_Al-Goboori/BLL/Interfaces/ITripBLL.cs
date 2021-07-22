using CS412Final_Al_Goboori.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CS412Final_Al_Goboori.BLL.Interfaces
{
    public interface ITripBLL
    {
        List<Trip> GetTrips();
        Trip CreateTrip(Trip trip);
        
    }
}