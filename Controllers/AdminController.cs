using Microsoft.AspNetCore.Mvc;
namespace MrBin.Controllers;

public class AdminController : Controller
{
    private readonly IConfiguration _configuration;

    public AdminController(IConfiguration configuration)
    {
        _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        if (_configuration.GetConnectionString("DB") == null)
        {
            throw new ArgumentNullException(nameof(configuration), "DB connection string is missing.");
        }
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Index(string userId, string password)
    {

        if (userId.Equals("admin") && password.Equals("admin"))
        {
            return Redirect("/Home/registerRCV");
        }
        else
        {
            return View();
        }
    }
    [HttpGet]
    public IActionResult RegisterRCV()
    {
        return View("registerRCV");
    }
    [HttpPost]
    public IActionResult RegisterRCV(MrBin.Models.RCV model)
    {
        if (ModelState.IsValid){
            return RedirectToAction("Index");
        }
        return View(model);
    }
}
