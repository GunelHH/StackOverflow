using System;
using System.ComponentModel.DataAnnotations;
using StackOverflow.Models.Base;

namespace StackOverflow.Models
{
	public class Technologist:BaseEntity
	{
		public string MainTitle { get; set; }

		public string BottomTitle { get; set; }

		[Required]
		public string Icon { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Desc { get; set; }
	}
}

