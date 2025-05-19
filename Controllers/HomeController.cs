using System.Diagnostics;
using DAL;
using Microsoft.AspNetCore.Mvc;
using MrBin.Models;
using Models;
using MrBin.DAL;
using System.Net.Mail;
namespace MrBin.Controllers;
public class HomeController : Controller
{    
    private readonly UsrDAL _usrDAL;
    private readonly StateDAL _stateDAL;
    private readonly DistDAL _distDAL;
    private readonly ZipCodeDAL _zipDAL;
    private readonly keyAccessDAL _keyAccessDAL;
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
    {
        _logger = logger;
        var connectionString = configuration.GetConnectionString("DB") ?? throw new ArgumentNullException("DB connection string is missing.");
        _usrDAL = new UsrDAL(connectionString);
        _stateDAL = new StateDAL(connectionString);
        _distDAL = new DistDAL(connectionString);
        _zipDAL = new ZipCodeDAL(connectionString);
        _keyAccessDAL = new keyAccessDAL(connectionString);
    }

    public async Task<IActionResult> UserRegister()
    {
        ViewBag.States = await _stateDAL.GetAllState();
        return View("UserRegister");
    }
    
    [HttpGet]
    public async Task<List<Dist>> GetDist(string stateId)
    {
        // Console.WriteLine("State ID: " + stateId);
        var dist = await _distDAL.GetAllState(stateId);
        return dist;
    }

    [HttpGet]
    public async Task<List<ZipCode>> getZipCode(string distId){
        // Console.WriteLine("District ID: " + distId);
        var x=await _zipDAL.GetAllZipCode(distId);
        return x;
    }

    //route for EMAIL Verification
    [HttpGet]
    public async Task<IActionResult> CheckEmail(string email)
    {
        Random random = new Random();
        int Gkey= random.Next(100000, 999999);
        try
        {
            await Task.Run(() =>
            {
                using (MailMessage m = new MailMessage())
                {
                    m.From = new MailAddress("chatapp659@gmail.com");
                    m.To.Add(email);
                    m.Subject = "Verify Your Email";
                    m.SubjectEncoding = System.Text.Encoding.UTF8;
                    m.Body = $@"
                        <div style='font-family: Arial, sans-serif; background: #f4f4f4; padding: 30px;'>
                            <div style='max-width: 500px; margin: auto; background: #fff; border-radius: 8px; box-shadow: 0 2px 8px rgba(0,0,0,0.1); padding: 30px;'>
                                <h2 style='color: #4CAF50; text-align: center;'>Welcome,</h2>
                                <p style='font-size: 16px; color: #333;'>Thank you for registering with us.</p>
                                <p style='font-size: 16px; color: #333;'>Please verify your email address to complete your registration.</p>
                                <div style='text-align: center; margin: 30px 0;'>
                                    <a href='http://localhost:5251/Home/UpdateSituation?key={Gkey}&email={email}' style='background: #4CAF50; color: #fff; padding: 12px 30px; border-radius: 5px; text-decoration: none; font-weight: bold; font-size: 16px;'>Verify Email</a>
                                </div>
                                <p style='font-size: 14px; color: #888; text-align: center;'>If you did not request this, please ignore this email.</p>
                            </div>
                        </div>";
                    m.IsBodyHtml = true;
                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtp.Credentials = new System.Net.NetworkCredential("chatapp659@gmail.com", "mjwn gmtx eekj vkdv");
                        smtp.EnableSsl = true;
                        smtp.Send(m);
                    }
                }
            });
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        await  _keyAccessDAL.StoreKey(email, Gkey);

        while (true)
        {
            var x = await _keyAccessDAL.GetSituation(email, Gkey);
            if (x == 1){
                return Json(new { success = true });
            }
            else if(x==0){
                // Console.WriteLine("Email not verified yet");
                Task.Delay(1000).Wait();
                continue;
            }
        }
    }

    [HttpGet]
    public async Task UpdateSituation()
    {
        // Console.WriteLine("UpdateSituation called");
        var Gkey = Request.Query["key"];
        var email = Request.Query["email"];
        await _keyAccessDAL.UpdateKey(email, Convert.ToInt32(Gkey));
        Response.ContentType = "text/html";
        await Response.WriteAsync(System.IO.File.ReadAllText("wwwroot/banner.html"));
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
