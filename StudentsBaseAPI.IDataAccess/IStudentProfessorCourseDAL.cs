namespace StudentsBaseAPI.IDataAccess
{
    public interface IStudentProfessorCourseDAL
    {
        bool GetStudentWhoListenTheCourse(int? studentId, int? courseId);
    }
}
