using StudentsBaseAPI.Common.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentsBaseAPI.IDataAccess
{
    public interface IExamDAL
    {
        Task<List<Exam>> GetAllExamsFilteredAsync(int? index = null, string courseName = null, DateTime? examDate = null);

        Task<bool> CreateOrEditAsync(Exam model);

        Task<Exam> GetFirstExamAsync(int id);

        Task<bool> DeleteExamAsync(int id);
    }
}
