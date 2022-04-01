namespace StudentsBaseAPI.Common.Models
{
    public class  StudentPorfessorCourse
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int ProfessorCourseId { get; set; }

        #region Navigation properties

        public virtual Student Student { get; set; }
        public virtual ProfessorCourse ProfessorCourse { get; set; }

        #endregion
    }
}
