using System;
using System.ComponentModel.DataAnnotations;
using StackOverflow.Models.Base;

namespace StackOverflow.Models
{
	public class MainCard:BaseEntity
	{
		[Required]
		public string Icon { get; set; }

		[Required]
		public string Sentence { get; set; }
	}
}

