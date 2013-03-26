using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core.Models;
using Core.Repositories;
using Core.Views;
using Core.Filters;

namespace WebUI.Areas.Customer.Controllers
{
    public class CommentController : Controller
    {
        private readonly IBaseRepository<Comment> rComment;

        public CommentController(IBaseRepository<Comment> rComment)
        {
            this.rComment = rComment;
        }

        [NoCache]
        public ActionResult Index(int orderId)
        {
            var comments = (from p in rComment.GetList(p => p.OrderId == orderId).ToList()
                            select new CommentView()
                                       {
                                           Id = p.Id,
                                           MakeDate = p.MakeDate,
                                           Content = p.Content
                                       });

            return PartialView(comments);
        }

        public ActionResult Create(int orderId)
        {
            var comment = new CommentView();
            comment.OrderId = orderId;
            return PartialView(comment);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(Comment comment)
        {
            comment.MakeDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                rComment.Create(comment);
            }            
            var comments = (from p in rComment.GetList(p => p.OrderId == comment.OrderId).ToList()
                            select new CommentView()
                            {
                                Id = p.Id,
                                MakeDate = p.MakeDate,
                                Content = p.Content
                            });
            return PartialView("Index", comments.ToList());
        }
    }
}
