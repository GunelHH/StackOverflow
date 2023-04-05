
using System;
using System.ComponentModel.DataAnnotations;

namespace StackOverflow.ViewModels
{
	public class AdminLoginVM
	{
        [Required, StringLength(20)]
        public string Username { get; set; }

        [Required, MinLength(8), DataType(DataType.Password)]
        public string Password { get; set; }
	}
}

