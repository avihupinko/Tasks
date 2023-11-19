using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using Tasks.Models;

namespace Tasks.Data
{
    // Define User column types configurations
    public class UsersTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x=> x.Id).ValueGeneratedOnAdd();
            builder
                .Property(b => b.Name)
                .HasMaxLength(250)
                .IsRequired();

            //builder.HasData(new[]
            //{
            //    new User
            //    {
            //        Id = 1,
            //        Name = "Avihu",
            //    },
            //    new User
            //    {
            //        Id = 2,
            //        Name = "Dotan",
            //    },
            //    new User
            //    {
            //        Id = 3,
            //        Name = "Ariel",
            //    }
            //});
        }
    }
}
