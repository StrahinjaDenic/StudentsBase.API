using StudentsBaseAPI.Common.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentsBaseAPI.IBusinessLogic
{
    public interface ICourseBL
    {
        Task<List<CourseViewModel>> GetAllCoursesFilteredAsync(string code = null, string name = null);

        Task<ValidationResponse> CreateOrEditAsync(CourseInputViewModel model);

        Task<CourseInputViewModel> GetFirstCourseInputViewModelAsync(int id);

        Task<bool> DeleteCourseAsync(int courseId);
    }
}
