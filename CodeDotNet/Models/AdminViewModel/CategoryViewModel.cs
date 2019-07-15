using CodeDotNet.Models.Blog;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CodeDotNet.Models.AdminViewModel
{
    public class CategoryViewModel
    {

        [Required(ErrorMessage = "Id: Field is required")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Title: Field is required")]
        [StringLength(500, ErrorMessage = "Title: Length should not exceed 500 characters")]
        public string Title { get; set; }

        [Required(ErrorMessage = "ShortDescription: Field is required")]
        public string ShortDescription { get; set; }

        [Required(ErrorMessage = "Description: Field is required")]
        public string Description { get; set; }


        [Required(ErrorMessage = "Meta: Field is required")]
        [StringLength(1000, ErrorMessage = "Meta: Length should not exceed 1000 characters")]
        public string Meta { get; set; }


        [Required(ErrorMessage = "UrlSlug: Field is required")]
        [StringLength(1000, ErrorMessage = "UrlSlug should not exceed 50 characters")]
        public string UrlSlug { get; set; }

        [Required(ErrorMessage = "PostedOn: Field is required")]
        public bool Published { get; set; }


        public DateTime PostedOn { get; set; }
        public DateTime? Modified { get; set; }

        public Category Category { get; set; }
        public IList<Category> Categorties { get; set; }
    }
}
