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

            ValidationResponse response = new() { IsSuccess = false };

            response.IsSuccess = await _courseDAL.CreateOrEditAsync(course);
            response.Message = response.IsSuccess == true ? $"Course added/updated" : "Course was not added.";

            return response;
        }

        public async Task<CourseInputViewModel> GetFirstCourseInputViewModelAsync(int id)
        {
            var result = await GetFirstCourseAsync(id);
            return _mapper.Map<CourseInputViewModel>(result);
        }

        //MVC
        //public async Task<CourseViewModel> GetFirstCourseViewModelAsync(int id)
        //{
        //    var firstCourse = await GetFirstCourseAsync(id);

        //    return new CourseViewModel
        //    {
        //        Id = firstCourse.Id,
        //        Code = firstCourse.Code,
        //        Name = firstCourse.Name,
        //        Points = firstCourse.Bodovi,
        //        StudentsLaidings = firstCourse.Exams.GroupBy(c => c.StudentId)
        //                                                  .Select(c => ($"{c.First().StudentNavigation.Name} {c.First().StudentNavigation.Surname}", c.Count(), c.First().StudentNavigation.Id))
        //                                                  .OrderByDescending(c => c.Item2)
        //                                                  .ToList(),
        //        GradeAverage = firstCourse.Exams.Count > 0 ? Math.Round(firstCourse.Exams.Average(c => c.Grade), 2) : null,
        //        PofessorNamesandSurnames = firstCourse.ProfessorCourses.GroupBy(c => c.IdProfessor)
        //                                                               .Select(c => ($"{ c.First().ProfessorNavigation.Name} {c.First().ProfessorNavigation.Surname}"))
        //                                                               .ToList()
        //    };
        //}

        public async Task<Course> GetFirstCourseAsync(int id)
        {
            return await _courseDAL.GetFirstCourseAsync(id);
        }

        public async Task<bool> DeleteCourseAsync(int courseId)
        {
            if (courseId > 0)
            {
                return await _courseDAL.DeleteCourseAsync(courseId);
            }

            throw new ArgumentException("ID value for course is not valid");
        }

        #endregion
    }
}
