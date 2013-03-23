using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Order : Entity
    {
        public virtual List<OrderFlavor> OrderFlavors { get; set; }

        public double TotalSum() {
            return OrderFlavors.Sum(p => p.Flavor.Price * p.Quantity);
        }
    }
}
