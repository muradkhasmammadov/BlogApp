using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Blog
    {
        [Key]
        public int BlogID { get; set; }
        [Required(ErrorMessage = "Can't be blank.")]
        public string BlogTitle { get; set; }

        [Required(ErrorMessage = "Can't be blank.")]
        public string BlogContent { get; set; }
        
        [Required(ErrorMessage = "Can't be blank.")]
        public string BlogThumbnailImage { get; set; }
        
        [Required(ErrorMessage = "Can't be blank.")]
        public string BlogImage { get; set; }
        
        public DateTime BlogCreateDate { get; set; }
        public bool BlogStatus { get; set; }
        public int CategoryID { get; set; }
        [Required(ErrorMessage = "Can't be blank.")]
        public Category Category { get; set; }
		public int WriterID { get; set; }
		public AppUser Writer { get; set; }
		public List<Comment> Comments { get; set; } 
    }
}
