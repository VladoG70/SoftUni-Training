using BashSoft.Attributes;
using BashSoft.Contracts;
using BashSoft.Exceptions;

namespace BashSoft.IO.Commands
    {
    [Allias("help")]
    public class GetHelpCommand : Command
        {
        public GetHelpCommand(string input, string[] data)
            : base(input, data)
            { }

        public override void Execute()
            {
            if (this.Data.Length != 1)
                {
                throw new InvalidCommandException(this.Input);
                }

            this.DisplayHelp();
            }

        private void DisplayHelp()
            {
            OutputWriter.WriteMessageOnNewLine($"{new string('_', 100)}");
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "open file - open: [path]file "));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "make directory - mkdir: path "));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "traverse directory - ls: depth "));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "comparing files - cmp: path1 path2"));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "change directory - cdRel: relative path"));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "change directory - cdAbs: absolute path"));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "read students data base - readDb: [path]file"));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "filter {courseName} excelent/average/poor  take 2/5/all students - filterExcelent (the output is written on the console)"));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "order increasing students - order {courseName} ascending/descending take 20/10/all (the output is written on the console)"));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "show wanted data (course/student) from Database (readDb first!) - show: [path]course[, username]"));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "download file - download: path of file (saved in current directory)"));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "download file asinchronously - downloadAsynch: path of file (save in the current directory)"));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "display data entities - display students/courses ascending/descending"));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "get help – help"));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "QUIT from BashSoft – quit"));

            OutputWriter.WriteMessageOnNewLine($"{new string('_', 100)}");
            OutputWriter.WriteEmptyLine();
            }
        }
    }