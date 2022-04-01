using StudentsBaseAPI.IBusinessLogic;
using StudentsBaseAPI.IDataAccess;

namespace StudentsBaseAPI.BusinessLogic
{
    public class StudentProfessorCourseBL : IStudentProfessorCourseBL
    {
        #region Private fields

        private readonly IStudentProfessorCourseDAL _studentProfessorCourseDAL;

        #endregion

        #region Public constructor

        public StudentProfessorCourseBL(IStudentProfessorCourseDAL studentProfessorCourseDAL)
        {
            _studentProfessorCourseDAL = studentProfessorCourseDAL;
        }

        #endregion

        #region Public methods

        public bool GetStudentWhoListenTheCourse(int? studentId, int? courseId)
        {
            return _studentProfessorCourseDAL.GetStudentWhoListenTheCourse(studentId, courseId);
        }

        #endregion
    }
}
