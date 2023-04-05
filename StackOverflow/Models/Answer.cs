using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using StackOverflow.Models.Base;

namespace StackOverflow.Models
{
	public class Answer:BaseEntity
	{
		[Required]
		public string Desc { get; set; }

		public string Code { get; set; }

		public DateTime AnswerDate { get; set; } = DateTime.Now;

		public DateTime EditDate { get; set; }

		public bool IsTheBest { get; set; } = false;

		public Question Question { get; set; }

		public int QuestionId { get; set; }

		public List<Comment> Comments { get; set; }

		public AppUser AppUser { get; set; }

		public string AppUserId { get; set; }
	}
}

