using System;

namespace MUTDataService.Models
{
	public class MUTJob
	{
		public int Id { get; set; }
		public DateTime CreateDateTime { get; set; }
		public int AccountId { get; set; }
	}
}