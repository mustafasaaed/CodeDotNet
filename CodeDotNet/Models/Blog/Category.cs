using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CodeDotNet.Models.Blog
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "Name :  Length should not exceed 500 characters")]
        public string Name { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "UrlSlug:  Length should not exceed 500 characters")]
        public string UrlSlug { get; set; }

        public string Description { get; set; }
        public DateTime PostedOn { get; set; }


        [JsonIgnore]
        public virtual IList<Post> Posts { get; set; }
    }
}
