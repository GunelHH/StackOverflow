using System;
using System.ComponentModel.DataAnnotations;
using StackOverflow.Models;

namespace StackOverflow.ViewModels
{
	public class AccountVM
	{
		public AppUser AppUser { get; set; }

		public string Token { get; set; }
		[Required,DataType(DataType.Password)]
		public string Password { get; set; }

        [Required, DataType(DataType.Password),Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
	}
}

