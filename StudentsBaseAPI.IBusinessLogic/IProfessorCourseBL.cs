using StudentsBaseAPI.Common.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentsBaseAPI.IBusinessLogic
{
    public interface IProfessorCourseBL
    {
        Task<List<ProfessorCourse>> GetAllProfessorCoursesAsync();
    }
}
