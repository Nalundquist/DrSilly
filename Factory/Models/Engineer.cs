using System.Collections.Generic;
using System;

namespace Factory.Models
{
	public class Engineer
	{
		public Engineer()
		{
			this.JoinEngMach = new Hashset<EngineerMachine>();
		}

		public int EngineerId {get; set;}
		public string Name {get; set;}
		public string Expertise {get; set;}
		public bool Busy {get; set;}
		public DateTime LicRenew {get; set;}
		public virtual ICollection<EngineerMachine> JoinEngMach();
	}
}