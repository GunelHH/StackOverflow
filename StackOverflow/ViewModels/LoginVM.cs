using System;
using System.ComponentModel.DataAnnotations;

namespace StackOverflow.ViewModels
{
	public class LoginVM
	{
        [Required, DataType(DataType.EmailAddress),StringLength(30)]
        public string Email { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
	}
}

