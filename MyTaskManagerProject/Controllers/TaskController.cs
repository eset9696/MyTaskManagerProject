using Microsoft.AspNetCore.Mvc;
using MyTaskManagerProject.Enums;
using MyTaskManagerProject.Filters;
using MyTaskManagerProject.Models.Domain;
using MyTaskManagerProject.Services;
using System.ComponentModel.DataAnnotations;

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
        [AuthorizedOnly]
        public IActionResult GetAllTasks()
        {
            User? user = _userService.GetUserById(Convert.ToInt64(HttpContext.Session.GetString("UserId")));
            if (user != null)
            {
                ViewBag.Tasks = _taskService.GetUserTasks(user);
                return View();
            }
            return RedirectToAction(controllerName: "Home", actionName: "Index");
        }

        [HttpGet]
        [AuthorizedOnly]
        public IActionResult NewTask()
        {
            return View();
        }

        [HttpPost]
        [AuthorizedOnly]
        public IActionResult NewTask(TaskItem newTask)
        {
            if (newTask.Title == null)
            {
                ViewBag.ErrorMessage = "Указаны некорректные данные!";
                return View();
            }

            long userId = Convert.ToInt64(HttpContext.Session.GetString("UserId"));
            newTask.UserId = userId;
            _taskService.CreateTask(newTask);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [AuthorizedOnly]
        public IActionResult DeleteTask(long taskId)
        {
            _taskService.DeleteTask(taskId);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [AuthorizedOnly]
        public IActionResult EditTask(long taskId)
        {
            ViewBag.taskId = taskId;
            return View();
        }

        [HttpPost]
        [AuthorizedOnly]
        public IActionResult EditTask(TaskItem editedTask, long taskId)
        {
            _taskService.EditTask(editedTask, taskId);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [AuthorizedOnly]
        public IActionResult ChangeTaskStatus(long taskId)
        {
            _taskService.ChangeTaskStatus(taskId);
            return RedirectToAction("Index");
        }
    }
}
