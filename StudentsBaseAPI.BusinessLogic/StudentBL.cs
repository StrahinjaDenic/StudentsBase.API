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
    public class StudentBL : IStudentBL
    {
        #region Private fields

        private readonly IStudentDAL _studentDAL;
        private readonly IProfessorCourseDAL _professorCourseDAL;
        private readonly IMapper _mapper;

        #endregion

        #region Public constructor

        public StudentBL(IStudentDAL studentDAL, IProfessorCourseDAL professorCourseDAL, IMapper mapper)
        {
            _studentDAL = studentDAL;
            _professorCourseDAL = professorCourseDAL;
            _mapper = mapper;
        }

        #endregion

        #region Public methods
        
        public async Task<List<StudentViewModel>> GetAllStudentsFilteredAsync(int? index, string name, string surname)
        {
            var result = await _studentDAL.GetAllStudentsFilteredAsync(index, name, surname);
             return _mapper.Map<List<StudentViewModel>>(result);
        }

        public async Task<ValidationResponse> CreateOrEditAsync(StudentInputViewModel model)
        {
            var student = _mapper.Map<Student>(model); 
             
            ValidationResponse response = new() { IsSuccess = false };

            response.IsSuccess = await _studentDAL.CreateOrEditAsync(student);
            response.Message = response.IsSuccess == true ? $"Student added/updated" : "Student was not added.";

            return response;
        }

        public async Task<StudentInputViewModel> GetFirstStudentInputViewModelAsync(int studentId)
        {
            var result = await GetFirstStudentAsync(studentId);
            return _mapper.Map<StudentInputViewModel>(result);
        }

        public async Task<Student> GetFirstStudentAsync(int Id)
        {
            return await _studentDAL.GetFirstStudentAsync(Id);
        }

        public async Task<bool> DeleteStudentAsync(int studentId)
        {
            if (studentId > 0)
            {
                return await _studentDAL.DeleteStudentAsync(studentId);
            }
            throw new ArgumentException("ID value for student is not valid");
        }

        public async Task<List<ProfessorCourseViewModel>> GetAllProfessorCoursesAsync()
        {
            var result = await _professorCourseDAL.GetAllProfessorCoursesAsync();

            return _mapper.Map<List<ProfessorCourseViewModel>>(result);
        }

        #endregion
    }
}
