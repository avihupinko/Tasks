using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tasks.Extensions;
using Tasks.Interfaces;
using Tasks.Models;

namespace users_backend.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TasksController : Controller
    {
        private readonly ITasksService _service;

        public TasksController(ITasksService service)
        {
            _service = service;
        }

        /// <summary>
        /// Get Tasks
        /// </summary>
        /// <returns></returns>
        [HttpGet("~/api/Tasks")]
        public async Task<ActionResult<List<TaskLogicModel>>> Get()
        {
            return Ok(await _service.Get());
        }

        /// <summary>
        /// Get Open Tasks
        /// </summary>
        /// <returns></returns>
        [HttpGet("~/api/Tasks/Open")]
        public async Task<ActionResult<List<OpenTasksLogicModel>>> OpenTasks()
        {
            return Ok(await _service.OpenTasks());
        }

        /// <summary>
        /// Get OverDue Tasks
        /// </summary>
        /// <returns></returns>
        [HttpPost("~/api/Tasks/OverDue")]
        public async Task<ActionResult<List<TaskLogicModel>>> OverDueTasks(OverDueTasksLogicModel model)
        {
            return Ok(await _service.OverDueTasks(model));
        }

        /// <summary>
        /// Create Task
        /// </summary>
        /// <returns></returns>
        [HttpPost("~/api/Tasks")]
        public async Task<ActionResult<TaskLogicModel>> Create(TaskLogicModel model)
        {
            try
            {
                return Ok(await _service.Create(model));
            }
            catch (ValidationException exp)
            {
                return BadRequest(exp.Message);
            }
        }
    }
}
