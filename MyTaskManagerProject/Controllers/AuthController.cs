using Microsoft.AspNetCore.Mvc;
using MyTaskManagerProject.Models.Domain;
using MyTaskManagerProject.Services;

namespace MyTaskManagerProject.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService) 
        {
            _userService = userService;
        }


        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View("~/Views/Auth/SignUp.cshtml");
        }

        [HttpPost]
        public IActionResult DoLogin(string login, string password)
        {
            User? user = _userService.Authorize(login, password);
            if (user == null)
            {
                ViewBag.ErrorMessage = "Некорректные данные для входа!";
                return View("SignIn");
            }

            HttpContext.Session.SetString("UserId", user.Id.ToString());
            HttpContext.Session.SetString("UserLogin", user.Login);

            return RedirectToAction(controllerName: "Task", actionName: "Index");
        }

        [HttpPost]
        public IActionResult DoRegistration(string login, string password, string email, string phoneNumber)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ErrorMessage = "Данные для регистрация не валидны!";
                return View("SignUp");
            }
            try
            {
                _userService.Register(login, password, email, phoneNumber);
            }
            catch (Exception)
            {
                ViewBag.ErrorMessage = "Упс! Что-то пошло не так!";
                return View("SignUp");
            }
            ViewBag.Message = "Вы успешно зарегистрированы!";
            return View("SignUp");
        }
    }
}
