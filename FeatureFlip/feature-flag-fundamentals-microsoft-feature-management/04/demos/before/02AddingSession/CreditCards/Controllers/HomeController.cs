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

namespace CreditCards.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IFeatureManagerSnapshot _featureManager;

        public HomeController(ILogger<HomeController> logger, IFeatureManagerSnapshot featureManager)
        {
            _logger = logger;
            _featureManager = featureManager;
        }

        public async Task<IActionResult> IndexAsync()
        {
            for (int i = 0; i < 10; i++)
            {
                ViewData["PrintMessage"] += (await _featureManager.IsEnabledAsync(nameof(FeatureFlags.Printing))).ToString() + ", ";
                await Task.Delay(5000);
            }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [FeatureGate(RequirementType.Any, FeatureFlags.Printing, FeatureFlags.PrintPreview)]
        public IActionResult Print()
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
