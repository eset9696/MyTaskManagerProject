using Microsoft.AspNetCore.Mvc;
using MyTaskManagerProject.Services;

namespace MyTaskManagerProject.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        [ActionName("Index")]
        public IActionResult GetAllTasks()
        {
            ViewBag.Tasks = _taskService.GetTasks();
            return View();
        }
    }
}
