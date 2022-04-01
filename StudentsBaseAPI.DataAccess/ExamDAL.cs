using Microsoft.EntityFrameworkCore;
using StudentsBaseAPI.Common.Models;
using StudentsBaseAPI.IDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentsBaseAPI.DataAccess
{
    public class ExamDAL : IExamDAL
    {
        #region Private fields

        private readonly AppDBContext _context;

        #endregion

        #region Public constructor

        public ExamDAL(AppDBContext context)
        {
            _context = context;
        }

        #endregion

        #region Public methods

        public async Task<List<Exam>> GetAllExamsFilteredAsync(int? index, string courseName, DateTime? examDate)
        {
            IQueryable<Exam> query = _context.Exams.Include(c => c.Course)
                                                   .Include(c => c.ExaminationDate)
                                                   .Include(c => c.Student).AsNoTracking().AsQueryable();

            if (index != null)
            {
                query = query.Where(x => x.Student.Index == index);
            }
            if (!string.IsNullOrEmpty(courseName))
            {
                query = query.Where(x => x.Course.Name.ToLower().Contains(courseName.Trim().ToLower()));
            }
            if (examDate != null)
            {
                query = query.Where(x => x.ExamDate == examDate);
            }

            return await query.ToListAsync();
        }

        public async Task<bool> CreateOrEditAsync(Exam model)
        {
            try
            {
                if (model.Id == 0)
                {
                    _context.Exams.Add(model);
                }
                else
                {
                    var exam = _context.Exams.Single(c => c.Id == model.Id);
                    exam.StudentId = model.StudentId;
                    exam.CourseId = model.CourseId;
                    exam.ExaminationDateId = model.ExaminationDateId;
                    exam.Grade = model.Grade;
                    exam.ExamDate = model.ExamDate;
                    exam.Points = model.Points;
                }

                await _context.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }

        }

        public async Task<Exam> GetFirstExamAsync(int id)
        {
            return await _context.Exams.Include(c => c.Course)
                                 .Include(c => c.ExaminationDate)
                                 .Include(c => c.Student)
                                 .SingleAsync(c => c.Id == id);

        }

        public async Task<bool> DeleteExamAsync(int id)
        {
            var firstExam = await GetFirstExamAsync(id);

            if (firstExam == null)
            {
                return false;
            }

            _context.Exams.Remove(firstExam);

            return (await _context.SaveChangesAsync()) > 0;
        }

        #endregion
    }
}
