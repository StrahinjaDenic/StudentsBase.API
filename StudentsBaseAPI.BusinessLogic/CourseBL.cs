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
    public class CourseBL : ICourseBL
    {
        #region Private fields

        private readonly ICourseDAL _courseDAL;
        private readonly IMapper _mapper;

        #endregion

        #region Public constructor

        public CourseBL(ICourseDAL courseDAL, IMapper mapper)
        {
            _courseDAL = courseDAL;
            _mapper = mapper;
        }

        //TODO dodati ostalo
        //private readonly IProfessorManager _professorManager;

        //public CourseManager(ICourseRepository courseRepository, IProfessorManager professorManager)
        //{
        //    _courseRepository = courseRepository;
        //    _professorManager = professorManager;
        //}

        #endregion

        #region Public methods

        public async Task<List<CourseViewModel>> GetAllCoursesFilteredAsync(string code = null, string name = null)
        {
            var result = await _courseDAL.GetAllCoursesFilteredAsync(code, name);
            return _mapper.Map<List<CourseViewModel>>(result);
        }

        public async Task<ValidationResponse> CreateOrEditAsync(CourseInputViewModel model)
        {
            var course = _mapper.Map<Course>(model);

            var response = new ValidationResponse();

            response.IsSuccess = await _courseDAL.CreateOrEditAsync(course);
            response.Message = response.IsSuccess == true ? $"Course added/updated" : "Course was not added.";

            return response;
        }

        public async Task<CourseInputViewModel> GetFirstCourseInputViewModelAsync(int id)
        {
            var result = await _courseDAL.GetFirstCourseAsync(id);
            return _mapper.Map<CourseInputViewModel>(result);
        }

        public async Task<ValidationResponse> DeleteCourseAsync(int courseId)
        {
            var response = new ValidationResponse ();

            if (courseId > 0)
            {
                response.IsSuccess = await _courseDAL.DeleteCourseAsync(courseId);
                response.Message = response.IsSuccess == true ? "Course succesfully deleted!" : "Error occured!";
            }
            else
            {
                response.IsSuccess = false;
                response.Message = "ID value for course is not valid!";
            }

            return response;
        }

        #endregion
    }
}
