using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bussiness.Files;
using System.Data.SqlClient;
using System.Configuration;
using Core.Repositories;
using Core.Models;
using Core.Views;
using Core.Structures;

namespace WebUI.Areas.Customer.Controllers
{
    public class FlavorController : Controller
    {
        private int pageSize = 3;
        private readonly IBaseRepository<Coffee> rCoffee;
        private readonly IBaseRepository<Flavor> rFlavor; //sdf

        public FlavorController(IBaseRepository<Coffee> rCoffee, IBaseRepository<Flavor> rFlavor)
        {            
            this.rCoffee = rCoffee;
            this.rFlavor = rFlavor;
        }

        public ActionResult Index(string coffeeCode = "StarbucksBlonde", int page = 1)
        {

            var result = new CoffeeFlavorListView()
            {                
                CurrentCoffee = coffeeCode,
                Flavors = rFlavor.GetList(p => p.Coffee.Code == coffeeCode)
                        .OrderBy(p => p.Id)
                        .Skip((page - 1) * pageSize)
                        .Take(pageSize).ToList(),
                PagingInfo = new PagingInfo()
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = rFlavor.GetList(p => p.Coffee.Code == coffeeCode).Count()
                }
            };

            return PartialView(result);
        }

        //public FileContentResult ShowImage(int flavorId)
        public ActionResult ShowImage(int flavorId)
        {
            //byte[] fileContent = ImageLogic.GetFromDB("Flavors", flavorId);

            SqlDataReader rdr;
            byte[] coffeeImage = null;
            //string connect = ConfigurationManager.ConnectionStrings["ApplicationConn"].ConnectionString;

            //using (var conn = new SqlConnection(connect))
            //{
            //    var qry = "SELECT CoffeeImage FROM Flavors WHERE Id = @Id";
            //    var cmd = new SqlCommand(qry, conn);
            //    //cmd.Parameters.AddWithValue("@ObjectName", objectNamePLR);
            //    cmd.Parameters.AddWithValue("@Id", flavorId);
            //    conn.Open();
            //    rdr = cmd.ExecuteReader();
            //    if (rdr.HasRows)
            //    {
            //        rdr.Read();
            //        try
            //        {
            //            coffeeImage = (byte[])rdr["CoffeeImage"];
            //        }
            //        catch { rdr.Dispose(); }
            //    }
            //}
            //rdr.Dispose();
            //return File(coffeeImage, "image/jpeg");
            return Content("");
        }
    }
}
