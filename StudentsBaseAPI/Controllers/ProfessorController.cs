using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StudentsBaseAPI.Common.ViewModels;
using StudentsBaseAPI.IBusinessLogic;
using System.Threading.Tasks;

namespace StudentsBaseAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProfessorController : BaseController
    {
        #region Private fields

        private readonly ILogger<ProfessorController> _logger;
        private readonly IProfessorBL _professorBL;
        private readonly ICourseBL _courseBL;

        #endregion

        #region Public constructor

        public ProfessorController(ILogger<ProfessorController> logger, IProfessorBL professorBL, ICourseBL courseBL) : base(logger)
        {
            _logger = logger;
            _professorBL = professorBL;
            _courseBL = courseBL;
        }

        #endregion

        #region Public methods

        [HttpGet]
        [Route("Index")]
        public async Task<IActionResult> IndexAnsyc(string name = null, string surname = null)
        {
            _logger.LogInformation("Get filtered professors");
            return await TryReturnOk(() => _professorBL.GetAllProfessorsFilteredAsync(name, surname));
        }

        [HttpPost]
        [Route("Save")]
        public async Task<IActionResult> SaveAsync(ProfessorInputViewModel model)
        {
            _logger.LogInformation($"Save professor {model.Name} {model.Surname}");
            return await TryReturnOk(() => _professorBL.CreateOrEditAsync(model));
        }

        [HttpGet]
        [Route("Edit")]
        public async Task<ActionResult<ProfessorInputViewModel>> EditAsync(int id)
        {
            _logger.LogInformation($"Get Professor with id {id}");
            return await TryReturnOk(() => _professorBL.GetFirstProfessorInputViewModelAsync(id));
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> DeleteAsync(int professorId)
        {

            _logger.LogInformation("Professor delete started.");
            return await TryReturnOk(() => _professorBL.DeleteProfessorAsync(professorId));
        }

        #endregion
    }
}
