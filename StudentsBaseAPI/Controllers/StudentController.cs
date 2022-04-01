﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StudentsBaseAPI.Common.ViewModels;
using StudentsBaseAPI.IBusinessLogic;
using System.Threading.Tasks;

namespace StudentsBaseAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : BaseController
    {
        #region Private fields

        private readonly ILogger<StudentController> _logger;
        private readonly IStudentBL _studentBL;

        #endregion

        #region Public constructor

        public StudentController(ILogger<StudentController> logger, IStudentBL studentBL) : base(logger)
        {
            _logger = logger;
            _studentBL = studentBL;
        }

        #endregion

        #region Public methods

        [HttpGet]
        [Route("Index")]
        public async Task<IActionResult> IndexAsync(int? index, string name, string surname)
        {
            var student = await _studentBL.GetAllStudentsFilteredAsync(index, name, surname);
            return Ok(student);
        }


        [HttpGet]
        [Route("ProfessorCourses")]
        public async Task<IActionResult> GetAllProfessorCoursesAnsyc()
        {
            var profCourses = _studentBL.GetAllProfessorCoursesAsync();
            return Ok(await profCourses);
        }

        [HttpPost]
        [Route("Save")]
        public async Task<IActionResult> SaveAsync(StudentInputViewModel model)
        {
            return await TryReturnOk(() => _studentBL.CreateOrEditAsync(model));
        }

        [HttpGet]
        [Route("Edit")]
        public async Task<ActionResult<StudentInputViewModel>> EditAsync(int studentId)
        {
            _logger.LogInformation($"Get Student with id {studentId}");
            return await TryReturnOk(() => _studentBL.GetFirstStudentInputViewModelAsync(studentId));
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> DeleteAsync(int studentId)
        {
            _logger.LogInformation("Student delete started.");
            return await TryReturnOk(() => _studentBL.DeleteStudentAsync(studentId));
        }

        #endregion
    }
}
