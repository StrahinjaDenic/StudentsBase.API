using Microsoft.EntityFrameworkCore;
using StudentsBaseAPI.Common.Models;
using StudentsBaseAPI.IDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentsBaseAPI.DataAccess
{
    public class CourseDAL : ICourseDAL
    {
        #region Private fields

        private readonly AppDBContext _context;

        #endregion

        #region Public constructor

        public CourseDAL(AppDBContext context)
        {
            _context = context;
        }

        #endregion

        #region Public methods

        public async Task<List<Course>> GetAllCoursesFilteredAsync(string code = null, string name = null)
        {
            IQueryable<Course> query = _context.Courses.Include(c => c.ProfessorCourses)
                                                        .ThenInclude(c => c.Professor).AsNoTracking().AsQueryable();

            if (!string.IsNullOrEmpty(code))
            {
                query = query.Where(x => x.Code.ToLower().Contains(code.Trim().ToLower()));
            }
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(x => x.Name.ToLower().Contains(name.Trim().ToLower()));
            }

            return await query.ToListAsync();
        }

        public async Task<bool> CreateOrEditAsync(Course course)
        {
            try
            {
                if (course.Id == 0)
                {
                    _context.Courses.Add(course);
                }
                else
                {
                    var CourseInDb = _context.Courses.Include(c => c.ProfessorCourses).Single(c => c.Id == course.Id);
                    CourseInDb.Code = course.Code;
                    CourseInDb.Name = course.Name;
                    CourseInDb.Points = course.Points;

                    _context.ProfessorCourses.RemoveRange(CourseInDb.ProfessorCourses);

                    CourseInDb.ProfessorCourses = course.ProfessorCourses;
                }

                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteCourseAsync(int courseId)
        {
            var firstCourse = await GetFirstCourseAsync(courseId);

            if (firstCourse == null)
            {
                return false;
            }

            _context.Courses.Remove(firstCourse);

            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<Course> GetFirstCourseAsync(int id)
        {
            return await _context.Courses.Include(c => c.Exams)
                                   .ThenInclude(c => c.Student)
                                   .Include(c => c.ProfessorCourses)
                                   .ThenInclude(c => c.Professor)
                                   .SingleAsync(c => c.Id == id);
        }

        #endregion
    }
}
