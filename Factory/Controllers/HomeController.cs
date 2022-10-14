using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Factory.Models;

namespace Factory.Controllers
{
	public class HomeController : controller
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
			List<Machines> machines = _db.Machines.ToList();
			Dictionary<string, List> model = new Dictionary<string, List>;
			model.Add("engineers", engineers);
			model.Add("machines", machines);
			return View(model);
		} 
	}
}