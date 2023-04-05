using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;
using StackOverflow.Models.Base;

namespace StackOverflow.Models
{
	public class Award : BaseEntity
	{
		public string Image { get; set; }

		[Required]
		public string Name { get; set; }

		[Required]
		public string Desc { get; set; }

		[Required]
		public DateTime DateOfSubmision { get; set; }


		[NotMapped]
		public IFormFile Photo { get; set; }
	}
}

