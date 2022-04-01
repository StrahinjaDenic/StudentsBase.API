using Microsoft.EntityFrameworkCore;
using StudentsBaseAPI.Common.Models;
using StudentsBaseAPI.IDataAccess;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentsBaseAPI.DataAccess
{
    public class ProfessorCourseDAL : IProfessorCourseDAL
    {
        #region Private fields

        private readonly AppDBContext _context;

        #endregion

        #region Public constructor

        public ProfessorCourseDAL(AppDBContext context)
        {
            _context = context;
        }

        public async Task<List<ProfessorCourse>> GetAllProfessorCoursesAsync()
        {
            return await _context.ProfessorCourses.Include(c => c.Course)
                                             .Include(c => c.Professor)
                                             .ToListAsync();
        }

        #endregion
    }
}
