using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace FactExpressAPI.Models
{
    public class ConexionDB
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;


    }
}