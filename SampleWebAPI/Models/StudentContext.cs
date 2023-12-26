using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SampleWebAPI.Models; 

namespace SampleWebAPI.Models
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options) : base(options)
        {
          
        }

        public DbSet<Student> Students { get; set; } = null; 
    }
}
