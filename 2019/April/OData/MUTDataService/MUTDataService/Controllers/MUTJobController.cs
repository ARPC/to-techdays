using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using MUTDataService.Models;
using MUTDataService.Models.DBContext;

namespace MUTDataService.Controllers
{
	public class MUTJobController : ODataController
	{
		private MUTDataContext _db;
		
		public MUTJobController(MUTDataContext dbContext)
		{
			_db = dbContext;

			if (dbContext.MutJobs.Count() == 0)
			{
				var jobCount = 3;
				var accounts = 3;
				while (accounts > 0)
				{
					var ctr = jobCount;
					while (ctr > 0)
					{
						dbContext.MutJobs.Add(new MUTJob() {Id = dbContext.MutJobs.Count() + 1 , CreateDateTime = DateTime.Now, AccountId = accounts });
						dbContext.SaveChanges();
						ctr--;
					}
					accounts--;
				}
			}
		}

		[EnableQuery]
		public IActionResult Get()
		{
			return Ok(_db.MutJobs.AsQueryable());
		}

		[EnableQuery]
		public IActionResult Get(int key)
		{
			return Ok(_db.MutJobs.FirstOrDefault(m => m.Id == key));
		}

		
		[EnableQuery]
		public IActionResult Post([FromQuery] int accountId, [FromQuery] string description)
		{
			var mutJob = new MUTJob()
			{
				Id = _db.MutJobs.Count() + 1,
				AccountId = accountId,
				CreateDateTime = DateTime.Now
			};
		
			_db.MutJobs.Add(mutJob);
			_db.SaveChanges();

			return Created(mutJob);
		}


	}
}
