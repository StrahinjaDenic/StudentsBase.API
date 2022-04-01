using StudentsBaseAPI.Common.Models;
using StudentsBaseAPI.IBusinessLogic;
using StudentsBaseAPI.IDataAccess;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentsBaseAPI.BusinessLogic
{
    public class ProfessorCourseBL : IProfessorCourseBL
    {
        #region Private fields

        private readonly IProfessorCourseDAL _professorCourseDAL;

        #endregion

        #region Public constructor

        public ProfessorCourseBL(IProfessorCourseDAL professorCourseDAL)
        {
            _professorCourseDAL = professorCourseDAL;
        }

        #endregion

        #region Public methods

        public async Task<List<ProfessorCourse>> GetAllProfessorCoursesAsync()
        {
            return await _professorCourseDAL.GetAllProfessorCoursesAsync();
        }

        #endregion
    }
}
