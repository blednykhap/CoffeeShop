using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Bussiness.Files
{
    public class ImageLogic
    {
        public static byte[] GetFromDB(int objectId)
        {
            SqlDataReader rdr;
            byte[] coffeeImage = null;            
            //string connect = ConfigurationManager.ConnectionStrings["ApplicationConn"].ConnectionString;
            string connect = ConfigurationManager.ConnectionStrings["CoffeeShopDBContext"].ConnectionString;

            using (var conn = new SqlConnection(connect))
            {
                var qry = "SELECT CoffeeImage FROM Flavors WHERE Id = @Id";
                var cmd = new SqlCommand(qry, conn);
                cmd.Parameters.AddWithValue("@Id", objectId);
                conn.Open();
                rdr = cmd.ExecuteReader();
                
                if (rdr.HasRows)
                {
                    rdr.Read();
                    try
                    {                        
                        coffeeImage = (byte[])rdr["CoffeeImage"];  
                    }
                    catch { }
                }
            }
            return coffeeImage;
        }
    }
}
