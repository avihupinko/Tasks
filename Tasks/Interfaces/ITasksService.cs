using Tasks.Models;

namespace Tasks.Interfaces
{
    public interface ITasksService
    {
        Task<List<OpenTasksLogicModel>> OpenTasks();
        Task<List<TaskLogicModel>> Get();
        Task<TaskLogicModel> Create(TaskLogicModel model);
        Task<List<TaskLogicModel>> OverDueTasks(OverDueTasksLogicModel model);
    }
}
