// Standard
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

// Internal
using BagherMusic.Models;

namespace BagherMusic.Core.QuerySystem
{
	public abstract class Terms
	{
		public List<Token> Tokens { get; set; }

		public Terms()
		{
			Tokens = new List<Token>();
		}

		public bool IsEmpty()
		{
			return !Tokens.Any();
		}

		protected void Collect(string expression, Regex pattern, int regexGroupIndex)
		{
			foreach (var match in pattern.Matches(expression).OfType<Match>())
				Tokens.Add(new Token(match.Groups[regexGroupIndex].Value));
		}
	}
}
