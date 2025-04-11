using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebUniversity.ViewModels;

namespace WebUniversity.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public IActionResult Logging()
        {
            WebUniversity.ViewModels.RegisterViewModel registerView = new ViewModels.RegisterViewModel();
            return View(registerView);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult TryLog(RegisterViewModel registerView)
        {
            RegisterViewModel trueRegisterData = new RegisterViewModel();
            string jsonData = System.IO.File.ReadAllText("appsettings.json");
            dynamic jsonObject = JsonConvert.DeserializeObject(jsonData);

            trueRegisterData = jsonObject.Admin.ToObject<RegisterViewModel>();
            if (registerView.Equals(trueRegisterData))
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Logging");
        }
    }
}