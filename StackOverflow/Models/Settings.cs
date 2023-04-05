using System;
using System.ComponentModel.DataAnnotations;
using StackOverflow.Models.Base;

namespace StackOverflow.Models
{
	public class Settings:BaseEntity
	{
		[Required]
		public string Key { get; set; }

		[Required]
		public string Value { get; set; }
	}
}

