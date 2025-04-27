using System.Diagnostics;
using DAL;
using Microsoft.AspNetCore.Mvc;
using MrBin.Models;
using Models;
using MrBin.DAL;
namespace MrBin.Controllers;
public class HomeController : Controller
{    
    private readonly UsrDAL _usrDAL;
    private readonly StateDAL _stateDAL;
    private readonly DistDAL _distDAL;
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger,IConfiguration configuration)
    {
        _logger = logger;
        var connectionString = configuration.GetConnectionString("DB") ?? throw new ArgumentNullException("DB connection string is missing.");
        _usrDAL = new UsrDAL(connectionString);
        _stateDAL = new StateDAL(connectionString);
        _distDAL = new DistDAL(connectionString);
    }

    public async Task<IActionResult> UserRegister()
    {
        ViewBag.States = await _stateDAL.GetAllState();
        return View("UserRegister");
    }
    
    [HttpPost]
    public async Task<List<Dist>> GetDist(string stateId)
    {
        Console.WriteLine("State ID: " + stateId);
        var dist = await _distDAL.GetAllState(stateId);
        return dist;
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
