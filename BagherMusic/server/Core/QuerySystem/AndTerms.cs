// Standard
using System.Text.RegularExpressions;

namespace BagherMusic.Core.QuerySystem
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
