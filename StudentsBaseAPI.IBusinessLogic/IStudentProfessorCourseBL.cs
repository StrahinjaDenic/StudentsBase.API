namespace StudentsBaseAPI.IBusinessLogic
{
    public interface IStudentProfessorCourseBL
    {
        bool GetStudentWhoListenTheCourse(int? studentId, int? courseId);
    }
}
