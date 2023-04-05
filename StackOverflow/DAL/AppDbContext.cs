using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Emit;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StackOverflow.Models;

namespace StackOverflow.DAL
{
	public class AppDbContext:IdentityDbContext<AppUser>
	{
		public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
		{

		}
		public DbSet<Settings> Settings { get; set; }

		public DbSet<Technologist> Technologists { get; set; }

		public DbSet<Statistic> Statistics { get; set; }

		public DbSet<Product> Products { get; set; }

		public DbSet<MainSentence> MainSentences { get; set; }

		public DbSet<Quote> Quotes { get; set; }

		public DbSet<Award> Awards { get; set; }

		public DbSet<MainCard> MainCards { get; set; }

		public DbSet<Tag> Tags { get; set; }

		public DbSet<Question> Questions { get; set; }

		public DbSet<Company> Companies { get; set; }

		public DbSet<AppUser> AppUsers { get; set; }

		public DbSet<Answer> Answers { get; set; }

		public DbSet<SocialMedia> SocialMedias { get; set; }

		public DbSet<Comment> Comments { get; set; }

		public DbSet<Badge> Badges { get; set; }

		public DbSet<BadgeUser> BadgeUsers { get; set; }

		public DbSet<SocialMediaUser> SocialMediaUsers { get; set; }

		public DbSet<TagCompany> tagCompanies { get; set; }

		public DbSet<QuestionTag> questionTags { get; set; }

		public DbSet<Contact> Contacts { get; set; }




		protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<Settings>()
				.HasIndex(s => s.Key)
				.IsUnique();

			builder.Entity<Tag>()
				.HasIndex(t => t.Name).IsUnique();

            base.OnModelCreating(builder);
        }
    }
}

