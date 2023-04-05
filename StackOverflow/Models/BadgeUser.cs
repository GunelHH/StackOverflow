using System;
using StackOverflow.Models.Base;

namespace StackOverflow.Models
{
	public class BadgeUser:BaseEntity
	{
		public string AppUserId { get; set; }

		public AppUser AppUser { get; set; }

		public int BagdeId { get; set; }

		public Badge badge { get; set; }
	}
}

