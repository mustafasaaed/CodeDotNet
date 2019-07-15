using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CodeDotNet.Interfaces;
using Newtonsoft.Json;
using CodeDotNet.Models.Blog;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;
using CodeDotNet.Models.AdminViewModel;
using AutoMapper;

namespace CodeDotNet.Controllers
{
    public class AdminController : Controller
    {
        private IPostsBlogRepository _postsBlogRepository;

        public AdminController(IPostsBlogRepository postsBlogRepository)
        {
            _postsBlogRepository = postsBlogRepository;
        }

        public ActionResult ManagePosts()
        {
            var posts = _postsBlogRepository.Posts(1, 10);
            return View(posts);
        }

        [HttpGet]
        public ActionResult AddPost()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddPost(Post post)
        {
            if (ModelState.IsValid)
            {
                _postsBlogRepository.AddPost(post);
                RedirectToAction("ManagePosts");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {

            var post = _postsBlogRepository.FindPost(id);
            if (post != null)
            {
                return View(post);
            }
            return StatusCode(500, "Something went wrong!");
        }


        [HttpPost]
        public ActionResult Edit(Post post)
        {
            if (ModelState.IsValid)
            {
                _postsBlogRepository.EditPost(post);
                return RedirectToAction("ManagePosts");
            }
            else
            {
                return View();
            }
        }
    }
}