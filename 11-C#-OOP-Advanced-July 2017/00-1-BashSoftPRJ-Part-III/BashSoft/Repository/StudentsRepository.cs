using BashSoft.Exceptions;
using BashSoft.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using BashSoft.Contracts;
using BashSoft.DataStructures;

namespace BashSoft
    {
    public class StudentsRepository : IDatabase
        {
        private bool isDataInitialized = false;
        private Dictionary<string, Dictionary<string, List<int>>> studentsByCourse;
        private RepositoryFilter filter;
        private RepositorySorter sorter;

        // NEW - File 01 - Problem 12
        private Dictionary<string, ICourse> courses;

        private Dictionary<string, IStudent> students;

        public StudentsRepository(RepositorySorter sorter, RepositoryFilter filter)
            {
            this.filter = filter;
            this.sorter = sorter;
            this.studentsByCourse = new Dictionary<string, Dictionary<string, List<int>>>();
            }

        public void LoadData(string fileName)
            {
            if (!this.isDataInitialized)
                {
                OutputWriter.WriteMessageOnNewLine("Reading data...");
                this.students = new Dictionary<string, IStudent>();
                this.courses = new Dictionary<string, ICourse>();
                ReadData(fileName);
                }
            else
                {
                throw new InvalidOperationException(ExceptionMessages.DataAlreadyInitialisedException);
                }
            }

        public void UnloadData()
            {
            if (!this.isDataInitialized)
                {
                throw new ArgumentException(ExceptionMessages.DataNotInitializedExceptionMessage);
                }
            this.students = null;
            this.courses = null;
            this.isDataInitialized = false;
            }

        private void ReadData(string fileName)
            {
            var path = SessionData.currentPath + "\\" + fileName;

            if (File.Exists(path))
                {
                //var pattern = @"([A-Z][a-zA-Z#+]*_[A-Z][a-z]{2}_\d{4})\s+([A-Z][a-z]{0,3}\d{2}_\d{2,4})\s+(\d+)";
                var pattern = @"([A-Z][a-zA-Z#\++]*_[A-Z][a-z]{2}_\d{4})\s+([A-Za-z]+\d{2}_\d{2,4})\s([\s0-9]+)";
                var rgx = new Regex(pattern);
                var allInputLines = File.ReadAllLines(path);

                for (int line = 0; line < allInputLines.Length; line++)
                    {
                    if (!string.IsNullOrEmpty(allInputLines[line]) && rgx.IsMatch(allInputLines[line]))
                        {
                        var currentMatch = rgx.Match(allInputLines[line]);
                        var tokens = allInputLines[line].Split(' ');
                        var courseName = currentMatch.Groups[1].Value;
                        var studentName = currentMatch.Groups[2].Value;
                        var scoresStr = currentMatch.Groups[3].Value;

                        // F01-P12 p.9
                        try
                            {
                            int[] scores = scoresStr.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse)
                                .ToArray();

                            if (scores.Any(x => x > 100 || x < 0))
                                {
                                OutputWriter.DisplayException(ExceptionMessages.InvalidScore);
                                }

                            if (scores.Length > SoftUniCourse.NumberOfTasksOnExam)
                                {
                                OutputWriter.DisplayException(ExceptionMessages.InvalidNumberOfScores);
                                continue;
                                }

                            if (!this.students.ContainsKey(studentName))
                                {
                                this.students.Add(studentName, new SoftUniStudent(studentName));
                                }

                            if (!this.courses.ContainsKey(courseName))
                                {
                                this.courses.Add(courseName, new SoftUniCourse(courseName));
                                }

                            ICourse course = this.courses[courseName];
                            IStudent student = this.students[studentName];

                            student.EnrollInCourse(course);
                            student.SetMarksInCourse(courseName, scores);

                            course.EnrollStudent(student);
                            }
                        catch (FormatException fex)
                            {
                            OutputWriter.DisplayException(fex.Message + $"at line : {line}");
                            }
                        }
                    }

                isDataInitialized = true;
                OutputWriter.WriteMessageOnNewLine("Data read!");
                }
            else
                {
                throw new InvalidPathException();
                }
            }

        private bool IsQueryForCoursePossible(string courseName)
            {
            if (isDataInitialized)
                {
                if (this.courses.ContainsKey(courseName))
                    {
                    return true;
                    }
                else
                    {
                    OutputWriter.DisplayException(ExceptionMessages.InexistingCourseInDataBase);
                    }
                }
            else
                {
                OutputWriter.DisplayException(ExceptionMessages.DataNotInitializedExceptionMessage);
                }
            return false;
            }

        private bool IsQueryForStudentPossible(string courseName, string studentName)
            {
            if (IsQueryForCoursePossible(courseName) && this.courses[courseName].StudentsByName.ContainsKey(studentName))
                {
                return true;
                }
            else
                {
                OutputWriter.DisplayException(ExceptionMessages.InexistingStudentInDataBase);
                }
            return false;
            }

        public void GetStudentScoreFromCourse(string courseName, string studentName)
            {
            if (IsQueryForStudentPossible(courseName, studentName))
                {
                OutputWriter.DisplayStudent(new KeyValuePair<string, double>(studentName, this.courses[courseName].StudentsByName[studentName].MarksByCourseName[courseName]));
                }
            }

        public void GetStudentFromCourse(string courseName, string userName)
            {
            if (IsQueryForStudentPossible(courseName, userName))
                {
                OutputWriter.DisplayStudent(new KeyValuePair<string, double>(userName, this.courses[courseName].StudentsByName[userName].MarksByCourseName[courseName]));
                }
            }

        public void GetAllStudentsFromCourse(string courseName)
            {
            if (IsQueryForCoursePossible(courseName))
                {
                OutputWriter.WriteMessageOnNewLine(courseName);

                foreach (var stdentMarksEntry in this.courses[courseName].StudentsByName)
                    {
                    this.GetStudentScoreFromCourse(courseName, stdentMarksEntry.Key);
                    }
                }
            }

        public ISimpleOrderedBag<ICourse> GetAllCoursesSorted(IComparer<ICourse> cmp)
            {
            SimpleSortedList<ICourse> sortedCourses = new SimpleSortedList<ICourse>(cmp);
            sortedCourses.AddAll(this.courses.Values);

            return sortedCourses;
            }

        public void OrderAndTake(string courseName, string comparison, int? studentsToTake = null)
            {
            if (IsQueryForCoursePossible(courseName))
                {
                if (studentsToTake == null)
                    {
                    studentsToTake = this.courses[courseName].StudentsByName.Count;
                    }

                Dictionary<string, double> marks = this.courses[courseName].StudentsByName
                    .ToDictionary(x => x.Key, x => x.Value.MarksByCourseName[courseName]);
                this.sorter.OrderAndTake(marks, comparison, studentsToTake.Value);
                }
            }

        public void FilterAndTake(string courseName, string givenFilter, int? studentsToTake = null)
            {
            if (this.IsQueryForCoursePossible(courseName))
                {
                if (studentsToTake == null)
                    {
                    studentsToTake = this.courses[courseName].StudentsByName.Count;
                    }

                Dictionary<string, double> marks = this.courses[courseName].StudentsByName
                    .ToDictionary(x => x.Key, x => x.Value.MarksByCourseName[courseName]);

                this.filter.FilterAndTake(marks, givenFilter, studentsToTake.Value);
                }
            }


        public ISimpleOrderedBag<IStudent> GetAllStudentsSorted(IComparer<IStudent> cmp)
            {
            SimpleSortedList<IStudent> sortedStudents = new SimpleSortedList<IStudent>(cmp);
            sortedStudents.AddAll(this.students.Values);

            return sortedStudents;
            }



        }
    }