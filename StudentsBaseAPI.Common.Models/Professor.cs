using System.Collections.Generic;

namespace StudentsBaseAPI.Common.Models
{
    public class Professor
    {
        public Professor()
        {
            ProfessorCourses = new HashSet<ProfessorCourse>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        #region Navigation properties

        public virtual ICollection<ProfessorCourse> ProfessorCourses { get; set; }

        #endregion
    }
}
