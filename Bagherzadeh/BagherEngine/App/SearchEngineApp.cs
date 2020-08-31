using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using BagherEngine.Elastic;
using BagherEngine.Exceptions;
using BagherEngine.Models;
using BagherEngine.QuerySystem;
using BagherEngine.Utils;

namespace BagherEngine.App
{
	public class AppMessages
	{
		public const string NoResultsFoundMessage = "No results found!";
		public const string NoKeyWordsPassedMessage = "No keywords passed!";
		public const string NoDocumentIdPassedMessage = "No documentId passed!";
		public const string NoPathPassedMessage = "No path passed!";
		public const string DirectoryNotFoundMessage = "Directory not found!";
		public const string FileNotFoundMessage = "File not found!";
		public const string HelpMessage = "search <terms> -- view <documentId> -- help -- import <pathToDocuments>";
	}

	public class SearchEngineApp : ConsoleApp
	{
		private const string AppName = "Bagherzadeh";
		private const string Year = "2020";
		private const string Version = "v1.0.1";
		private const string IndexName = "bagher-documents";

		private readonly string ResourcesDirectory;

		private Engine bagherEngine = Engine.GetInstance();

		public override void Intro()
		{
			WriteLine($"Welcome to {AppName}! Copyright(c) Team8 {Year} {Version}");
		}

		public override void Help()
		{
			WriteLine(AppMessages.HelpMessage);
		}

		public SearchEngineApp(string resourcesDirectory) : base()
		{
			ResourcesDirectory = resourcesDirectory;
			prompt = AppName + "> ";
		}

		public override bool HandleCommand()
		{
			switch (command)
			{
				case "search":
					Search(arguments);
					break;
				case "view":
					View(arguments);
					break;
				case "help":
					Help();
					break;
				case "import":
					Import(arguments);
					break;
				case "exit":
					return false;
				default:
					WriteLine($"'{command}' is not recognized as an internal or external command.");
					break;
			}

			return true;
		}

		private string GetSearchResults(string arguments)
		{
			var results = bagherEngine.GetQueryResults(new Query(arguments));
			if (!results.Any())
				return AppMessages.NoResultsFoundMessage;
			return Prettifier<Document>.Prettify(results);
		}

		public void Search(string arguments)
		{
			if (String.IsNullOrEmpty(arguments))
			{
				WriteError(AppMessages.NoKeyWordsPassedMessage);
				return;
			}
			try
			{
				var results = GetSearchResults(arguments);
				WriteLine(results);
			}
			catch (Exception e)
			{
				WriteError(e.Message);
			}
		}

		public void View(string arguments)
		{
			if (String.IsNullOrEmpty(arguments))
			{
				WriteError(AppMessages.NoDocumentIdPassedMessage);
				return;
			}
			try
			{
				WriteLine(FileHandler.GetFileContent(Path.Combine(ResourcesDirectory, arguments)));
			}
			catch (FileNotFoundException)
			{
				WriteError(AppMessages.FileNotFoundMessage);
			}
		}

		public void Import(string arguments)
		{
			if (String.IsNullOrEmpty(arguments))
			{
				WriteError(AppMessages.NoPathPassedMessage);
				return;
			}
			Console.WriteLine($"\nImporting documents from {arguments}...");
			try
			{
				var documents = FileHandler.GetDocumentsFromFolder(arguments);
				var ids = documents.Select(doc => doc.Id).ToList();
				var importer = new Importer<Document>();
				importer.Import(documents, IndexName, ids);
				Console.WriteLine($"[DONE]\n");
			}
			catch (DirectoryNotFoundException)
			{
				WriteError(AppMessages.DirectoryNotFoundMessage);
			}
		}

		private void WriteLine(string output)
		{
			Console.WriteLine("\n" + output + "\n");
		}

		private void WriteError(string error)
		{
			Console.ForegroundColor = ConsoleColor.Red;
			WriteLine(error);
			Console.ResetColor();
		}
	}
}
