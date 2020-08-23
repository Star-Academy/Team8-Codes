using System;
using System.Collections.Generic;
using System.Linq;

using BagherEngine.Elastic;
using BagherEngine.Models;
using BagherEngine.QuerySystem;
using BagherEngine.Utils;

namespace BagherEngine.App
{
    public class SearchEngineApp : ConsoleApp
    {
        private const string AppName = "Bagherzadeh";
        private const string Year = "2020";
        private const string Version = "v1.0.1";

        private readonly string ResourcesDirectory;

        public override void Intro()
        {
            WriteLine($"Welcome to {AppName}! Copyright(c) Team8 {Year} {Version}");
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
            var results = Engine.GetQueryResults(new Query(arguments));
            if (!results.Any())
                return "No results found!";
            return Prettifier<Document>.Prettify(results);
        }

        public void Search(string arguments)
        {
            if (arguments == "")
            {
                WriteLine("No keywords passed!");
                return;
            }
            try
            {
                var results = GetSearchResults(arguments);
                WriteLine(results);
            }
            catch (ArgumentException e)
            {
                WriteLine(e.Message);
            }
        }

        public void View(string arguments)
        {
            if (arguments == "")
            {
                WriteLine("No documentId passed!");
                return;
            }
            WriteLine(FileHandler.GetFileContent(ResourcesDirectory + "/" + arguments));
        }

        public override void Help()
        {
            WriteLine("search <terms> -- view <documentId> -- help");
        }

        private void WriteLine(string output)
        {
            Console.WriteLine("\n" + output + "\n");
        }
    }
}
