using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StudentsBaseAPI.Common.ViewModels;
using StudentsBaseAPI.IBusinessLogic;
using System.Threading.Tasks;

namespace StudentsBaseAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExaminationDateController : BaseController
    {
        #region Private fields

        private readonly ILogger<ExaminationDateController> _logger;
        private readonly IExaminationDateBL _examinationDateBL;

        #endregion

        #region Public constructor

        public ExaminationDateController(ILogger<ExaminationDateController> logger, IExaminationDateBL examinationDateBL) : base(logger)
        {
            _logger = logger;
            _examinationDateBL = examinationDateBL;
        }

        #endregion

        #region Public methods

        [HttpGet]
        [Route("Index")]
        public async Task<IActionResult> IndexAsync(int? year, string name = null)
        {
            _logger.LogInformation("Get filtered examination dates");
            return await TryReturnOk(() => _examinationDateBL.GetAllExaminationDatesFilteredAsync(year, name));
        }

        [HttpPost]
        [Route("Save")]
        public async Task<IActionResult> SaveAsync(ExaminationDateInputViewModel model)
        {
            _logger.LogInformation($"Save eaxmination date {model.Name}");
            return await TryReturnOk(() => _examinationDateBL.CreateOrEditAsync(model));
        }

        [HttpGet]
        [Route("Edit")]
        public async Task<ActionResult<ExaminationDateInputViewModel>> EditAsync(int examinationDateId)
        {
            _logger.LogInformation($"Get Examination data with id {examinationDateId}");
            return await TryReturnOk(() => _examinationDateBL.GetFirstExaminationDateAsync(examinationDateId));
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> DeleteAsync(int examinationDateId)
        {
            _logger.LogInformation("Examination date delete started.");
            return await TryReturnOk(() => _examinationDateBL.DeleteExaminationDateAsync(examinationDateId));
        }

        #endregion
    }
}
