using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core.Views;
using System.Text;
using System.Web.Mvc.Ajax;

namespace WebUI.HtmlHelpers
{
    
    public static class PagingHelpers
    {
        public static MvcHtmlString FlavorPageLinks(this AjaxHelper html, CoffeeFlavorListView coffeeFlavor/*, Func<int, string> pageUrl*/)
        {
            StringBuilder result = new StringBuilder();

            var options = new AjaxOptions()
            {
                UpdateTargetId = "customer-content",
                //OnComplete = "CalculateQuantity()",
                InsertionMode = InsertionMode.Replace,
                HttpMethod = "POST"
            };

            for (int i = 1; i <= coffeeFlavor.PagingInfo.TotalPages; i++)
            {
                var link = html.ActionLink(i.ToString(), "Index", "Flavor",
                    new { coffeeCode = coffeeFlavor.CurrentCoffee, page = i }, options, new { @class = (coffeeFlavor.PagingInfo.CurrentPage == i ? "selected" : null) });
                result.Append(link.ToString());
            }

            return MvcHtmlString.Create(result.ToString());
        }
    }



}