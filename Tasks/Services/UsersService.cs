using Microsoft.EntityFrameworkCore;
using System.Net.Mail;
using Tasks.Interfaces;
using Tasks.Models;

namespace Tasks.Services
{
    public class UsersService : IUsersService
    {
        private readonly TasksDbContext _dbContext;

        public UsersService(TasksDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Get Table Page informations 
        public async Task<List<UserLogicModel>> Get()
        {
            return await this._dbContext.Users.Select(x => new UserLogicModel
            {
                Name = x.Name,
                Id = x.Id
            }).ToListAsync();
        }
    }
}
