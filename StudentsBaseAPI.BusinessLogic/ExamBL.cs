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
    public class ExamBL : IExamBL
    {
        #region Private fields

        private readonly IExamDAL _examDAL;
        private readonly IMapper _mapper;

        #endregion

        #region Public constructor

        public ExamBL(IExamDAL examDAL, IMapper mapper)
        {
            _examDAL = examDAL;
            _mapper = mapper;
        }

        #endregion

        #region Public methods

        public async Task<List<ExamViewModel>> GetAllExamFilteredAsync(int? index, string courseName, DateTime? examDate)
        {
            var result = await _examDAL.GetAllExamsFilteredAsync(index, courseName, examDate);
            return _mapper.Map<List<ExamViewModel>>(result);
        }

        public async Task<ValidationResponse> CreateOrEditAsync(ExamInputViewModel model)
        {
            var exam = _mapper.Map<Exam>(model);

            ValidationResponse response = new() { IsSuccess = false };

            response.IsSuccess = await _examDAL.CreateOrEditAsync(exam);
            response.Message = response.IsSuccess == true ? $"Exam added/updated" : "Exam was not added.";

            return response;
        }

        public async Task<ExamInputViewModel> GetFirstExamInputViewModelAsync(int id)
        {
            var result = await GetFirstExamAsync(id);
            return _mapper.Map<ExamInputViewModel>(result);
        }

        public async Task<bool> DeleteExmAsync(int id)
        {
            if (id > 0)
            {
                return await _examDAL.DeleteExamAsync(id);
            }

            throw new ArgumentException("ID value for professor is not valid");
        }

        public async Task<Exam> GetFirstExamAsync(int id)
        {
            return await _examDAL.GetFirstExamAsync(id);
        }

        #endregion
    }
}
