using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;
using StackOverflow.Models.Base;

namespace StackOverflow.Models
{
	public class Company:BaseEntity
	{
		public string Image { get; set; }

		[Required]
		public string Name{ get; set; }

		[Required]
		public string Title { get; set; }

        [Required]
        public string About { get; set; }

        public string AboutImage { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public DateTime OriginHistory { get; set; }

        public bool Status { get; set; }

        [Required]
        public string WebSiteLink { get; set; }

        [Required]
        public string WebSiteLinkName { get; set; }

        [Required]
		public string Industry { get; set; }

        [Required]
		public string Benefits { get; set; }

        [Required]
        public string VideoLink { get; set; }

        public string VideoImage { get; set; }

        public string PostImage { get; set; }
       
        public string PostDesc { get; set; }

        public DateTime PostUpdateTime { get; set; } = DateTime.UtcNow.AddHours(4);


        public List<TagCompany> tagCompanies { get; set; }

        public List<CompanyUserFollow> CompanyUserFollows { get; set; }


        [NotMapped]
        public IFormFile CompanyPhoto { get; set; }

        [NotMapped]
        public IFormFile AboutPhoto { get; set; }

        [NotMapped]
        public IFormFile VideoPhoto{ get; set; }

        [NotMapped]
        public IFormFile PostPhoto { get; set; }

    }
}

