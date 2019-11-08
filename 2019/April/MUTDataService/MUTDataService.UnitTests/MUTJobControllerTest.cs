using System;
using System.Linq;
using MUTDataService.Controllers;
using MUTDataService.Models;
using NUnit.Framework;

namespace MUTDataService.Tests
{
	[TestFixture]
	public class MUTJobControllerTest
	{
		private MUTJobController controller;

		[SetUp]
		public void Init()
		{
			controller = new MUTJobController();
		}

		[Test]
		public void GetAll()
		{
			var mutjobs = controller.Get();
			Assert.That(mutjobs, Is.Not.Null);
			Assert.That(mutjobs.Count(), Is.GreaterThan(0));
		}

		[Test]
		public void GetAMutJob()
		{
			var mutjob = controller.Get(1);
			Assert.That(mutjob, Is.Not.Null);
		}

		[Test]
		public void AddAMutJob()
		{
			var mutjobs = controller.Get();
			int origJobs = mutjobs.Count();

			controller.Post(new MUTJob(){AccountId = 99, CreateDateTime = DateTime.Now});
			Assert.That(controller.Get().Count(), Is.GreaterThan(origJobs));
			Assert.That(controller.db.MutJobs.Any(p => p.AccountId == 99), Is.True);
		}

		[Test]
		public void DeleteAMutJob()
		{
			var mutjobs = controller.Get();
			int origJobs = mutjobs.Count();

			controller.Delete(1);
			Assert.That(controller.Get().Count(), Is.LessThan(origJobs));
		}

		[Test]
		public void EditAMutJob()
		{
			var mutJob = new MUTJob() {AccountId = 99, CreateDateTime = DateTime.Now};
			controller.Post(mutJob).Wait();

			Assert.That(controller.db.MutJobs.Any(p => p.AccountId == 99), Is.True);
			mutJob = controller.db.MutJobs.Where(b => b.AccountId == 99).FirstOrDefault();

			mutJob.AccountId = 101;
			controller.Put(mutJob.Id, mutJob).Wait();
			Assert.That(controller.db.MutJobs.Any(p => p.AccountId == 99), Is.False);
			Assert.That(controller.db.MutJobs.Any(p => p.AccountId == 101), Is.True);

		}
	}
}
