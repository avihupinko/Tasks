using Microsoft.EntityFrameworkCore;
using Tasks.Data;
using Tasks.Models;

namespace Tasks
{
    public class TasksDbContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserTask> UserTasks { get; set; }

        public TasksDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Define DB assemblys
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UsersTypeConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TasksTypeConfiguration).Assembly);
            modelBuilder.Entity<User>().HasData(new[]
            {
                new User
                {
                    Id = 1,
                    Name = "Avihu",
                },
                new User
                {
                    Id = 2,
                    Name = "Dotan",
                },
                new User
                {
                    Id = 3,
                    Name = "Ariel",
                }
            });

            modelBuilder.Entity<UserTask>().HasData(new[]
            {
                new UserTask
                {
                    Id = 1,
                    Subject = "Task1",
                    UserId = 1,
                    TargetDate = new DateTime(2023, 11, 11),
                    IsCompleted = false,
                },
                new UserTask
                {
                    Id = 2,
                    Subject = "Task2",
                    UserId = 2,
                    TargetDate = new DateTime(2023, 11, 11),
                    IsCompleted = true,
                },
                new UserTask
                {
                    Id = 3,
                    Subject = "Task3",
                    UserId = 3,
                    TargetDate = new DateTime(2023, 11, 11),
                    IsCompleted = false,
                },
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
