using System;
using System.ComponentModel.DataAnnotations;
using StackOverflow.Models.Base;

namespace StackOverflow.Models
{
	public class Statistic:BaseEntity
	{
		[Required]
		public string Title { get; set; }

		[Required]
		public string Desc { get; set; }

	}
}

