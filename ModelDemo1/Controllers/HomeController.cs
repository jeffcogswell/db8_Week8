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

		public IActionResult SampleList()
		{
			List<Person> people = new List<Person>();
			Person per = new Person() { FirstName = "Fred", 
				LastName = "Franklin", Email = "fred@abc.com", Born = 1970 };
			people.Add(per);
			per = new Person() { FirstName = "Sally",
				LastName = "Smith", Email = "sally@abc.com", Born = 1990};
			people.Add(per);
			per = new Person() { FirstName = "Julia",
				LastName = "Jones", Email = "julia@abc.com", Born = 1980 };
			people.Add(per);

			//foreach (Person next in people)
			//{
			//	Console.WriteLine($"{next.FirstName} {next.LastName}");
			//}

			//ViewBag.Department = "IT";
			ViewData["Department"] = "IT";
			ViewData["Year"] = 2022;

			return View(people);
		}

		public IActionResult ShowRegister()
		{
			return View();
		}

		public IActionResult Register(Person per)
		{
			if (per.Born > 2004)
			{
				// Let's use a different view for people under 18
				// We'll call the view "Under18.cshtml".
				return View("Under18");
				//return Redirect("/home/index");
			}
			else
			{
				return View(per);
			}
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}