using Microsoft.EntityFrameworkCore;

namespace ReactAspCrud.Models
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options)
        {
        }

        public DbSet<Student> Student { get; set; }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Data Source=DESKTOP-H58DVOI\\SQLEXPRESS;Initial Catalog=lbs;User ID=sa;Password=Uday@901!; TrustServerCertificate=True;");
        //}
    }
}
