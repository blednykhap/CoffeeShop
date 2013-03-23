using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Flavor : Entity
    {
        [MaxLength(200)]
        [DisplayName("Name")]
        public string Name { get; set; }

        public int CoffeeId { get; set; }
        [DisplayName("Coffee")]
        public virtual Coffee Coffee { get; set; }

        [MaxLength(200)]
        [DisplayName("Tasting Notes")]
        public string TastingNotes { get; set; }

        [MaxLength(200)]
        [DisplayName("Enjoy this with")]
        public string EngoyWith { get; set; }

        [MaxLength(1000)]
        [DisplayName("Description")]
        public string Description { get; set; }

        [MaxLength(100)]
        [DisplayName("Roast")]
        public string Roast { get; set; }

        [MaxLength(100)]
        [DisplayName("Region")]
        public string Region { get; set; }

        [DisplayName("Price")]
        public double Price { get; set; }

        [DisplayName("Image")]
        public byte[] CoffeeImage { get; set; }

        [MaxLength(100)]
        [DisplayName("Content Type")]
        public string ContentType { get; set; }
    }
}
