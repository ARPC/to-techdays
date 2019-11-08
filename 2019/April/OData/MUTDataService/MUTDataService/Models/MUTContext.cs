using System.Data.Entity;

namespace MUTDataService.Models
{
	public class MUTContext: DbContext
	{
		public MUTContext() : base("name=MUTContext")
		{
			Database.SetInitializer<MUTContext>(new DropCreateDatabaseAlways<MUTContext>());
		}

		public DbSet<MUTJob> MutJobs { get; set; }
	}
}