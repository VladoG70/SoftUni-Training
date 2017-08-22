﻿using System;
using System.Collections.Generic;
using BashSoft.Contracts;

namespace BashSoft
    {
    public class RepositoryFilter : IDataFilter
        {
        public void FilterAndTake(Dictionary<string, double> studentsWithMarks, string wantedFilter, int studentsToTake)
            {
            wantedFilter = wantedFilter.ToLower();

            if (wantedFilter == "excellent")
                {
                FilterAndTake(studentsWithMarks, x => x >= 5, studentsToTake);
                }
            else if (wantedFilter == "average")
                {
                FilterAndTake(studentsWithMarks, x => x < 5 && x >= 3.5, studentsToTake);
                }
            else if (wantedFilter == "poor")
                {
                FilterAndTake(studentsWithMarks, x => x < 3.5, studentsToTake);
                }
            else
                {
                throw new ArgumentException(ExceptionMessages.InvalidStudentFilter);
                }
            }

        private void FilterAndTake(Dictionary<string, double> studentsWithMarks, Predicate<double> givenFilter, int studentsToTake)
            {
            var counterForPrinted = 0;

            foreach (var studentMark in studentsWithMarks)
                {
                if (counterForPrinted == studentsToTake)
                    {
                    break;
                    }

                if (givenFilter(studentMark.Value))
                    {
                    OutputWriter.DisplayStudent(new KeyValuePair<string, double>(studentMark.Key, studentMark.Value));
                    counterForPrinted++;
                    }
                }
            }
        }
    }