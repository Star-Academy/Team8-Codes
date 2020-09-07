// Standard
using System;
using System.Text.RegularExpressions;

namespace BagherMusic.Core.QuerySystem
{
	public class OrTerms : Terms
	{
		private static readonly Regex Pattern = new Regex(@"\+(\w+)", RegexOptions.Compiled | RegexOptions.IgnoreCase);

		public OrTerms(String expression) : base()
		{
			Collect(expression, Pattern, 1);
		}
	}
}
