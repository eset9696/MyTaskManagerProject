using MyTaskManagerProject.Models.Domain;

namespace MyTaskManagerProject.Services
{
    public interface ITaskService
    {
        List<TaskItem> GetUserTasks(User user);
        TaskItem? GetTaskById(long taskId);

        bool CreateTask(TaskItem newTask);
        bool EditTask(TaskItem editedTask, long taskId);
        bool ChangeTaskStatus(long taskId);
        bool DeleteTask(long taskId);
    }
}
