using BashSoft.Attributes;
using BashSoft.Contracts;
using BashSoft.Exceptions;

namespace BashSoft.IO.Commands
    {
    [Allias("mkdir")]
    public class MakeDirectoryCommand : Command
        {
        [Inject]
        private IDirectoryManager inputOutputManager;

        public MakeDirectoryCommand(string input, string[] data)
            : base(input, data)
            { }

        public override void Execute()
            {
            if (this.Data.Length != 1)
                {
                throw new InvalidCommandException(Input);
                }

            string folderName = this.Data[1];
            this.inputOutputManager.CreateDirectoryInCurrentFolder(folderName);
            }
        }
    }