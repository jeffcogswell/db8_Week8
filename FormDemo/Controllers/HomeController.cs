using FormDemo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FormDemo.Controllers
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

		public IActionResult MyTest()
		{
			return Content("Hello world!");
		}

		public IActionResult CurrentTime()
		{
			// todo: Find out why this didn't work
			Request.ContentType = "text/html";
			DateTime current = DateTime.Now;
			return Content($"The <b>current</b> date and time is {current.ToString()}.");
		}

		public IActionResult Login()
		{
			return View();
		}

		public IActionResult ProcessLogin(string username, string password)
		{
			ViewBag.Username = username;
			ViewBag.Password = password;
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}