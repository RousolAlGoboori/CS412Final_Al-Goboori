using CS412Final_Al_Goboori.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CS412Final_Al_Goboori.Repositories
{
    public class Error : IError
    {
        public bool Log(Exception ex)
        {
            
            return false;
        }
    }
}