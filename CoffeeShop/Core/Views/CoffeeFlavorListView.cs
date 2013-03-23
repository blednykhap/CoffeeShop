using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;
using Core.Structures;

namespace Core.Views
{
    public class CoffeeFlavorListView
    {        
        //public Coffee Coffee { get; set; }
        public string CurrentCoffee { get; set; }
        public IEnumerable<Flavor> Flavors { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
