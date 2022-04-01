using StudentsBaseAPI.Common.Models;
using StudentsBaseAPI.Common.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentsBaseAPI.IBusinessLogic
{
    public interface IStudentBL
    {
        Task<List<StudentViewModel>> GetAllStudentsFilteredAsync(int? index, string name, string surname);

        Task<ValidationResponse> CreateOrEditAsync(StudentInputViewModel model);

        Task<StudentInputViewModel> GetFirstStudentInputViewModelAsync(int studentId);

        Task<Student> GetFirstStudentAsync(int Id);

        Task<bool> DeleteStudentAsync(int studentId);

        Task<List<ProfessorCourseViewModel>> GetAllProfessorCoursesAsync();
    }
}
