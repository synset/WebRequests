using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebRequests.Models;

namespace WebRequests.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        //Homepage
        public IActionResult Index()
        {
            return View();
        }
        //Page entering GET request
        public IActionResult GetRequest()
        {
            return View();
        }
        //Page displaying GET result
        public IActionResult GetResult()
        {
            return View();
        }
        //Page entering GET request
        public IActionResult PostRequest()
        {
            return View();
        }
        //Page displaying POST result
        public IActionResult PostResult()
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
