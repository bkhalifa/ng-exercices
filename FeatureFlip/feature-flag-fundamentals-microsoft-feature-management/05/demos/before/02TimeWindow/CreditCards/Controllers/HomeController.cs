using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CreditCards.Models;
using Microsoft.FeatureManagement;
using Microsoft.FeatureManagement.Mvc;
using Microsoft.AspNetCore.Http;

namespace CreditCards.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IFeatureManagerSnapshot _featureManager;
        private readonly IHttpContextAccessor _contextAccessor;

        public HomeController(ILogger<HomeController> logger, IFeatureManagerSnapshot featureManager, IHttpContextAccessor contextAccessor)
        {
            _logger = logger;
            _featureManager = featureManager;
            _contextAccessor = contextAccessor;
        }

        public async Task<IActionResult> IndexAsync()
        {
            for (int i = 0; i < 10; i++)
            {
                ViewData["PrintMessage"] += (await _featureManager.IsEnabledAsync(nameof(FeatureFlags.Printing))).ToString() + ", ";
                // await Task.Delay(5000);
            }

            _contextAccessor.HttpContext.Session.SetInt32("set something in session to retain session across requests", 42);

            ViewData["SessionId"] = _contextAccessor.HttpContext.Session.Id;

            return View();
        }

        [FeatureGate(FeatureFlags.Printing)]
        public IActionResult Print()
        {
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
