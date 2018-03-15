using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PD.Web.Helper
{
    public static class Extension
    {
        public static SqlConnection OpenConnection(this System.Web.Mvc.Controller controller)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            con.Open();
            return con;
        }
    }
}