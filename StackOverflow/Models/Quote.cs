using System;
using System.ComponentModel.DataAnnotations;
using StackOverflow.Models.Base;

namespace StackOverflow.Models
{
	public class Quote:BaseEntity
	{
		[Required]
		public string Icon { get; set; }

		[Required]
		public string Desc { get; set; }

		[Required]
		public string Job { get; set; }

        [Required]
        public string Company { get; set; }
	}
}

