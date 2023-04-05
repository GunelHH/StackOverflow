using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using StackOverflow.Models.Base;

namespace StackOverflow.Models
{
	public class Comment:BaseEntity
	{
		[Required]
		public string Body { get; set; }

		public DateTime PostDate { get; set; } = DateTime.Now;

		public int? QuestionId { get; set; }

		public Question Question { get; set; }

		public int? AnswerId { get; set; }

		public Answer Answer { get; set; }

		public AppUser AppUser { get; set; }

		public string AppUserId { get; set; }
	}
}

