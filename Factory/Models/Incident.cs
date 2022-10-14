using System;
using System.Collections.Generic;

namespace Factory.Models
{
	public class Incident
	{
		public int IncidentId {get; set;}
		public int MachineId {get; set;}
		public int EngineerId {get; set;}
		public string MalfunctionDate {get; set;}
		public string RepairDate {get; set;}
		public bool Repaired {get; set;}
		public virtual Engineer Engineer {get; set;}
		public virtual Machine Machine {get; set;}
	}
}