using System;
using System.Collections.Generic;
using System.Linq;
using GoogleSharp.Src.Core.Engine;
using GoogleSharp.Src.Core.Query;
using GoogleSharp.Src.Core.Structures;
using GoogleSharp.Src.Utils;

namespace SearchEngine {
    public class SearchEngineApp : ConsoleApp {
        private const string AppName = "google";
        private const string Year = "2020";
        private const string Version = "v1.0.1";

        private readonly string ResourcesDirectory;
        private GoogleInvertedIndex index;

        public override void Intro() {
            WriteLine("Welcome to " + AppName + "! Copyright(c) Team8 " + Year + " " + Version);
        }

        public SearchEngineApp(string resourcesDirectory) : base() {
            ResourcesDirectory = resourcesDirectory;
            var fileHandler = new FileHandler();
            index = new GoogleInvertedIndex(fileHandler.GetDocumentsFromFolder(ResourcesDirectory), fileHandler);
            prompt = AppName + "> ";
        }

        public override bool HandleCommand() {
            if (command.Equals("search")) Search(arguments);
            else if (command.Equals("view")) View(arguments);
            else if (command.Equals("help")) Help();
            else if (command.Equals("exit")) return false;
            else WriteLine($"'{command}' is not recognized as an internal or external command.");
            return true;
        }

        private string GetSearchResults(string arguments) {
            HashSet<Document> results = QueryEngine.GetQueryResults(new QueryBuilder(arguments), index);
            if (!results.Any())
                return "No results found!";
            return Prettifier<Document>.Prettify(results);
        }

        public void Search(string arguments) {
            if (arguments == "") {
                WriteLine("No keywords passed!");
                return;
            }
            try {
                WriteLine(GetSearchResults(arguments));
            } catch (ArgumentException e) {
                WriteLine(e.Message);
            }
        }

        public void View(string arguments) {
            if (arguments == "") {
                WriteLine("No documentId passed!");
                return;
            }
            WriteLine(new FileHandler().GetFileContent(ResourcesDirectory + "/" + arguments));
        }

        public override void Help() {
            WriteLine("search <terms> -- view <documentId> -- help");
        }

        private void WriteLine(string output) {
            Console.WriteLine("\n" + output + "\n");
        }
    }
}
