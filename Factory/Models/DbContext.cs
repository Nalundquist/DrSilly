using System.Collections.Generic;

namespace Factory.Models
{
	public class FactoryContext : Context
	{
		public DbSet<Machine> Machines {get; set;}
		public DbSet<Engineer> Engineers {get; set;}
		public DbSet<MachineEngineer> MachineEngineer {get; set;} 

		public FactoryContext (DbContext options) : base(options) {}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseLazyLoadingProxies();
		}
	}
}