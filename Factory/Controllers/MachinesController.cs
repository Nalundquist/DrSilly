using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Factory.Models;

namespace Factory.Controllers
{
	public class MachinesController : Controller
	{
		private readonly FactoryContext _db;
		public MachinesController(FactoryContext db)
		{
			_db = db;
		}

		public ActionResult Index()
		{
			List<Machine> machines = _db.Machines.ToList();
			return View(machines);
		}

		public ActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Create(Machine machine)
		{
			_db.Machines.Add(machine);
			_db.SaveChanges();
			return RedirectToAction("Details", new {id = machine.MachineId});
		}

		public ActionResult Details(int id)
		{
			Machine thisMachine = _db.Machines
				.Include(machine => machine.JoinEngMach)
				.ThenInclude(join => join.Machine)
				.FirstOrDefault(machine => machine.MachineId == id);
			return View(thisMachine);
		}

		public ActionResult Edit(int id)
		{
			Machine thisMachine = _db.Machines.FirstOrDefault(machine => machine.MachineId == id);
			return View(thisMachine);
		}

		[HttpPost]
		public ActionResult Edit(Machine machine)
		{
			_db.Entry(machine).State = EntityState.Modified;
			_db.SaveChanges();
			return RedirectToAction("Details", new {id = machine.MachineId});
		}

		[HttpPost]
		public ActionResult Delete(int id)
		{
			Machine thisMachine = _db.Machines.FirstOrDefault(machine => machine.MachineId == id);
			_db.Machines.Remove(thisMachine);
			_db.SaveChanges();
			return RedirectToAction("Index");
		}

		public ActionResult AddEngineer(int id)
		{
			Machine thisMachine = _db.Machines.FirstOrDefault(machine => machine.MachineId == id);
			ViewBag.EngineerId = new SelectList(_db.Engineers, "EngineerId", "Name");
			return View(thisMachine);
		}

		[HttpPost]
		public ActionResult AddEngineer(Machine machine, int EngineerId)
		{
			if (EngineerId != 0)
			{
				_db.EngineerMachine.Add(new EngineerMachine() {MachineId = machine.MachineId, EngineerId = EngineerId});
				_db.SaveChanges();
			}
			return RedirectToAction("Details", new {id = machine.MachineId});
		}

		[HttpPost]
		public ActionResult DeleteEngineer(int joinId)
		{
			EngineerMachine thisJoin = _db.EngineerMachine.FirstOrDefault(join => join.EngineerMachineId == joinId);
			_db.EngineerMachine.Remove(thisJoin);
			_db.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}