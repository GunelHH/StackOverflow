using System;
using StackOverflow.Models;
using System.Collections.Generic;
namespace StackOverflow.ViewModels
{
	public class QuestionVM
	{
		public List<Question> questions { get; set; }

		public List<UserTag> userTags { get; set; }
	}
}

