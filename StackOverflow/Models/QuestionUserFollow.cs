using System;
using StackOverflow.Models.Base;

namespace StackOverflow.Models
{
	public class QuestionUserFollow:BaseEntity
	{
		public string AppUserId { get; set; }

		public AppUser AppUser { get; set; }

		public int QuestionId { get; set; }

		public Question Question { get; set; }
	}
}

