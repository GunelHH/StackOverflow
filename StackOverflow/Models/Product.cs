using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;
using StackOverflow.Models.Base;

namespace StackOverflow.Models
{
	public class Product:BaseEntity
	{
		public string Logo { get; set; }

		public string Image { get; set; }

		[Required]
		public string Desc { get; set; }

		[Required]
		public string Button { get; set; }


		[NotMapped]
		public IFormFile PhotoImage { get; set; }

		[NotMapped]
		public IFormFile LogoPhoto { get; set; }
	}
}

