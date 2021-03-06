﻿using BashSoft.Attributes;
using BashSoft.Contracts;
using BashSoft.Exceptions;

namespace BashSoft.IO.Commands
    {
    [Allias("show")]
    public class ShowCourseCommand : Command
        {
        [Inject]
        private IDatabase repository;

        public ShowCourseCommand(string input, string[] data)
            : base(input, data)
            { }

        public override void Execute()
            {
            if (this.Data.Length == 2)
                {
                var courseName = this.Data[1];
                this.repository.GetAllStudentsFromCourse(courseName);
                }
            else if (this.Data.Length == 3)
                {
                var courseName = this.Data[1];
                var userName = this.Data[2];
                this.repository.GetStudentFromCourse(courseName, userName);
                }
            else
                {
                throw new InvalidCommandException(this.Input);
                }
            }
        }
    }