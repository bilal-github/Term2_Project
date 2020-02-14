using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Team5_Workshop5.Models
{
    public static class TravelExpertsDB
    {
        public static string GetConnection()
        {
            return ConfigurationManager.ConnectionStrings["TravelExpertsConnection"].ConnectionString;
        }
        
    }
}