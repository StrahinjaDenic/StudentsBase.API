using Microsoft.EntityFrameworkCore;
using StudentsBaseAPI.Common.Models;
using StudentsBaseAPI.IDataAccess;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentsBaseAPI.DataAccess
{
    public class StudentDAL : IStudentDAL
    {
        #region Private fields

        private readonly AppDBContext _context;

        #endregion

        #region Public constructor

        public StudentDAL(AppDBContext context)
        {
            _context = context;
        }

        #endregion

        #region Public methods

        public async Task<List<Student>> GetAllStudentsFilteredAsync(int? index, string name, string surname)
        {
            IQueryable<Student> query = _context.Students.Include(x => x.Exams).AsNoTracking().AsQueryable();

            if (index != null)
            {
                query = query.Where(x => x.Index == index);
            }
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
       
        public async Task<bool> CreateOrEditAsync(Student model)
        {
            try
            {
                if (model.Id == 0)
                {
                    _context.Students.Add(model);
                }
                else
                {
                    var studentProfessorCourse = _context.Students.Include(x => x.StudentProfessorCourses).Single(c => c.Id == model.Id);
                    studentProfessorCourse.Index = model.Index;
                    studentProfessorCourse.Name = model.Name;
                    studentProfessorCourse.Surname = model.Surname;
                    studentProfessorCourse.DateOfEntry = model.DateOfEntry;
                    studentProfessorCourse.DateOfBirth = model.DateOfBirth;
                    studentProfessorCourse.PlaceOfBirth = model.PlaceOfBirth;

                    _context.StudentPorfessorCourses.RemoveRange(studentProfessorCourse.StudentProfessorCourses);

                    studentProfessorCourse.StudentProfessorCourses = model.StudentProfessorCourses;
                }

                await _context.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }

        }

        public async Task<Student> GetFirstStudentAsync(int Id)
        {
            return await _context.Students.Include(c => c.Exams)
                                        .ThenInclude(c => c.Course)

                                    .Include(c => c.StudentProfessorCourses)
                                        .ThenInclude(c => c.ProfessorCourse)
                                            .ThenInclude(c => c.Professor)

                                    .Include(c => c.StudentProfessorCourses)
                                        .ThenInclude(c => c.ProfessorCourse)
                                            .ThenInclude(c => c.Course)

                                    .SingleAsync(c => c.Id == Id);

        }

        public async Task<bool> DeleteStudentAsync(int studentId)
        {
            var deleteStudent = await GetFirstStudentAsync(studentId);

            if (deleteStudent == null)
            {
                return false;
            }

            _context.Students.Remove(deleteStudent);

            return (await _context.SaveChangesAsync()) > 0;
        }

        #endregion
    }
}
