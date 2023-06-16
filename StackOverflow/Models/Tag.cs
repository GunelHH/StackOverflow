using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;
using StackOverflow.Models.Base;

namespace StackOverflow.Models
{
	public class Tag:BaseEntity
	{
		[Required]
		public string Name { get; set; }

		public string Image { get; set; }

		[Required]
		public string About { get; set; }

		public List<TagCompany> TagCompanies { get; set; }

		public List<QuestionTag> questionTags { get; set; }

		public List<UserTag> UserTags { get; set; }

		[NotMapped]
		public IFormFile Photo { get; set; }

	}
}

