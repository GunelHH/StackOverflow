using System;
using StackOverflow.Models.Base;

namespace StackOverflow.Models
{
	public class SocialMediaUser:BaseEntity
	{
		public string AppUserId { get; set; }

		public AppUser AppUser { get; set; }

		public int SocialMediaId { get; set; }

		public SocialMedia socialMedia { get; set; }
	}
}

