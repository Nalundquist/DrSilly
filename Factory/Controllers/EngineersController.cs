using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Factory.Models;

namespace Factory.Controllers
{
	public class EngineersController : Controller
	{
		private readonly FactoryContext _db;
		public EngineersController(FactoryContext db)
		{
			_db = db;
		}

		public ActionResult Index()
		{
			List<Engineer> engineers = _db.Engineers.ToList();
			return View(engineers);
		}

		public ActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Create(Engineer engineer)
		{
			_db.Engineers.Add(engineer);
			_db.SaveChanges();
			return RedirectToAction("Details", new {id = engineer.EngineerId});
		}

		public ActionResult Details(int id)
		{
			Engineer thisEngineer = _db.Engineers
				.Include(engineer => engineer.JoinEngMach)
				.ThenInclude(join => join.Engineer)
				.FirstOrDefault(engineer => engineer.EngineerId == id);
			return View(thisEngineer);
		}

		public ActionResult Edit(int id)
		{
			Engineer thisEngineer = _db.Engineers.FirstOrDefault(engineer => engineer.EngineerId == id);
			return View(thisEngineer);
		}

		[HttpPost]
		public ActionResult Edit(Engineer engineer)
		{
			_db.Entry(engineer).State = EntityState.Modified;
			_db.SaveChanges();
			return RedirectToAction("Details", new {id = engineer.EngineerId});
		}

		[HttpPost]
		public ActionResult Delete(int id)
		{
			Engineer thisEngineer = _db.Engineers.FirstOrDefault(engineer => engineer.EngineerId == id);
			_db.Engineers.Remove(thisEngineer);
			_db.SaveChanges();
			return RedirectToAction("Index");
		}

		public ActionResult AddMachine(int id)
		{
			Engineer thisEngineer = _db.Engineers.FirstOrDefault(engineer => engineer.EngineerId == id);
			ViewBag.MachineId = new SelectList(_db.Machines, "MachineId", "Name");
			return View(thisEngineer);
		}

		[HttpPost]
		public ActionResult AddMachine(Engineer engineer, int MachineId)
		{
			if (MachineId != 0)
			{
				_db.EngineerMachine.Add(new EngineerMachine() {EngineerId = engineer.EngineerId, MachineId = MachineId});
				_db.SaveChanges();
			}
			return RedirectToAction("Details", new {id = engineer.EngineerId});
		}

		[HttpPost]
		public ActionResult DeleteMachine(int joinId)
		{
			EngineerMachine thisJoin = _db.EngineerMachine.FirstOrDefault(join => join.EngineerMachineId == joinId);
			_db.EngineerMachine.Remove(thisJoin);
			_db.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}