using MyTaskManagerProject.Models.Domain;

namespace MyTaskManagerProject.Services.Implementations
{
    public class TaskService : ITaskService
    {

        private List<TaskItem> _tasks = new List<TaskItem>()
        {
            new TaskItem()
            {
                Title = "Task 1",
                Description = "Desctiption 1",
                CreatedAt = DateTime.Now,
                TaskType = Enums.TaskTypeEnum.Weekly,
            },
            new TaskItem()
            {
                Title = "Task 1",
                Description = "Desctiption 2"
            },
            new TaskItem()
            {
                Title = "Task 1",
                Description = "Desctiption 3"
            },
            new TaskItem()
            {
                Title = "Task 1",
                Description = "Desctiption 4"
            },
            new TaskItem()
            {
                Title = "Task 1",
                Description = "Desctiption 5"
            },
        };

        public bool AddTask(TaskItem newTask)
        {
            throw new NotImplementedException();
        }

        public bool DeleteTask(long taskId)
        {
            throw new NotImplementedException();
        }

        public bool EditTask(TaskItem editedTask)
        {
            throw new NotImplementedException();
        }

        public TaskItem GetTaskById(long taskId)
        {
            throw new NotImplementedException();
        }

        public List<TaskItem> GetTasks()
        {
            return _tasks;
        }
    }
}
