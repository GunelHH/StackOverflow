using System;
using Microsoft.AspNetCore.Mvc;

namespace StackOverflow.Controllers
{
	public class Error:Controller
	{
		public IActionResult notFound()
		{
			return View();
		}
		
	}
}

