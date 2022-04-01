using System;
using System.Collections.Generic;

namespace StudentsBaseAPI.Common.Models
{
    public class Student
    {
        public Student()
        {
            Exams = new HashSet<Exam>();
            StudentProfessorCourses = new HashSet<StudentPorfessorCourse>();
        }

        public int Id { get; set; }
        public int Index { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfEntry { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string PlaceOfBirth { get; set; }

        #region Navigation properties

        public virtual ICollection<Exam> Exams { get; set; }
        public virtual ICollection<StudentPorfessorCourse> StudentProfessorCourses { get; set; }

        #endregion
    }
}
