using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Tasks.Models;

namespace Tasks.Data
{
    public class TasksTypeConfiguration : IEntityTypeConfiguration<UserTask>
    {
        public void Configure(EntityTypeBuilder<UserTask> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder
                .Property(b => b.Subject)
                .HasMaxLength(250)
                .IsRequired();

            builder.HasOne(b => b.User)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
