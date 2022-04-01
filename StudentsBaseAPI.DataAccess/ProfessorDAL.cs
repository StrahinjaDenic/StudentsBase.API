using Microsoft.EntityFrameworkCore;
using StudentsBaseAPI.Common.Models;
using StudentsBaseAPI.IDataAccess;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentsBaseAPI.DataAccess
{
    public class ProfessorDAL : IProfessorDAL
    {
        #region Private fields

        private readonly AppDBContext _context;

        #endregion

        #region Public constructor

        public ProfessorDAL(AppDBContext context)
        {
            _context = context;
        }

        #endregion

        #region Public methods

        public async Task<List<Professor>> GetAllProfessorsFilteredAsync(string name = null, string surname = null)
        {
            IQueryable<Professor> query = _context.Professors
                .Include(x => x.ProfessorCourses)
                .ThenInclude(x => x.Course)
                .AsNoTracking().AsQueryable();

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(x => x.Name.ToLower().Contains(name.Trim().ToLower()));
            }
            if (!string.IsNullOrEmpty(surname))
            {
                query = query.Where(x => x.Surname.ToLower().Contains(surname.Trim().ToLower()));
            }

            return await query.ToListAsync();
        }

        public async Task<bool> CreateOrEditAsync(Professor model)
        {
            try
            {

                if (model.Id == 0)
                {
                    _context.Professors.Add(model);
                }
                else
                {
                    var professor = _context.Professors.Include(x => x.ProfessorCourses).Single(c => c.Id == model.Id);
                    professor.Name = model.Name;
                    professor.Surname = model.Surname;

                    _context.ProfessorCourses.RemoveRange(professor.ProfessorCourses);

                    professor.ProfessorCourses = model.ProfessorCourses;
                }

                await _context.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteProfessorAsync(int professorId)
        {
            var firstProfessor = await GetFirstProfessorAsync(professorId);

            if (firstProfessor == null)
            {
                return false;
            }

            _context.Professors.Remove(firstProfessor);
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<Professor> GetFirstProfessorAsync(int id)
        {
            return await _context.Professors.Include(c => c.ProfessorCourses)
                                       .ThenInclude(c => c.Course)
                                       .SingleAsync(c => c.Id == id);
        }

        public async Task<List<Professor>> GetProfessorByFilterAsync(string name, string surname)
        {
            IQueryable<Professor> query = _context.Professors.AsNoTracking().AsQueryable();

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(x => x.Name.ToLower().Contains(name.Trim().ToLower()));
            }
            if (!string.IsNullOrEmpty(surname))
            {
                query = query.Where(x => x.Surname.ToLower().Contains(surname.Trim().ToLower()));
            }

            return await query.ToListAsync();
        }

        #endregion
    }
}
