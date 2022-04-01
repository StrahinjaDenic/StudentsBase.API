using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StudentsBaseAPI.Common.ViewModels;
using StudentsBaseAPI.IBusinessLogic;
using System;
using System.Threading.Tasks;

namespace StudentsBaseAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExamController : BaseController
    {
        #region Private fields

        private readonly ILogger<ExamController> _logger;
        private readonly IExamBL _examBL;

        #endregion

        #region Public constructor

        public ExamController(ILogger<ExamController> logger, IExamBL examBL) : base(logger)
        {
            _logger = logger;
            _examBL = examBL;
        }

        #endregion

        #region Public methods

        [HttpGet]
        [Route("Index")]
        public async Task<IActionResult> IndexAsync(int? index = null, string courseName = null, DateTime? examDate = null)
        {
            var exams = await _examBL.GetAllExamFilteredAsync(index, courseName, examDate);

            return Ok(exams);
        }

        [HttpPost]
        [Route("Save")]
        public async Task<IActionResult> SaveAsync(ExamInputViewModel model)
        {
            return await TryReturnOk(() => _examBL.CreateOrEditAsync(model));
        }

        [HttpGet]
        [Route("Edit")]
        public async Task<ActionResult<ExamInputViewModel>> EditAsync(int id)
        {
            _logger.LogInformation($"Get Exam with id {id}");
            return await TryReturnOk(() => _examBL.GetFirstExamInputViewModelAsync(id));
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            _logger.LogInformation("Exam delete started.");
            return await TryReturnOk(() => _examBL.DeleteExmAsync(id));
        }

        #endregion
    }
}
