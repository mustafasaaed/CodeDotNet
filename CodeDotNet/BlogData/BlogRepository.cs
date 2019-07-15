using CodeDotNet.Data;
using CodeDotNet.Interfaces;
using CodeDotNet.Models.Blog;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeDotNet.BlogData
{
    public class BlogRepository : IPostsBlogRepository
    {
        private ApplicationDbContext _db;
        public BlogRepository(ApplicationDbContext db)
        {
            this._db = db;
        }

        public IList<Post> Posts(int pageNo, int pageSize)
        {
            var posts = _db.Set<Post>()
                .Where(p => p.Published)
                .OrderByDescending(p => p.PostedOn)
                .Take(pageSize)
                .Include(p => p.Category)
                .ToList();

            var postIds = posts.Select(p => p.Id).ToList();

            //_db.Posts
            return _db.Set<Post>()
                .Where(p => postIds.Contains(p.Id))
                .OrderByDescending(p => p.PostedOn)
                .ToList();

        }
        public int TotalPosts(bool checkIsPublished = true)
        {
            return _db.Posts.Where(p => !checkIsPublished || p.Published).Count();
        }


        public IList<Post> PostsForSearch(string search, int pageNo, int pageSize)
        {
            var posts = _db.Set<Post>()
                .Where(p => p.Published && (p.Title.Contains(search) ||
                 p.Category.Name.Equals(search)))
                .OrderByDescending(p => p.PostedOn)
                .Skip(pageSize * pageNo)
                .Take(pageSize)
                .Include(p => p.Category)
                .ToList();

            var postIds = posts.Select(p => p.Id).ToList();

            return _db.Set<Post>()
                .Where(p => postIds.Contains(p.Id))
                .OrderByDescending(p => p.PostedOn)
                .ToList();

        }
        public int TotalPostsForSearch(string search)
        {
            return _db.Set<Post>()
                .Where(p => p.Published && (p.Title.Contains(search) ||
                 p.Category.Name.Equals(search)))
                .Count();
        }
        public Post Post(int year, int month, string titleSlug)
        {
            var Set = _db.Posts
                .Where(p => p.PostedOn.Year == year && p.PostedOn.Month == month && p.UrlSlug.Equals(titleSlug));


            return Set.FirstOrDefault();
        }
        public IList<Post> Posts(int pageNo, int pageSize, string sortColumn, bool sortByAscending)
        {
            IList<Post> posts;
            IList<int> postIds;

            switch (sortColumn)
            {
                case "Title":
                    if (sortByAscending)
                    {
                        posts = _db.Set<Post>()
                        .OrderBy(p => p.Title)
                        .Skip(pageNo * pageSize)
                        .Take(pageSize)
                        .Include(p => p.Category)
                        .ToList();

                        postIds = posts.Select(p => p.Id).ToList();

                        posts = _db.Set<Post>()
                        .Where(p => postIds.Contains(p.Id))
                        .OrderBy(p => p.Title)
                        .ToList();
                    }
                    else
                    {
                        posts = _db.Set<Post>()
                        .OrderByDescending(p => p.Title)
                        .Skip(pageNo * pageSize)
                        .Take(pageSize)
                        .Include(p => p.Category)
                        .ToList();

                        postIds = posts.Select(p => p.Id).ToList();

                        posts = _db.Set<Post>()
                        .Where(p => postIds.Contains(p.Id))
                        .OrderByDescending(p => p.Title)
                        .ToList();
                    }
                    break;
                case "Published":
                    if (sortByAscending)
                    {
                        posts = _db.Set<Post>()
                        .OrderBy(p => p.Published)
                        .Skip(pageNo * pageSize)
                        .Take(pageSize)
                        .Include(p => p.Category)
                        .ToList();

                        postIds = posts.Select(p => p.Id).ToList();

                        posts = _db.Set<Post>()
                        .Where(p => postIds.Contains(p.Id))
                        .OrderBy(p => p.Published)
                        .ToList();
                    }
                    else
                    {
                        posts = _db.Set<Post>()
                        .OrderByDescending(p => p.Published)
                        .Skip(pageNo * pageSize)
                        .Take(pageSize)
                        .Include(p => p.Category)
                        .ToList();

                        postIds = posts.Select(p => p.Id).ToList();

                        posts = _db.Set<Post>()
                        .Where(p => postIds.Contains(p.Id))
                        .OrderByDescending(p => p.Published)
                        .ToList();
                    }
                    break;
                case "PostedOn":
                    if (sortByAscending)
                    {
                        posts = _db.Set<Post>()
                        .OrderBy(p => p.PostedOn)
                        .Skip(pageNo * pageSize)
                        .Take(pageSize)
                        .Include(p => p.Category)
                        .ToList();

                        postIds = posts.Select(p => p.Id).ToList();

                        posts = _db.Set<Post>()
                        .Where(p => postIds.Contains(p.Id))
                        .OrderBy(p => p.PostedOn)
                        .ToList();
                    }
                    else
                    {
                        posts = _db.Set<Post>()
                        .OrderByDescending(p => p.PostedOn)
                        .Skip(pageNo * pageSize)
                        .Take(pageSize)
                        .Include(p => p.Category)
                        .ToList();

                        postIds = posts.Select(p => p.Id).ToList();

                        posts = _db.Set<Post>()
                        .Where(p => postIds.Contains(p.Id))
                        .OrderByDescending(p => p.PostedOn)
                        .ToList();
                    }
                    break;
                case "Category":
                    if (sortByAscending)
                    {
                        posts = _db.Set<Post>()
                        .OrderBy(p => p.Category.Name)
                        .Skip(pageNo * pageSize)
                        .Take(pageSize)
                        .Include(p => p.Category)
                        .ToList();

                        postIds = posts.Select(p => p.Id).ToList();

                        posts = _db.Set<Post>()
                        .Where(p => postIds.Contains(p.Id))
                        .OrderBy(p => p.Category.Name)
                        .ToList();
                    }
                    else
                    {
                        posts = _db.Set<Post>()
                        .OrderByDescending(p => p.Category.Name)
                        .Skip(pageNo * pageSize)
                        .Take(pageSize)
                        .Include(p => p.Category)
                        .ToList();

                        postIds = posts.Select(p => p.Id).ToList();

                        posts = _db.Set<Post>()
                        .Where(p => postIds.Contains(p.Id))
                        .OrderByDescending(p => p.Category.Name)
                        .ToList();
                    }
                    break;
                default:
                    posts = _db.Set<Post>()
                    .OrderByDescending(p => p.PostedOn)
                    .Skip(pageNo * pageSize)
                    .Take(pageSize)
                    .Include(p => p.Category)
                    .ToList();

                    postIds = posts.Select(p => p.Id).ToList();

                    posts = _db.Set<Post>()
                    .Where(p => postIds.Contains(p.Id))
                    .OrderByDescending(p => p.PostedOn)
                    .ToList();
                    break;
            }

            return posts;
        }



        public Post FindPost(int id)
        {
            var post = _db.Posts.Find(id);
            if (post == null)
            {
                return null;
            }
            else
            {
                return post;
            }
        }

        public int AddPost(Post post)
        {
            _db.Posts.Add(post);
            _db.SaveChanges();
            return post.Id;
        }
        public void EditPost(Post post)
        {
            var dbPost = _db.Posts.Find(post.Id);
            if (dbPost != null)
            {
                _db.Entry(dbPost).CurrentValues.SetValues(post);
                _db.SaveChanges();
            }
            else if (dbPost == null)
            {
                _db.Posts.Add(post);
                _db.SaveChanges();
            }
        }
        public void DeletePost(int id)
        {
            var post = _db.Posts.Find(id);
            _db.Posts.Remove(post);
            _db.SaveChanges();
        }
    }
}
