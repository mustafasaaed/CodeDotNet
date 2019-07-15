using CodeDotNet.Models.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeDotNet.Interfaces
{
    public interface IPostsBlogRepository
    {
        IList<Post> Posts(int pageNo, int pageSize);
        int TotalPosts(bool checkIsPublished = true);

        IList<Post> PostsForSearch(string search, int pageNo, int pageSize);
        int TotalPostsForSearch(string search);
        Post Post(int year, int month, string titleSlug);
        IList<Post> Posts(int pageNo, int pageSize, string sortColumn, bool sortByAscending);

        Post FindPost(int id);


        int AddPost(Post post);
        void EditPost(Post post);
        void DeletePost(int id);
    }
}
