using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CodeDotNet.Models.Blog
{
    public class Post
    {

        [Required(ErrorMessage = "Id: Field is required")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Title: Field is required")]
        [StringLength(500, ErrorMessage = "Title: Length should not exceed 500 characters")]
        public string Title { get; set; }

        [Required(ErrorMessage = "ShortDescription: Field is required")]
        [Display(Name = "Short Description")]
        public string ShortDescription { get; set; }

        [Required(ErrorMessage = "Description: Field is required")]
        public string Description { get; set; }
        
        [Required(ErrorMessage = "UrlSlug: Field is required")]
        [StringLength(1000, ErrorMessage = "UrlSlug should not exceed 50 characters")]
        [Display(Name = "Url Slug")]
        public string UrlSlug { get; set; }

        [Required(ErrorMessage = "PostedOn: Field is required")]
        public bool Published { get; set; }

        [Required(ErrorMessage = "Image Url Is Required")]
        [Display(Name = "Image Url")]
        public string ImageUrl { get; set; }

        [Display(Name = "Posted On")]
        public DateTime PostedOn { get; set; }
        public Category Category { get; set; }

    }
}
