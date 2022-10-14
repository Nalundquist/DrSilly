using System;
using System.Collections.Generic;

namespace Factory.Models
{
	public class Machine
	{
		public Machine()
		{
			this.JoinEngMach = new HashSet<EngineerMachine>();
			this.JoinIncident = new HashSet<Incident>();
		}

		public int MachineId {get; set;}
		public string Name {get; set;}
		public string Function {get; set;}
		public string InspectDate {get; set;}
		public bool Functional {get; set;}
		public bool BeingRepaired {get; set;}
		public virtual ICollection<EngineerMachine> JoinEngMach {get; set;}
		public virtual ICollection<Incident> JoinIncident {get; set;}
	}
}