using EmployeeManagment.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagment.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Employee> EmployeeDetails { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Address> Address { get; set; }


    }
}
