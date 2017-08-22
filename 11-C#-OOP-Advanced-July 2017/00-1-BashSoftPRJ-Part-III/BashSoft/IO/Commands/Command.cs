using BashSoft.Exceptions;
using System;
using BashSoft.Attributes;
using BashSoft.Contracts;

namespace BashSoft.IO.Commands
    {
    public abstract class Command : IExecutable
        {
        private string input;
        private string[] data;

        //[Inject]
        //private IDirectoryManager inputOutputManager;

        //[Inject]
        //private IContentComparer judge;

        //[Inject]
        //private IDatabase repository;

        public Command(string input, string[] data)
            {
            this.Input = input;
            this.Data = data;
            }

        public string Input
            {
            get { return this.input; }
            private set
                {
                if (String.IsNullOrEmpty(value))
                    {
                    throw new InvalidStringException();
                    }
                this.input = value;
                }
            }

        public string[] Data
            {
            get { return this.data; }
            private set
                {
                if (value == null || value.Length == 0)
                    {
                    throw new NullReferenceException();
                    }
                this.data = value;
                }
            }

        public abstract void Execute();
        }
    }