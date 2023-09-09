using EmployeeMangement.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeMangement.Context
{
    public class EmployeeDbContext:DbContext
    {
        public EmployeeDbContext()
        {

        }
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options)
        { 
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeAttendance> EmployeeAttendance { get; set; }
    }
}
