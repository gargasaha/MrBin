using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MrBin.DAL;
using MrBin.Models;

namespace MrBin.Controllers;

public class HomeController : Controller
{
    private UsrDAL _usrDAL;
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger,IConfiguration configuration)
    {
        _logger = logger;
        var connectionString = configuration.GetConnectionString("DB") ?? throw new ArgumentNullException("DB connection string is missing.");
        _usrDAL = new UsrDAL(connectionString);
    }

    public IActionResult Index()
    {
        var x=_usrDAL.GetAll();
        Console.WriteLine(x.Result);
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
