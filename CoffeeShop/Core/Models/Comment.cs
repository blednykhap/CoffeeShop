using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Comment : Entity
    {
        public int OrderId { get; set; }
        [DisplayName("Order")]
        public virtual Order Order { get; set; }

        [DisplayName("Make Date")]
        public DateTime MakeDate { get; set; }

        [MaxLength(1000)]
        [DisplayName("Comment")]
        public string Content { get; set; }
    }
}
