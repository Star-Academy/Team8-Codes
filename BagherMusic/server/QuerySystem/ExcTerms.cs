// Standard Library
using System.Collections.Generic;
using System.Text.RegularExpressions;

// Internal
using BagherMusic.Models;

namespace BagherMusic.QuerySystem
{
	public class ExcTerms : Terms
	{
		private static readonly Regex Pattern = new Regex(@"\-(\w+)", RegexOptions.Compiled | RegexOptions.IgnoreCase);

		public ExcTerms(string expression) : base()
		{
			Collect(expression, Pattern, 1);
		}
	}
}
