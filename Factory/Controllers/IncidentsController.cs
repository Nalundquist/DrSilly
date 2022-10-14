using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Factory.Models;

namespace Factory.Controllers
{
	public class IncidentsController : Controller
	{
		private readonly FactoryContext _db;
		public IncidentsController(FactoryContext db)
		{
			_db = db;
		}

		public ActionResult Details(int id)
		{
			Incident thisIncident = _db.Incidents.FirstOrDefault(incident => incident.IncidentId == id);
			ViewBag.EngineerName = _db.Engineers.FirstOrDefault(engineer => engineer.EngineerId == thisIncident.EngineerId).Name;
			ViewBag.MachineName = _db.Machines.FirstOrDefault(machine => machine.MachineId == thisIncident.MachineId).Name;
			return View(thisIncident);
		}

		public ActionResult Edit(int id)
		{
			Incident thisIncident = _db.Incidents.FirstOrDefault(incident => incident.IncidentId == id);
			ViewBag.EngineerId = new SelectList(_db.Engineers, "EngineerId", "Name");
			return View(thisIncident);
		}

		[HttpPost]
		public ActionResult Edit(Incident incident, int EngineerId)
		{
			_db.Entry(incident).State = EntityState.Modified;
			_db.SaveChanges();
			if (EngineerId != 0)
			{
				incident.EngineerId = EngineerId;
				_db.Entry(incident).State = EntityState.Modified;
				_db.SaveChanges();
			}
			return RedirectToAction("Details", new {id = incident.IncidentId});
		}
	}
}