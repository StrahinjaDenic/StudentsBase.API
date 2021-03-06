using StudentsBaseAPI.Common.Models;
using StudentsBaseAPI.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentsBaseAPI.IBusinessLogic
{
    public interface IExamBL
    {
        Task<List<ExamViewModel>> GetAllExamFilteredAsync(int? index, string courseName, DateTime? examDate);

        Task<ValidationResponse> CreateOrEditAsync(ExamInputViewModel model);

        Task<ExamInputViewModel> GetFirstExamInputViewModelAsync(int id);

        Task<ValidationResponse> DeleteExmAsync(int id);
    }
}
