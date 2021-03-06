﻿using BashSoft.Exceptions;
using System.Diagnostics;
using BashSoft.Attributes;
using BashSoft.Contracts;

namespace BashSoft.IO.Commands
    {
    [Allias("open")]
    public class OpenFileCommand : Command
        {
        public OpenFileCommand(string input, string[] data)
            : base(input, data)
            { }

        public override void Execute()
            {
            if (this.Data.Length != 2)
                {
                throw new InvalidCommandException(this.Input);
                }

            string fileName = this.Data[1];
            Process.Start(SessionData.currentPath + "\\" + fileName);
            }
        }
    }