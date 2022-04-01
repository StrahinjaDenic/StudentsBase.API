using StudentsBaseAPI.Common.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentsBaseAPI.IBusinessLogic
{
    public interface IProfessorBL
    {
        Task<List<ProfessorViewModel>> GetAllProfessorsFilteredAsync(string name = null, string surname = null);

        Task<ValidationResponse> CreateOrEditAsync(ProfessorInputViewModel model);

        Task<ProfessorInputViewModel> GetFirstProfessorInputViewModelAsync(int professorId);

        Task<bool> DeleteProfessorAsync(int professorId);
    }
}
