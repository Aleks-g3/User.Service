using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User.Service.API.Domian.Models;

namespace User.Service.API.Domian.Persistence.Contexts
{
    public class DatabaseContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<UserTask> UserTasks { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserEntity>().ToTable("Users");
            builder.Entity<UserEntity>().HasKey(p => p.ID);
            builder.Entity<UserEntity>().Property(p => p.ID).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<UserEntity>().Property(p => p.Name).IsRequired().HasMaxLength(20);
            builder.Entity<UserEntity>().Property(p => p.Surname).IsRequired().HasMaxLength(20);
            builder.Entity<UserEntity>().Property(p => p.IsDeleted);
            builder.Entity<UserEntity>().HasMany(p => p.UserTasks).WithOne(p => p.User).HasForeignKey(p => p.UserID);

            builder.Entity<UserTask>().ToTable("UserTasks");
            builder.Entity<UserTask>().HasKey(p => p.ID);
            builder.Entity<UserTask>().Property(p => p.ID).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<UserTask>().Property(p => p.Title).IsRequired().HasMaxLength(10);
            builder.Entity<UserTask>().Property(p => p.Description).IsRequired().HasMaxLength(30);
            builder.Entity<UserTask>().Property(p => p.IsDeleted);
            builder.Entity<UserTask>().Property(p => p.Deadline);
        }
    }
}
