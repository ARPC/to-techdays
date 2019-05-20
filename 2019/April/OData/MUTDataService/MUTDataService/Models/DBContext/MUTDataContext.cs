using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MUTDataService.Models.DBContext
{
	public class MUTDataContext : DbContext
	{
		public MUTDataContext(DbContextOptions<MUTDataContext> options) : base (options)
		{
		}

		public DbSet<MUTJob> MutJobs { get; set; }

	}
}
