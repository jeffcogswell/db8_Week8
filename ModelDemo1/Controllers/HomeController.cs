using Microsoft.AspNetCore.Mvc;
using ModelDemo1.Models;
using System.Diagnostics;

namespace ModelDemo1.Controllers
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
			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		public IActionResult Sample()
		{
			Person fred = new Person() { FirstName = "Fred", 
				LastName = "Franklin", Email = "fred@abc.com", Born = 1970 };
			return View(fred);
		}

		public IActionResult ShowRegister()
		{
			return View();
		}

		public IActionResult Register(Person per)
		{
			return View(per);
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}