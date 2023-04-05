using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using StackOverflow.Models.Base;

namespace StackOverflow.Models
{
	public class SocialMedia:BaseEntity
	{
		[Required]
		public string Icon { get; set; }

		[Required]
		public string Name { get; set; }

		public List<SocialMediaUser> SocialMediaUsers { get; set; }
	}
}

