using StudentsBaseAPI.Common.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentsBaseAPI.IDataAccess
{
    public interface IProfessorDAL
    {
        Task<List<Professor>> GetAllProfessorsFilteredAsync(string name = null, string surname = null);

        Task<bool> CreateOrEditAsync(Professor model);

        Task<Professor> GetFirstProfessorAsync(int id);

        Task<bool> DeleteProfessorAsync(int professorId);

    }
}
