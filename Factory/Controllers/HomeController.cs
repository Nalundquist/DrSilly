using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Factory.Models;

namespace Factory.Controllers
{
	public class HomeController : Controller
	{
		private readonly FactoryContext _db;
		public HomeController(FactoryContext db)
		{
			_db = db;
		}

		public ActionResult Index()
		{
			return View();
		}

		public ActionResult List()
		{
			List<Engineer> engineers = _db.Engineers.ToList();
			ViewBag.MachineList = _db.Machines.ToList();
			return View(engineers);
		} 
	}
}