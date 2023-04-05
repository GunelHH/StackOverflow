using System;
using System.Collections.Generic;
using StackOverflow.Models;

namespace StackOverflow.ViewModels
{
	public class HomeVM
	{
		public List<MainCard> MainCards { get; set; }

		public List<MainSentence> mainSentences { get; set; }

		public List<Quote> quotes { get; set; }

		public List<Settings> settings { get; set; }

		public List<Statistic> statistics { get; set; }

		public List<Technologist> technologists { get; set; }
	}
}

