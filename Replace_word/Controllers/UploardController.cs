using Microsoft.AspNetCore.Mvc;

public class UploadController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Process(IFormFile file)
    {
        if (file != null && file.Length > 0)
        {
            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                var content = reader.ReadToEnd();
                var updatedContent = content.Replace("T", "C");
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", file.FileName);
                System.IO.File.WriteAllText(filePath, updatedContent);
            }
            TempData["Message"] = "File processed and saved successfully.";
        }
        else
        {
            TempData["InsertMsg"] = "Failed to save data.";
        }
        return View("Index");
    }
}