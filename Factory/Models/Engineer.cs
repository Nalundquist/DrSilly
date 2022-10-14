using System.Collections.Generic;
using System;

namespace Factory.Models
{
	public class Engineer
	{
		public Engineer()
		{
			this.JoinEngMach = new HashSet<EngineerMachine>();
			this.JoinIncident = new HashSet<Incident>();
		}

		public int EngineerId {get; set;}
		public string Name {get; set;}
		public string Expertise {get; set;}
		public bool Busy {get; set;}
		public string LicRenew {get; set;}
		public virtual ICollection<EngineerMachine> JoinEngMach {get; set;}
		public virtual ICollection<Incident> JoinIncident {get;}
	}
}