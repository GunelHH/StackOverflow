using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using StackOverflow.Models.Base;

namespace StackOverflow.Models
{
	public class Question:BaseEntity
	{
		public int Views { get; set; } 

		[Required]
		public string Title { get; set; }

		[Required]
		public string Desc { get; set; }

		public DateTime PostDate { get; set; } = DateTime.Now;

		public DateTime EditDate { get; set; }

		public string Code { get; set; }

		public List<QuestionTag> questionTags { get; set; }

        public List<Comment> Comments { get; set; }

		public List<QuestionUserFollow> QuestionUserFollows { get; set; }

		public List<Answer> Answers { get; set; }

		public AppUser AppUser { get; set; }

		public string AppUserId { get; set; }

		[NotMapped]
		public List<string> Tags { get; set; }

	}
}
