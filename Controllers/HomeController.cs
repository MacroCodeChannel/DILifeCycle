using DILifeCycle.Interfaces;
using DILifeCycle.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DILifeCycle.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITransientService _transientService1;
        private readonly IScopedService _scopedService1;
        private readonly ISingletonService _singletonService1;


        private readonly ITransientService _transientService2;
        private readonly IScopedService _scopedService2;
        private readonly ISingletonService _singletonService2;
        public HomeController(ILogger<HomeController> logger, 
            IScopedService scopedService1, 
            ISingletonService singletonService1,
            ITransientService transientService1,
            IScopedService scopedService2,
            ISingletonService singletonService2,
            ITransientService transientService2)
        {
            _logger = logger;
            _scopedService1 = scopedService1;
            _singletonService1 = singletonService1;
            _transientService1 = transientService1;

            _scopedService2 = scopedService2;
            _singletonService2 = singletonService2;
            _transientService2 = transientService2;
        }

        public IActionResult Index()
        {
            ViewBag.transient1=_transientService1.GetCurrentGUID().ToString();
            ViewBag.transient2 = _transientService2.GetCurrentGUID().ToString();

            ViewBag.scoped1 = _scopedService1.GetCurrentGUID().ToString();
            ViewBag.scoped2 = _scopedService2.GetCurrentGUID().ToString();

            ViewBag.singleton1 = _singletonService1.GetCurrentGUID().ToString();
            ViewBag.singleton2 = _singletonService2.GetCurrentGUID().ToString();
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
}