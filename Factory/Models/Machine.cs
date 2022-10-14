using System;
using System.Collections.Generic;

namespace Factory.Models
{
	public class Machine
	{
		public Machine()
		{
			this.JoinEngMach = new HashSet<EngineerMachine>();			
		}

		public int MachineId {get; set;}
		public string Name {get; set;}
		public string Function {get; set;}
		public string InspectDate {get; set;}
		public virtual ICollection<EngineerMachine> JoinEngMach {get; set;}
	}
}