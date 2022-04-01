using StudentsBaseAPI.Common.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentsBaseAPI.IDataAccess
{
    public interface IStudentDAL
    {
        Task<List<Student>> GetAllStudentsFilteredAsync(int? index = null, string name = null, string surname = null);

        Task<bool> CreateOrEditAsync(Student model);

        Task<Student> GetFirstStudentAsync(int Id);

        Task<bool> DeleteStudentAsync(int studentId);
    }
}
