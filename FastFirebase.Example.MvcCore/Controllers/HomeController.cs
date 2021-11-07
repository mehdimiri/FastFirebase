using FastFirebase.Example.MvcCore.Models;
using FastFirebase.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FastFirebase.Example.MvcCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPushService _pushService;
        public HomeController(IPushService pushService)
        {
            _pushService = pushService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendPush(PushJsonModel model)
        {
            _pushService.SendPushAsync(model);
            return View();
        }
    }
}
