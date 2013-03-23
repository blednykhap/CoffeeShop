using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Coffee : Entity
    {
        [MaxLength(100)]
        [DisplayName("Code")]
        public string Code { get; set; }

        [MaxLength(500)]
        [DisplayName("Name")]
        public string Name { get; set; }

        public virtual List<Flavor> Flavors { get; set; }
    }
}
