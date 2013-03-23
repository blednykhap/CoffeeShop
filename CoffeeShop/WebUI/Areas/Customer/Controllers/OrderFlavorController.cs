using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core.Repositories;
using Core.Models;


namespace WebUI.Areas.Customer.Controllers
{
    public class OrderFlavorController : Controller
    {
        private readonly IBaseRepository<OrderFlavor> rOrderFlavor;
        private readonly IBaseRepository<Order> rOrder;

        public OrderFlavorController(IBaseRepository<OrderFlavor> rOrderFlavor, IBaseRepository<Order> rOrder)
        {
            this.rOrderFlavor = rOrderFlavor;
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

            return PartialView(order);
        }
        
        public ContentResult Add(int flavorId)
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

            OrderFlavor orderFlavor = rOrderFlavor.Get(p => p.OrderId == orderId && p.FlavorId == flavorId);
            if (orderFlavor == null)
            {
                orderFlavor = new OrderFlavor();
                orderFlavor.FlavorId = flavorId;
                orderFlavor.OrderId = orderId;
                orderFlavor.Quantity = 1;
                rOrderFlavor.Create(orderFlavor);
            }
            else
            {
                orderFlavor.Quantity += 1;
                rOrderFlavor.Update(orderFlavor);
            }

            return Content("Coffee was added to your bag!", "text/html");
        }

        public ContentResult CalculateQuantity()
        {
            int quantity = 0;
            int orderId;

            if (Session["OrderId"] != null && Int32.TryParse(Session["OrderId"].ToString(), out orderId))
            {
                quantity = rOrderFlavor.GetList(p => p.OrderId == orderId).Sum(p => p.Quantity);
            }

            return Content(quantity.ToString(), "text/html");
        }
    }
}
