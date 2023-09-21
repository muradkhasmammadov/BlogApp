using DocumentFormat.OpenXml.Spreadsheet;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.VisualBasic;
using System.Reflection.Metadata;
using System.Security.AccessControl;

namespace CoreDemo.Controllers
{
    public class ErrorPageController : Controller
    {
        public IActionResult Error(int code)
        {
            return View();
        }

        [Route("Error/StatusCode/{statusCode}")]
        public IActionResult StatusCode(int statusCode)
        {
            return View(statusCode.ToString()); 
        }
    }
}
