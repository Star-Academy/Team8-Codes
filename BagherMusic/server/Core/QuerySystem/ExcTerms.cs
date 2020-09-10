// Standard
using System.Text.RegularExpressions;

namespace BagherMusic.Core.QuerySystem
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
