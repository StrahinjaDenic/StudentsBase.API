using StudentsBaseAPI.Common.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentsBaseAPI.IDataAccess
{
    public interface IExaminationDateDAL
    {
        Task<List<ExaminationDate>> GetAllExaminationDatesFilteredAsync(int? year = null, string name = null);

        Task<bool> CreateOrEditAsync(ExaminationDate model);

        Task<bool> DeleteExaminationDateAsync(int examinationDateId);

        Task<ExaminationDate> GetFirstExaminationDateAsync(int examinationDateId);
    }
}
