using System;
using BashSoft.Contracts;

namespace BashSoft
    {
    public class InputReader : IReader
        {
        private const string endCommand = "quit";
        private IInterpreter interpreter;

        public InputReader(IInterpreter interpreter)
            {
            this.interpreter = interpreter;
            }

        public void StartReadingCommands()
            {
            // Input Commands
            OutputWriter.WriteMessage($"{SessionData.currentPath}> ");
            string input = Console.ReadLine();
            input = input.Trim();

            while (input.ToLower() != endCommand)
                {
                this.interpreter.InterpredCommand(input);
                OutputWriter.WriteMessage($"{SessionData.currentPath}> ");
                input = Console.ReadLine();
                input = input.Trim();
                }
            }
        } // END of InputReader
    }