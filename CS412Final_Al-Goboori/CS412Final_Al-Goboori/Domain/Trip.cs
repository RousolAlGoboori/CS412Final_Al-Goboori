using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CS412Final_Al_Goboori.Domain
{
    [Serializable]
    public class Trip
    {
        public long Id { get; set; }
        public User User { get; set; }
        public string Name { get; set; }
        public string From { get; set; }
        public string To { get; set; }


    }
}