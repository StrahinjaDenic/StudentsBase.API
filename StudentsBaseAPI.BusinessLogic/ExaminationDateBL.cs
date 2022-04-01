using AutoMapper;
using StudentsBaseAPI.Common.Models;
using StudentsBaseAPI.Common.ViewModels;
using StudentsBaseAPI.IBusinessLogic;
using StudentsBaseAPI.IDataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentsBaseAPI.BusinessLogic
{
    public class ExaminationDateBL : IExaminationDateBL
    {
        #region Private fields

        private readonly IExaminationDateDAL _examinationDateDAL;
        private readonly IMapper _mapper;

        #endregion

        #region Public constructor

        public ExaminationDateBL(IExaminationDateDAL examinationDateDAL, IMapper mapper)
        {
            _examinationDateDAL = examinationDateDAL;
            _mapper = mapper;
        }

        #endregion

        #region Public methods

        public async Task<List<ExaminationDateViewModel>> GetAllExaminationDatesFilteredAsync(int? year, string name = null)
        {
            var result = await _examinationDateDAL.GetAllExaminationDatesFilteredAsync(year, name);
            return _mapper.Map<List<ExaminationDateViewModel>>(result);
        }

        public async Task<ValidationResponse> CreateOrEditAsync(ExaminationDateInputViewModel model)
        {
            var examinationDate = _mapper.Map<ExaminationDate>(model);

            ValidationResponse response = new() { IsSuccess = false };

            response.IsSuccess = await _examinationDateDAL.CreateOrEditAsync(examinationDate);
            response.Message = response.IsSuccess == true ? $"Examination date added/updated" : "Examination date was not added.";

            return response;
        }

        public async Task<ExaminationDate> GetFirstExaminationDateAsync(int examinationDateId)
        {
            return await _examinationDateDAL.GetFirstExaminationDateAsync(examinationDateId);
        }

        public async Task<bool> DeleteExaminationDateAsync(int examinationDateId)
        {
            if (examinationDateId > 0)
            {
                return await _examinationDateDAL.DeleteExaminationDateAsync(examinationDateId);
            }

            throw new ArgumentException("ID value for examination date is not valid");
        }

        #endregion
    }
}
