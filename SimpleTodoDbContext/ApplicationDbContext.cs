using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using SimpleTodoAuth.Authentication;
using SimpleTodoAuth.Models;

namespace SimpleTodoAuth.SimpleTodoDbContext
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options): base(options) 
        { 
        }

        public DbSet<TodoTaskModel> TodoTasks { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<TodoTaskModel>(entity =>
            {
                entity.Property(e => e.TaskName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.TaskDescription).HasMaxLength(200);
                entity.Property(e => e.TaskStatus);
            });

            base.OnModelCreating(builder);
        }
    }
}
