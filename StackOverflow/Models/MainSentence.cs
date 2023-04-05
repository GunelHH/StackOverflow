using System;
using System.ComponentModel.DataAnnotations;
using StackOverflow.Models.Base;

namespace StackOverflow.Models
{
	public class MainSentence:BaseEntity
	{
		[Required]
		public string Sentence { get; set; }
		
		[Required]
		public string ChangableWords { get; set; }
	}
}

