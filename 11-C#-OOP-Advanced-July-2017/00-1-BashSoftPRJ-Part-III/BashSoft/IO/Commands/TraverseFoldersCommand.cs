using BashSoft.Attributes;
using BashSoft.Contracts;
using BashSoft.Exceptions;

namespace BashSoft.IO.Commands
    {
    [Allias("ls")]
    public class TraverseFoldersCommand : Command
        {
        [Inject]
        private IDirectoryManager inputOutputManager;

        public TraverseFoldersCommand(string input, string[] data)
            : base(input, data)
            { }

        public override void Execute()
            {
            if (this.Data.Length == 1)
                {
                this.inputOutputManager.TraverseDirectory(0);
                }
            else
            if (this.Data.Length == 2)
                {
                var depth = 0;

                if (int.TryParse(this.Data[1], out depth))
                    {
                    this.inputOutputManager.TraverseDirectory(depth);
                    }
                else
                    {
                    OutputWriter.DisplayException(ExceptionMessages.UnableToParseNumber);
                    }
                }
            else
                {
                throw new InvalidCommandException(this.Input);
                }
            }
        }
    }