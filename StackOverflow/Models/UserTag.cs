using System;
using StackOverflow.Models.Base;

namespace StackOverflow.Models
{
	public class UserTag:BaseEntity
	{
        public int TagId { get; set; }

        public Tag Tag { get; set; }

        public string AppUserId { get; set; }

        public AppUser user { get; set; }

    }
}

