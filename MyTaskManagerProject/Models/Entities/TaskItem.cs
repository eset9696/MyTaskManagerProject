using MyTaskManagerProject.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyTaskManagerProject.Models.Domain
{
    [Table("Tasks")]
    public class TaskItem
    {

        public long Id { get; set; }
        public long UserId { get; set; }
        public required User User { get; set; }

        public required string Title { get; set; }
        public string? Description { get; set; }
        public bool Status { get; set; } = false;
        public TaskTypeEnum TaskType { get; set; } = TaskTypeEnum.Daily;

        public required DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DoneAt { get; set; }
    }
}
