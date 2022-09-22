using InstrumentsDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace InstrumentsDemo.Controllers
{
	public class InstController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult ShowForm()
		{
			return View();
		}

		public IActionResult Add(Instrument inst)
		{
			bool errorFound = false;
			// Validate 
			if (inst.Year > DateTime.Now.Year)
			{
				ViewBag.YearMessage = "Please enter a year that has already occurred.";
				errorFound = true;
			}
			if (inst.Price <= 0)
			{
				ViewBag.PriceMessage = "Price must be greater than 0.";
				errorFound = true;
			}
			if (errorFound)
			{
				return View("ShowForm");
			}
			else
			{
				return View();
			}
		}
	}
}
