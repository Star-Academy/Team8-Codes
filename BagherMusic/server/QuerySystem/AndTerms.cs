// Standard Library
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

// Internal
using BagherMusic.Models;

namespace BagherMusic.QuerySystem
{
	public class AndTerms : Terms
	{
		private static readonly Regex Pattern = new Regex(@"( *[^\+\-\w]|^)(\w+)", RegexOptions.Compiled | RegexOptions.IgnoreCase);

		public AndTerms(string expression) : base()
		{
			Collect(expression, Pattern, 2);
		}
	}
}
