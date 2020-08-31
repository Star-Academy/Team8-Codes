using System;

namespace BagherEngine.App
{
	public abstract class ConsoleApp
	{
		private const char Delimiter = ' ';

		protected string prompt;
		protected string command;
		protected string arguments;
		protected int firstSpaceIndex;

		public abstract void Intro();

		public abstract void Help();

		public abstract bool HandleCommand();

		public ConsoleApp()
		{
			Intro();
			Help();
		}

		private void DecomposeInput(string input)
		{
			firstSpaceIndex = input.IndexOf(Delimiter);
			if (firstSpaceIndex < 0)
			{
				firstSpaceIndex = input.Length;
				command = input;
				arguments = String.Empty;
			}
			else
			{
				command = input.Substring(0, firstSpaceIndex).Trim();
				arguments = input.Substring(firstSpaceIndex + 1).Trim();
			}
		}

		public void Run()
		{
			string input;
			do
			{
				Console.Write(prompt);
				input = Console.ReadLine().Trim();
				DecomposeInput(input);
			} while (HandleCommand());
		}
	}
}
