using System.Diagnostics;
using System.Threading.Tasks;
using DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using Models;
using MrBin.DAL;
using MrBin.Models;

namespace MrBin.Controllers;

public class HomeController : Controller
{
    private readonly UsrDAL _usrDAL;
    private readonly StateDAL _stateDAL;
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger,IConfiguration configuration)
    {
        _logger = logger;
        var connectionString = configuration.GetConnectionString("DB") ?? throw new ArgumentNullException("DB connection string is missing.");
        _usrDAL = new UsrDAL(connectionString);
        _stateDAL = new StateDAL(connectionString);
    }

    public async Task<IActionResult> UserRegister()
    {
        ViewBag.States = await _stateDAL.GetAllState();
        return View("UserRegister");
    }

    public async Task<IActionResult> Index()
    {
        var x = await _usrDAL.GetAll();
        foreach (var i in x)
        {
            Console.WriteLine(i.UserName);
        }
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
