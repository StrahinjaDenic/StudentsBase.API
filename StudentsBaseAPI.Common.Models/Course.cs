using System.Collections.Generic;

namespace StudentsBaseAPI.Common.Models
{
    public class Course
    {
        public Course()
        {
            Exams = new HashSet<Exam>();
            ProfessorCourses = new HashSet<ProfessorCourse>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public short Points { get; set; }
        public string Description { get; set; }

        #region Navigation properties

        public virtual ICollection<Exam> Exams { get; set; }
        public virtual ICollection<ProfessorCourse> ProfessorCourses { get; set; }

        #endregion
    }
}
