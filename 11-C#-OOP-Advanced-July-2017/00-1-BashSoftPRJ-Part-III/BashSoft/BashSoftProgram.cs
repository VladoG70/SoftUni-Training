using BashSoft.Contracts;

namespace BashSoft
    {
    internal class BashSoftProgram
        {

        private static void Main(string[] args)
            {
            IContentComparer tester = new Tester();
            IDirectoryManager ioManager = new IOManager();
            IDatabase repo = new StudentsRepository(new RepositorySorter(), new RepositoryFilter());

            IInterpreter currentInterpreter = new CommandInterpreter(tester, repo, ioManager);
            IReader reader = new InputReader(currentInterpreter);

            // COMMAND Interpreter - READY
            reader.StartReadingCommands();
            }
        }
    }