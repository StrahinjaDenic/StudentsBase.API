using StudentsBaseAPI.Common.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentsBaseAPI.IDataAccess
{
    public interface ICourseDAL
    {
        Task<List<Course>> GetAllCoursesFilteredAsync(string code = null, string name = null);

        Task<bool> CreateOrEditAsync(Course course);

        Task<bool> DeleteCourseAsync(int courseId);

        Task<Course> GetFirstCourseAsync(int id);
    }
}
