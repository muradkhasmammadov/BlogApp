using ClosedXML.Excel;
using CoreDemo.Areas.Admin.Models;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        public IActionResult ExportDynamicExcelList()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Blog List");
                worksheet.Cell(1, 1).Value = "Blog ID";
                worksheet.Cell(1, 2).Value = "Blog Name";
                worksheet.Cell(1, 3).Value = "Blog Content";
                worksheet.Cell(1, 4).Value = "Blog Thumbnail Image";
                worksheet.Cell(1, 5).Value = "Blog Main Image";
                worksheet.Cell(1, 6).Value = "Blog Published Date";
                worksheet.Cell(1, 7).Value = "Blog Status";
                worksheet.Cell(1, 8).Value = "Blog Category";
                worksheet.Cell(1, 9).Value = "Blog Writer";

                int BlogRowCount = 2;
                foreach (var item in BlogTitleList())
                {
                    worksheet.Cell(BlogRowCount, 1).Value = item.ID;
                    worksheet.Cell(BlogRowCount, 2).Value = item.BlogName;
                    worksheet.Cell(BlogRowCount, 3).Value = item.BlogContent;
                    worksheet.Cell(BlogRowCount, 4).Value = item.BlogThumbnailImage;
                    worksheet.Cell(BlogRowCount, 5).Value = item.BlogImage;
                    worksheet.Cell(BlogRowCount, 6).Value = item.BlogCreateDate;
                    worksheet.Cell(BlogRowCount, 7).Value = item.BlogStatus;
                    worksheet.Cell(BlogRowCount, 8).Value = item.CategoryID;
                    worksheet.Cell(BlogRowCount, 9).Value = item.WriterID;
                    BlogRowCount++;
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "BlogData.xlsx");
                }
            }
        }
        public List<BlogModel> BlogTitleList()
        {
            List<BlogModel> bm = new List<BlogModel>();
            using (var c = new Context())
            {
                bm = c.BLogs.Select(x => new BlogModel
                {
                    ID = x.BlogID,
                    BlogName = x.BlogTitle,
                    BlogContent = x.BlogContent,
                    BlogThumbnailImage = x.BlogThumbnailImage,
                    BlogImage = x.BlogImage,
                    BlogCreateDate = x.BlogCreateDate,
                    BlogStatus = x.BlogStatus,
                    CategoryID = x.CategoryID,
                    WriterID = x.WriterID
                }).ToList();
            }
            return bm;
        }
        public IActionResult BlogTitleListExcel()
        {
            return View();
        }

    }
}
