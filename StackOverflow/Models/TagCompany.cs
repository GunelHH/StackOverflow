using System;
using StackOverflow.Models.Base;

namespace StackOverflow.Models
{
	public class TagCompany:BaseEntity
	{
		public int TagId { get; set; }

		public Tag Tag { get; set; }

		public int CompanyId { get; set; }

		public Company Company { get; set; }
	}
}

