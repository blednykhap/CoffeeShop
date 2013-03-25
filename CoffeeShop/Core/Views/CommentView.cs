using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;

namespace Core.Views
{
    public class CommentView : Entity
    {
        public int OrderId { get; set; }

        public DateTime MakeDate { get; set; }

        public string Content { get; set; }
    }
}
