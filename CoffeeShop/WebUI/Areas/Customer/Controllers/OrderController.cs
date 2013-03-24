using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core.Models;
using Core.Repositories;

namespace WebUI.Areas.Customer.Controllers
{
    public class OrderController : Controller
    {
        private readonly IBaseRepository<Order> rOrder;

        public OrderController(IBaseRepository<Order> rOrder)
        {
            this.rOrder = rOrder;
        }

        public ActionResult Index()
        {
            var orders = rOrder.GetList(p => p.IsCheckout == true);

            if (orders.Any())
            {
                return PartialView(orders.ToList());
            }
            else
            {
                return Content("You don't have checkout orders!");
            }
        }

        public ContentResult Checkout()
        {
            int orderId;

            if (Session["OrderId"] != null && Int32.TryParse(Session["OrderId"].ToString(), out orderId))
            {
                var order = rOrder.Get(p => p.Id == orderId);
                if (order.CurrentOrders.Sum(p => p.Quantity) > 0)
                {
                    order.IsCheckout = true;
                    rOrder.Update(order);
                    Session["OrderId"] = null;
                    return Content("The order was checked out!", "text/html");
                }
                else
                {
                    return Content("The bag is empty!", "text/html");
                }
            }

            return Content("There was an error during the checkout process!", "text/html");
        }
    }
}
