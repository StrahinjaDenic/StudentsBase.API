using Microsoft.EntityFrameworkCore;
using StudentsBaseAPI.Common.Models;
using StudentsBaseAPI.IDataAccess;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentsBaseAPI.DataAccess
{
    public class ExaminationDateDAL : IExaminationDateDAL
    {
        #region Private fields

        private readonly AppDBContext _context;

        #endregion

        #region Public constructor

        public ExaminationDateDAL(AppDBContext context)
        {
            _context = context;
        }

        #endregion

        #region Public methods

        public async Task<List<ExaminationDate>> GetAllExaminationDatesFilteredAsync(int? year, string name = null)
        {
            IQueryable<ExaminationDate> query = _context.ExaminationDates.AsNoTracking().AsQueryable();

            if (year != null)
            {
                query = query.Where(x => x.Year == year);
            }
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(x => x.Name.ToLower().Contains(name.Trim().ToLower()));
            }

            return await query.ToListAsync();
        }

        public async Task<bool> CreateOrEditAsync(ExaminationDate model)
        {
            try
            {
                if (model.Id == 0)
                {
                    _context.ExaminationDates.Add(model);
                }
                else
                {
                    var examinationDate = _context.ExaminationDates.Single(c => c.Id == model.Id);
                    examinationDate.Year = model.Year;
                    examinationDate.Mark = model.Mark;
                    examinationDate.Name = model.Name;
                }

                await _context.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteExaminationDateAsync(int examinationDateId)
        {

            var examinationDate = _context.ExaminationDates.Single(c => c.Id == examinationDateId);

            if (examinationDate == null)
            {
                return false;
            }

            _context.ExaminationDates.Remove(examinationDate);
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<ExaminationDate> GetFirstExaminationDateAsync(int examinationDateId)
        {
            return await _context.ExaminationDates.SingleAsync(c => c.Id == examinationDateId);
        }

        #endregion
    }
}
