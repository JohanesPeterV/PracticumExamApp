using Microsoft.AspNetCore.Mvc;

namespace SLCTestApplication.Controllers
{
    public class FileController : Controller
    {
        public IActionResult Index(string filePath)
        {
            byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);
            return File(fileBytes, "application/force-download", filePath);

        }
    }
}
