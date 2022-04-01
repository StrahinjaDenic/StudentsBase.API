using StudentsBaseAPI.Common.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentsBaseAPI.IDataAccess
{
    public interface IProfessorCourseDAL
    {
        Task<List<ProfessorCourse>> GetAllProfessorCoursesAsync();
    }
}
