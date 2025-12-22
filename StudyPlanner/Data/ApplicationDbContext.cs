using Microsoft.EntityFrameworkCore;
using StudyPlanner.Models;
using System.Collections.Generic;

namespace StudyPlanner.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}
