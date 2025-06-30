using Microsoft.AspNetCore.Mvc;
using MyTaskManagerProject.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyTaskManagerProject.Models.Domain
{
    [Table("Tasks")]
    public class TaskItem
    {
        
        public long Id { get; set; }
        public long UserId { get; set; }
        public required User User { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Задача должна иметь название!")]
        [MinLength(5, ErrorMessage = "Название задачи слишком короткое!")]
        [MaxLength(100, ErrorMessage = "Название задачи слишком длинное!")]
        public required string Title { get; set; }

        [BindProperty]
        [MaxLength(400, ErrorMessage = "Описание задачи слишком длинное!")]
        public string? Description { get; set; }


        public bool Status { get; set; } = false;
        public TaskTypeEnum TaskType { get; set; } = TaskTypeEnum.Daily;

        public required DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DoneAt { get; set; }
    }
}
