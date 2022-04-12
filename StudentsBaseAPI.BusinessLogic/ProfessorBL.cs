using AutoMapper;
using StudentsBaseAPI.Common.Models;
using StudentsBaseAPI.Common.ViewModels;
using StudentsBaseAPI.IBusinessLogic;
using StudentsBaseAPI.IDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentsBaseAPI.BusinessLogic
{
    public class ProfessorBL : IProfessorBL
    {
        #region Private fields

        private readonly IProfessorDAL _professorDAL;
        private readonly IMapper _mapper;

        #endregion

        #region Public constructor

        public ProfessorBL(IProfessorDAL professorDAL, IMapper mapper)
        {
            _professorDAL = professorDAL;
            _mapper = mapper;
        }

        #endregion

        #region Public methods

        public async Task<List<ProfessorViewModel>> GetAllProfessorsFilteredAsync(string name = null, string surname = null)
        {
            var result = await _professorDAL.GetAllProfessorsFilteredAsync(name, surname);
            return _mapper.Map<List<ProfessorViewModel>>(result);

        }
        public async Task<ValidationResponse> CreateOrEditAsync(ProfessorInputViewModel model)
        {
            var professor = _mapper.Map<Professor>(model);

            var response = new ValidationResponse();

            response.IsSuccess = await _professorDAL.CreateOrEditAsync(professor);
            response.Message = response.IsSuccess == true ? $"Professor added/updated" : "Professor was not added.";


            return response;
        }

        public async Task<ValidationResponse> DeleteProfessorAsync(int professorId)
        {
            var response = new ValidationResponse();

            if (professorId > 0)
            {
                response.IsSuccess = await _professorDAL.DeleteProfessorAsync(professorId);
                response.Message = response.IsSuccess == true ? "Professor succesfully deleted!" : "Error occured!";
            }
            else
            {
                response.IsSuccess = false;
                response.Message = "ID value for examination date is not valid!";
            }

            return response;
        }

        public async Task<ProfessorInputViewModel> GetFirstProfessorInputViewModelAsync(int professorId)
        {
            var result = await _professorDAL.GetFirstProfessorAsync(professorId);
            return _mapper.Map<ProfessorInputViewModel>(result);
        }

        #endregion
    }
}
