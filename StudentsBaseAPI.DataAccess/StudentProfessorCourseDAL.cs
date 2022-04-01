using StudentsBaseAPI.IDataAccess;
using System.Linq;

namespace StudentsBaseAPI.DataAccess
{
    public class StudentProfessorCourseDAL : IStudentProfessorCourseDAL
    {
        #region Private fields

        private readonly AppDBContext _context;

        #endregion

        #region Public constructor

        public StudentProfessorCourseDAL(AppDBContext context)
        {
            _context = context;
        }

        #endregion

        #region Public methods

        public bool GetStudentWhoListenTheCourse(int? studentId, int? courseId)
        {
            return _context.StudentPorfessorCourses.Where(c => c.StudentId == studentId &&
                                                          c.ProfessorCourse.CourseId == courseId).Count() > 0;
        }

        #endregion
    }
}
