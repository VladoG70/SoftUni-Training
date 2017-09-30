using System.Collections.Generic;

namespace BashSoft.Contracts
    {
    public interface IRequester
        {
        void GetAllStudentsFromCourse(string courseName);

        void GetStudentScoreFromCourse(string courseName, string studentName);

        void GetStudentFromCourse(string courseName, string userName);

        ISimpleOrderedBag<ICourse> GetAllCoursesSorted(IComparer<ICourse> cmp);

        ISimpleOrderedBag<IStudent> GetAllStudentsSorted(IComparer<IStudent> cmp);
        }
    }