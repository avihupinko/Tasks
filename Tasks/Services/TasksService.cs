using Microsoft.EntityFrameworkCore;
using Tasks.Extensions;
using Tasks.Interfaces;
using Tasks.Models;

namespace Tasks.Services
{
    public class TasksService : ITasksService
    {
        private readonly TasksDbContext _dbContext;

        public TasksService(TasksDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<TaskLogicModel>> OverDueTasks(OverDueTasksLogicModel model)
        {
            return await this._dbContext.UserTasks.Where(x => x.TargetDate < model.TargetDate && !x.IsCompleted)
                .Include(x => x.User)
                .Select(x => new TaskLogicModel
                {
                    Subject = x.Subject,
                    User = new UserLogicModel { Name = x.User.Name, Id = x.User.Id },
                    UserId = x.UserId,
                    Id = x.Id,
                    IsCompleted = x.IsCompleted,
                    TargetDate = x.TargetDate
                }).ToListAsync();
        }

        public async Task<TaskLogicModel> Create(TaskLogicModel model)
        {
            var user = await this._dbContext.Users.FirstOrDefaultAsync(x => x.Id == model.UserId);
            if (user == null)
                throw new ValidationException("User not found");

            if (await this._dbContext.UserTasks.CountAsync(x => x.UserId == model.UserId && !x.IsCompleted) == 10)
                throw new ValidationException("User has 10 open tasks");

            if (await this._dbContext.UserTasks.AnyAsync(x => x.UserId == model.UserId && x.Subject == model.Subject))
                throw new ValidationException("User already has task with the specified subject");

            if (model.TargetDate <= DateTime.UtcNow)
                throw new ValidationException("Tagert Date must be a future date");

            var task = new UserTask
            {
                Subject = model.Subject,
                UserId = model.UserId,
                TargetDate = model.TargetDate,
                IsCompleted = model.IsCompleted
            };

            this._dbContext.UserTasks.Add(task);
            await this._dbContext.SaveChangesAsync();
            model.Id = task.Id;
            model.User = new UserLogicModel { Name = user.Name, Id = user.Id };
            return model;
        }

        public async Task<List<TaskLogicModel>> Get()
        {
            return await this._dbContext.UserTasks
                .Include(x => x.User)
                .OrderByDescending(x=> x.Id)
                .Select(x => new TaskLogicModel
                {
                    Subject = x.Subject,
                    User = new UserLogicModel { Name = x.User.Name, Id = x.User.Id },
                    UserId = x.UserId,
                    Id = x.Id,
                    IsCompleted = x.IsCompleted,
                    TargetDate = x.TargetDate
                }).ToListAsync();
        }

        public async Task<List<OpenTasksLogicModel>> OpenTasks()
        {
           return await this._dbContext.UserTasks.Include(x => x.User)
                 .Where(x => !x.IsCompleted)
                 .GroupBy(x => new { x.UserId, x.User.Name })
                 .Select(x => new OpenTasksLogicModel { Name = x.Key.Name, Count = x.Count() })
                 .ToListAsync();
        }
    }
}
