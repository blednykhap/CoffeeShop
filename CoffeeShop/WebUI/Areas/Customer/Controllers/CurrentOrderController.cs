using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core.Repositories;
using Core.Models;


namespace WebUI.Areas.Customer.Controllers
{
    public class CurrentOrderController : Controller
    {
        private readonly IBaseRepository<CurrentOrder> rCurrentOrder;
        private readonly IBaseRepository<Order> rOrder;

        public CurrentOrderController(IBaseRepository<CurrentOrder> rCurrentOrder, IBaseRepository<Order> rOrder)
        {
            this.rCurrentOrder = rCurrentOrder;
            this.rOrder = rOrder;
        }

        public ActionResult Index()
        {
            int orderId;            
            Order order = null;

            if (Session["OrderId"] != null && Int32.TryParse(Session["OrderId"].ToString(), out orderId))
            {
                order = rOrder.Get(p => p.Id == orderId);
            }

            if (order != null)
            {
                return PartialView(order);
            }
            else
            {
                return Content("The bag is empty", "text/html");
            }
            
        }

        public ContentResult Add(int flavorId, int quantity)
        {            
            int orderId;

            if (Session["OrderId"] == null || !Int32.TryParse(Session["OrderId"].ToString(), out orderId))
            {
                var order = new Order();
                rOrder.Create(order);
                orderId = order.Id;
                Session["OrderId"] = orderId;
            }
            else
            {
                Int32.TryParse(Session["OrderId"].ToString(), out orderId);
            }

            if (quantity != 0)
            {
                CurrentOrder currentOrder = rCurrentOrder.Get(p => p.OrderId == orderId && p.FlavorId == flavorId);
                if (currentOrder == null)
                {
                    currentOrder = new CurrentOrder();
                    currentOrder.FlavorId = flavorId;
                    currentOrder.OrderId = orderId;
                    currentOrder.Quantity = quantity;
                    rCurrentOrder.Create(currentOrder);
                }
                else
                {
                    currentOrder.Quantity += quantity;
                    rCurrentOrder.Update(currentOrder);
                }
            }

            return Content("0", "text/html");
        }

        public ContentResult CalculateQuantity()
        {
            int quantity = 0;
            int orderId;

            if (Session["OrderId"] != null && Int32.TryParse(Session["OrderId"].ToString(), out orderId))
            {
                quantity = rCurrentOrder.GetList(p => p.OrderId == orderId).Sum(p => p.Quantity);
            }

            return Content(quantity.ToString(), "text/html");
        }

        public ActionResult Delete(int orderFlavorId)
        {
            int orderId;
            Order order = null;
            var currentOrder = rCurrentOrder.Get(p => p.Id == orderFlavorId);
            rCurrentOrder.Delete(currentOrder);

            if (Session["OrderId"] != null && Int32.TryParse(Session["OrderId"].ToString(), out orderId))
            {
                order = rOrder.Get(p => p.Id == orderId);
            }

            return PartialView("Index", order);
        }
    }
}
