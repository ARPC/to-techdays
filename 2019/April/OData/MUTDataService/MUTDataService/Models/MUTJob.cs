using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MUTDataService.Models
{
	public class MUTJob
	{
		public int Id { get; set; }
		public DateTime CreateDateTime { get; set; }
		public int AccountId { get; set; }
	}
}
