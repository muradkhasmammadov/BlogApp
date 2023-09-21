using EntityLayer.Concrete;

namespace CoreDemo.Areas.Admin.Models
{
    public class BlogModel
    {
        public int ID { get; set; }
        public string BlogName { get; set; }
        public string BlogContent { get; set; }
        public string BlogThumbnailImage { get; set; }
        public string BlogImage { get; set; }
        public DateTime BlogCreateDate { get; set; }
        public bool BlogStatus { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
        public int WriterID { get; set; }
        public AppUser Writer { get; set; }
    }
}
