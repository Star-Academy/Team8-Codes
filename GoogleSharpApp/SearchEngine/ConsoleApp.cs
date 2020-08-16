using System;

namespace SearchEngine {
    public abstract class ConsoleApp {

        protected string prompt;
        protected string command;
        protected string arguments;
        protected int firstSpaceIndex;

        public abstract void Intro();

        public abstract void Help();

        public abstract bool HandleCommand();

        public ConsoleApp() {
            Intro();
            Help();
        }

        private void DecomposeInput(string input) {
            firstSpaceIndex = input.IndexOf(' ');
            if (firstSpaceIndex < 0) {
                firstSpaceIndex = input.Length;
                command = input;
                arguments = "";
            } else {
                command = input.Substring(0, firstSpaceIndex).Trim();
                arguments = input.Substring(firstSpaceIndex + 1).Trim();
            }
        }

        public void Run() {
            string input;
            do {
                Console.Write(prompt);
                input = Console.ReadLine().Trim();
                DecomposeInput(input);
            } while (HandleCommand());
        }
    }
}
