using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using MVCWebApplicationUI.Models;

namespace MVCWebApplicationUI.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			_logger.LogInformation("GET, Home Controller, Index View, No Model");
			return View();
		}

		public IActionResult Privacy()
		{
			_logger.LogInformation("GET, Home Controller, Privacy View, No Model");
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			string requestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
			ErrorViewModel errorViewModel = new ErrorViewModel { RequestId = requestId };
			_logger.LogError("GET, Home Controller, Error View, Error View Model with requestId = {requestId}", requestId);
			return View(errorViewModel);
		}
	}
}
