using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;
using Core.Structures;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Core.Views
{
    public class CoffeeFlavorListView
    {        
        //public Coffee Coffee { get; set; }
        public string CurrentCoffee { get; set; }
        public IEnumerable<Flavor> Flavors { get; set; }
        public PagingInfo PagingInfo { get; set; }        
        [Required(ErrorMessage = "The value is required!")]
        [RegularExpression(@"[0-9]", ErrorMessage = "The value should be between 1 and 9!")]        
        public int Quantity { get; set; }
    }
}
