using MyTaskManagerProject.Models.Domain;

namespace MyTaskManagerProject.Services
{
    public interface ITaskService
    {
        List<TaskItem> GetTasks();
        TaskItem GetTaskById(long taskId);

        bool AddTask(TaskItem newTask);
        bool EditTask(TaskItem editedTask);

        bool DeleteTask(long taskId);
    }
}
