using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class OrderFlavor: Entity
    {
        public int OrderId { get; set; }
        [DisplayName("Order")]
        public virtual Order Order { get; set; }

        public int FlavorId { get; set; }
        [DisplayName("Flavor")]
        public virtual Flavor Flavor { get; set; }

        [DisplayName("Quantity")]
        public int Quantity { get; set; }

        //public double TotalSum()
        //{
            
        //}
    }
}
