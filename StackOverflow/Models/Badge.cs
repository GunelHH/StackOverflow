using System;
using System.Collections.Generic;
using StackOverflow.Models.Base;

namespace StackOverflow.Models
{
	public class Badge:BaseEntity
	{
		public string Icon { get; set; }

		public string Name { get; set; }

		public List<BadgeUser> BadgeUser { get; set; }
	}
}

