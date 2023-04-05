using System;
using StackOverflow.Models.Base;

namespace StackOverflow.Models
{
	public class QuestionTag:BaseEntity
	{
		public int TagId { get; set; }

		public Tag Tag { get; set; }

		public int QuestionId { get; set; }

		public Question Question { get; set; }

	}
}

