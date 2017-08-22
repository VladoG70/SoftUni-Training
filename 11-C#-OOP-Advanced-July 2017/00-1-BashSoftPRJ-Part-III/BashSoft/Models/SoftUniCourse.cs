﻿using BashSoft.Exceptions;
using System.Collections.Generic;
using BashSoft.Contracts;

namespace BashSoft.Models
    {
    public class SoftUniCourse : ICourse
        {
        private string name;
        private Dictionary<string, IStudent> studentsByName;

        public const int NumberOfTasksOnExam = 5;
        public const int MaxScoreOnExamTask = 100;

        public SoftUniCourse(string name)
            {
            this.Name = name;
            this.studentsByName = new Dictionary<string, IStudent>();
            }

        public string Name
            {
            get { return this.name; }
            private set
                {
                if (string.IsNullOrEmpty(value))
                    {
                    throw new InvalidStringException($"{nameof(this.name)} {ExceptionMessages.NullOrEmptyValue}");
                    }
                this.name = value;
                }
            }

        public IReadOnlyDictionary<string, IStudent> StudentsByName
            {
            get { return this.studentsByName; }
            }

        public void EnrollStudent(IStudent student)
            {
            if (this.studentsByName.ContainsKey(student.UserName))
                {
                throw new DuplicateEntryInStructureException(student.UserName, this.Name);
                }

            this.studentsByName.Add(student.UserName, student);
            }

        public int CompareTo(ICourse other)
            {
            return this.Name.CompareTo(other.Name);
            }

        public override string ToString()
            {
            return this.Name;
            }
        }
    }