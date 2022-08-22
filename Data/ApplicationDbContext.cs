using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SimpleTodoAuth.Models;

namespace SimpleTodoAuth.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<SimpleTodoAuth.Models.TodoTaskModel> TodoTaskModel { get; set; }
    }
}
