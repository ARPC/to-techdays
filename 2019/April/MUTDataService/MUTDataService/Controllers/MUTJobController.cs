using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Microsoft.AspNet.OData;
using MUTDataService.Models;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;

namespace MUTDataService.Controllers
{
	public class MUTJobController : ODataController
	{
		public MUTContext db = new MUTContext();

		public MUTJobController()
		{
			if (db.MutJobs.Count() == 0)
			{
				var jobCount = 3;
				var accounts = 3;
				while (accounts > 0)
				{
					var ctr = jobCount;
					while (ctr > 0)
					{
						db.MutJobs.Add(new MUTJob() { Id = db.MutJobs.Count() + 1, CreateDateTime = DateTime.Now, AccountId = accounts });
						db.SaveChanges();
						ctr--;
					}
					accounts--;
				}
			}
		}

		private bool MUTJobExists(int key)
		{
			return db.MutJobs.Any(p => p.Id == key);
		}
		protected override void Dispose(bool disposing)
		{
			db.Dispose();
			base.Dispose(disposing);
		}

		[EnableQuery]
		public IQueryable<MUTJob> Get()
		{
			return db.MutJobs;
		}

		[EnableQuery]
		public SingleResult<MUTJob> Get([FromODataUri] int key)
		{
			IQueryable<MUTJob> result = db.MutJobs.Where(p => p.Id == key);
			return SingleResult.Create(result);
		}

		public async Task<IHttpActionResult> Post(MUTJob mutJob)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			db.MutJobs.Add(mutJob);
			await db.SaveChangesAsync();
			return Created(mutJob);
		}

		public async Task<IHttpActionResult> Put([FromODataUri] int key, MUTJob mutJob)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			if (key != mutJob.Id)
			{
				return BadRequest();
			}
			db.Entry(mutJob).State = EntityState.Modified;
			try
			{
				await db.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!MUTJobExists(key))
				{
					return NotFound();
				}
				else
				{
					throw;
				}
			}
			return Updated(mutJob);
		}

		public async Task<IHttpActionResult> Delete([FromODataUri] int key)
		{
			var product = await db.MutJobs.FindAsync(key);
			if (product == null)
			{
				return NotFound();
			}
			db.MutJobs.Remove(product);
			await db.SaveChangesAsync();
			return StatusCode(HttpStatusCode.NoContent);
		}

	}
}