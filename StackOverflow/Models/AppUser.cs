using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace StackOverflow.Models
{
	public class AppUser:IdentityUser
	{
		public string ProfilePhoto { get; set; }

		public DateTime LoginDate { get; set; } = DateTime.Now;

		public string About { get; set; }

		public string Location { get; set; }

		public int Reputation { get; set; }

		public int BadgeCount { get; set; }

		public string SocialMediaLink { get; set; }

		public List<BadgeUser> BadgeUsers { get; set; }

		public List<SocialMediaUser> socialMediaUsers { get; set; }

		public List<CompanyUserFollow> CompanyUserFollows { get; set; }

		public List<QuestionUserFollow> QuestionUserFollows { get; set; }

		public List<Question> Questions { get; set; }

		public List<Comment> Comments { get; set; }

		public List<Answer> Answers { get; set; }

		public List<UserTag> UserTags { get; set; }


		[NotMapped]
		public IFormFile ProfileImg { get; set; }
	}
}

