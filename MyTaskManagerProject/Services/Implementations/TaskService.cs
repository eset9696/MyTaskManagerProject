using Microsoft.EntityFrameworkCore;
using MyTaskManagerProject.Data;
using MyTaskManagerProject.Models.Domain;
using System.Threading.Tasks;

namespace MyTaskManagerProject.Services.Implementations
{
    public class TaskService : ITaskService
    {
        private readonly ApplicationDbContext _database;

        public TaskService(ApplicationDbContext database)
        {
            _database = database;
        }

        public bool CreateTask(TaskItem newTask)
        {
            try
            {
                _database.Tasks.Add(newTask);
                _database.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool DeleteTask(long taskId)
        {
            try
            {
                TaskItem? taskForDelete = GetTaskById(taskId);
                if (taskForDelete is null)
                    return false;

                _database.Tasks.Remove(taskForDelete);
                _database.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool EditTask(TaskItem editedTask, long taskId)
        {
            try
            {
                TaskItem? taskForEdit = GetTaskById(taskId);
                if (editedTask != null && taskForEdit != null)
                {
                    taskForEdit.Title = editedTask.Title;
                    taskForEdit.Description = editedTask.Description;
                    taskForEdit.Status = editedTask.Status;
                    taskForEdit.TaskType = editedTask.TaskType;
                    taskForEdit.UpdatedAt = DateTime.Now;


                    _database.Tasks.Update(taskForEdit);
                    _database.SaveChanges();

                    return true;
                }
                else
                    return false;
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public bool ChangeTaskStatus(long taskId)
        {
            try
            {
                TaskItem? taskForEdit = GetTaskById(taskId);
                if (taskForEdit != null)
                {
                    if(taskForEdit.Status == false)
                    {
                        taskForEdit.Status = true;
                        taskForEdit.DoneAt = DateTime.Now;
                    }
                    else
                    {
                        taskForEdit.Status = false;
                        taskForEdit.DoneAt = null;
                    }

                    _database.Tasks.Update(taskForEdit);
                    _database.SaveChanges();

                    return true;
                }
                else
                    return false;
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public TaskItem? GetTaskById(long taskId)
        {
            return _database.Tasks.FirstOrDefault(task => task.Id == taskId);
        }

        public List<TaskItem> GetUserTasks(User user)
        {
            return _database.Tasks.Where(task => task.UserId == user.Id).ToList();
        }
    }
}
