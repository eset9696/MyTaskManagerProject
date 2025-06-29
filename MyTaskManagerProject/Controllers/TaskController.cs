using Microsoft.AspNetCore.Mvc;
using MyTaskManagerProject.Models.Domain;
using MyTaskManagerProject.Services;

namespace MyTaskManagerProject.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskService _taskService;
        private readonly IUserService _userService;

        public TaskController(ITaskService taskService, IUserService userService)
        {
            _taskService = taskService;
            _userService = userService;
        }

        [HttpGet]
        [ActionName("Index")]
        public IActionResult GetAllTasks()
        {
            User? user = _userService.GetUserById(1);
            if (user is null)
            {
                throw new Exception();
            }
            ViewBag.Tasks = _taskService.GetUserTasks(user);
            return View();
        }

        [HttpGet]
        public IActionResult NewTask()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateTask(TaskItem newTask)
        {
            newTask.UserId = 1;
            _taskService.CreateTask(newTask);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeleteTask(long taskId)
        {
            _taskService.DeleteTask(taskId);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult ChangeTask(long taskId)
        {
            ViewBag.taskId = taskId;
            return View();
        }

        [HttpPost]
        public IActionResult EditTask(TaskItem editedTask, long taskId)
        {
            _taskService.EditTask(editedTask, taskId);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult ChangeTaskStatus(long taskId)
        {
            _taskService.ChangeTaskStatus(taskId);
            return RedirectToAction("Index");
        }
    }
}
