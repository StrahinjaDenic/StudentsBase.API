using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StudentsBaseAPI.Common.ViewModels;
using StudentsBaseAPI.IBusinessLogic;
using System.Threading.Tasks;

namespace StudentsBaseAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CourseController : BaseController
    {
        #region Private fields

        private readonly ILogger<CourseController> _logger;
        private readonly ICourseBL _courseBL;

        #endregion

        #region Public constructor

        public CourseController(ILogger<CourseController> logger, ICourseBL courseBL) : base(logger)
        {
            _logger = logger;
            _courseBL = courseBL;
        }

        #endregion

        #region Public methods

        [HttpGet]
        [Route("Index")]
        public async Task<IActionResult> IndexAsync(string code = null, string name = null)
        {
            _logger.LogInformation($"Get filtered courses");
            return await TryReturnOk(() => _courseBL.GetAllCoursesFilteredAsync(code, name));
        }

        [HttpPost]
        [Route("Save")]
        public async Task<IActionResult> SaveAsync(CourseInputViewModel model)
        {
            _logger.LogInformation($"Save course {model.Name}");
            return await TryReturnOk(() => _courseBL.CreateOrEditAsync(model));
        }

        [HttpGet]
        [Route("Edit")]
        public async Task<ActionResult<CourseInputViewModel>> EditAsync(int courseId)
        {
            _logger.LogInformation($"Get Course with id {courseId}");
            return await TryReturnOk(() => _courseBL.GetFirstCourseInputViewModelAsync(courseId));
        }

        [HttpDelete] 
        [Route("Delete")]
        public async Task<IActionResult> DeleteAsync(int courseId)
        {
            _logger.LogInformation("Coruse delete started.");
            return await TryReturnOk(() => _courseBL.DeleteCourseAsync(courseId));
        }

        #endregion
    }
}
