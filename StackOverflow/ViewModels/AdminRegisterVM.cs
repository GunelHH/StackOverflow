using System;
using System.ComponentModel.DataAnnotations;

namespace StackOverflow.ViewModels
{
	public class AdminRegisterVM
	{

        [Required, StringLength(20)]
        public string Username { get; set; }

        [Required, StringLength(40),DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required, MinLength(8), DataType(DataType.Password)]
        public string Password { get; set; }
	}
}

