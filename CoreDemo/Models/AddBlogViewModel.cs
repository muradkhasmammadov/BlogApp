using EntityLayer.Concrete;
using System.ComponentModel.DataAnnotations;

namespace CoreDemo.Models
{
    public class AddBlogViewModel
    {
        [Required(ErrorMessage = "Can't be blank.")]
        public string BlogTitle { get; set; }

        [Required(ErrorMessage = "Can't be blank.")]
        public string BlogContent { get; set; }

        [Required(ErrorMessage = "Can't be blank.")]
        public IFormFile BlogThumbnailImage { get; set; }

        [Required(ErrorMessage = "Can't be blank.")]
        public IFormFile BlogImage { get; set; }

        public DateTime BlogCreateDate { get; set; }
        public bool BlogStatus { get; set; }
        public int WriterID { get; set; }
        public int CategoryID { get; set; }
        //[Required(ErrorMessage = "Can't be blank.")]
        public Category Category { get; set; }
    }
}
