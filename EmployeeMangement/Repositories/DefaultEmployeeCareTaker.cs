using EmployeeMangement.Context;
using EmployeeMangement.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeMangement.Repositories
{
    public class DefaultEmployeeCareTaker : EmployeeCateTaker
    {
        private readonly EmployeeDbContext _dbContext;
        public DefaultEmployeeCareTaker()
        {

        }
        public DefaultEmployeeCareTaker(EmployeeDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public Employee findEmployeeById(int employeeId)
        {
            return _dbContext.Employees.Find(employeeId);
        }

        public int getThirdHighestSalary()
        {
            int thirdHighestSalary = _dbContext.Employees
                .OrderByDescending(e => e.employeeSalary)
                .Skip(2).Select(e => e.employeeSalary)
                .FirstOrDefault();

            return thirdHighestSalary; 

        }

        public bool isEmployeeCodeExist(String employeeCode)
        {
           
            bool ans=   _dbContext.Employees.Any(e => e.employeeCode == employeeCode);
            return ans;
        }

        public void updateEmployee(Employee employee)
        {
            _dbContext.SaveChanges();
        }
    }
}
