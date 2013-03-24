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
        private int pageSize = 10;
        private readonly IBaseRepository<Flavor> rFlavor;

        public FlavorController(IBaseRepository<Flavor> rFlavor)
        {            
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

        public ActionResult ShowImage(int flavorId)
        {           
            byte[] coffeeImage = ImageLogic.GetFromDB(flavorId);

            return File(coffeeImage, "image/jpeg");
        }
    }
}
