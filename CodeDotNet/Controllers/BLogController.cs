using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using CodeDotNet.Interfaces;
using CodeDotNet.Models.BlogViewModels;
using System.Net.Mail;
using MailKit.Net.Smtp;
using MimeKit;
using SendGrid.Helpers.Mail;
using SendGrid;

namespace CodeDotNet.Controllers
{
    [AllowAnonymous]
    public class BlogController : Controller
    {
        private readonly IPostsBlogRepository _postsBlogRepository;

        public BlogController(IPostsBlogRepository postsBlogRepository)
        {
            _postsBlogRepository = postsBlogRepository;
        }

        public ViewResult Posts(int p = 1)
        {
            var listViewModel = new ListViewModel(_postsBlogRepository, p);
            ViewBag.Title = "Latest Posts";
            return View("List", listViewModel);
        }



        //public ViewResult Search(string s, int p = 1)
        //{
        //    ViewBag.Title = String.Format(@"Lists of posts found
        //                for search text ""{0}""", s);

        //    var viewModel = new ListViewModel(_blogRepository, s, "Search", p);
        //    return View("List", viewModel);
        //}

        public ActionResult Post(int year, int month, string title)
        {
            var post = _postsBlogRepository.Post(year, month, title);

            if (post == null)
                return NotFound("Post not found");

            if (post.Published == false && User.Identity.IsAuthenticated == false)
                return BadRequest("The post is not published");

            return View(post);
        }

        //public ActionResult About()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public async Task<ActionResult> Contact()
        //{

        //    var apiKey = "";
        //    var client = new SendGridClient(apiKey);
        //    var from = new EmailAddress("phmustafasaeed@outlook.com", "Mustafa Saeed");
        //    var subject = "Testinnnnnng";
        //    var to = new EmailAddress("mustafasaeed202019@gmail.com", "Mustafa Saeed");
        //    var plainText = "Some Random Words";
        //    var htmlContent = "<strong>C##</strong>";
        //    var msg = MailHelper.CreateSingleEmail(from, to, subject, plainText, htmlContent);
        //    var response = await client.SendEmailAsync(msg);
        //    return RedirectToAction("Posts");

        //}
    }
}

