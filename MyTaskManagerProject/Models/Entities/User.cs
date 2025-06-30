using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyTaskManagerProject.Models.Domain
{
    public class User
    {
        public long Id { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Логин обязательное поле!")]
        [MinLength(5, ErrorMessage = "Логин слишком короткий!")]
        [MaxLength(15, ErrorMessage = "Логин слишком длинный!")]
        public required string Login { get; set; }


        [BindProperty]
        [Required(ErrorMessage = "email обязательное поле!")]
        public required string Email { get; set; }


        [BindProperty]
        [Required(ErrorMessage = "Пароль обязательное поле!")]
        [MinLength(8, ErrorMessage = "Пароль слишком короткий!")]
        [MaxLength(50, ErrorMessage = "Пароль слишком длинный!")]
        public required string Password { get; set; }

        [BindProperty]
        public string? PhoneNumber { get; set; }

        public DateTime? CreatedAt { get; set; } = DateTime.Now;

        public DateTime? UpdatedAt { get;set; }

        public List<TaskItem> Tasks { get; set; } = new List<TaskItem>();
    }
}
