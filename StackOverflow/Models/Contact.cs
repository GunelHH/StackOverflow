using System;
using System.ComponentModel.DataAnnotations;
using StackOverflow.Models.Base;

namespace StackOverflow.Models
{
	public class Contact:BaseEntity
	{
		[Required]
		public string reason { get; set; }

		[Required,DataType(DataType.EmailAddress)]
		public string email { get; set; }

		[Required,MinLength(15)]
		public string message { get; set; }

	}
}

