using BashSoft.Attributes;
using BashSoft.Contracts;
using BashSoft.Exceptions;

namespace BashSoft.IO.Commands
    {
    [Allias("order")]
    public class PrintOrderedStudentsCommand : Command
        {
        [Inject]
        private IDatabase repository;

        public PrintOrderedStudentsCommand(string input, string[] data)
            : base(input, data)
            { }

        public override void Execute()
            {
            if (this.Data.Length != 5)
                {
                throw new InvalidCommandException(this.Input);
                }

            var courseName = this.Data[1];
            var filter = this.Data[2].ToLower();
            var takeCommand = this.Data[3].ToLower();
            var takeQuantity = this.Data[4].ToLower();

            TryParseParametersForOrderAndTake(takeCommand, takeQuantity, courseName, filter);
            }

        private void TryParseParametersForOrderAndTake(string takeCommand, string takeQuantity, string courseName, string filter)
            {
            if (takeCommand == "take")
                {
                if (takeQuantity == "all")
                    {
                    this.repository.OrderAndTake(courseName, filter);
                    }
                else
                    {
                    var studentsToTake = 0;

                    if (int.TryParse(takeQuantity, out studentsToTake))
                        {
                        this.repository.OrderAndTake(courseName, filter, studentsToTake);
                        }
                    else
                        {
                        OutputWriter.DisplayException(ExceptionMessages.InvalidTakeQuantityParameter);
                        }
                    }
                }
            else
                {
                OutputWriter.DisplayException(ExceptionMessages.InvalidTakeQuantityParameter);
                }
            }
        }
    }