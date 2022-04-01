using System.Collections.Generic;

namespace StudentsBaseAPI.Common.Models
{
    public class ProfessorCourse
    {
        public ProfessorCourse()
        {
            StudentProfessorCourses = new HashSet<StudentPorfessorCourse>();
        }

        public int Id { get; set; }
        public int ProfessorId { get; set; }
        public int CourseId { get; set; }

        #region Navigation properties

        public virtual Professor Professor { get; set; }
        public virtual Course Course { get; set; }

        public virtual ICollection<StudentPorfessorCourse> StudentProfessorCourses { get; set; }

        #endregion
    }
}
