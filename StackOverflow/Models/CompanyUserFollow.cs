using System;
using StackOverflow.Models.Base;

namespace StackOverflow.Models
{
	public class CompanyUserFollow:BaseEntity
	{
		public int CompanyId { get; set; }

		public Company Company { get; set; }

		public AppUser AppUser { get; set; }

		public string AppUserId { get; set; }

	}
}

