using EmployeeMangement.Context;
using EmployeeMangement.Models;
using EmployeeMangement.Repositories;

namespace EmployeeMangement.Services
{
    public class DefaultEmployeeService : EmployeeService
    {
         EmployeeDbContext dbContext ;
        public DefaultEmployeeService(EmployeeDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public string addNewEmployeeRecord(Employee updateEmployee)
        {
            EmployeeCateTaker employeeCareTaker = new DefaultEmployeeCareTaker(dbContext);

            Employee employee = employeeCareTaker.findEmployeeById(updateEmployee.employeeId);
            if (employee == null)
            {
                return "No Employee Found";
            }
            if (employeeCareTaker.isEmployeeCodeExist(updateEmployee.employeeCode))
            {
                return "Employee code is already in use";
            }


 
            employee.employeeName = updateEmployee.employeeName;
            employee.employeeCode = updateEmployee.employeeCode;

            employeeCareTaker.updateEmployee(employee);

            return "New Employee Name is :" + employee.employeeName + " New Employee Code is :" + employee.employeeCode;
        }

        public int getThirdHighestSalary()
        {
            
            EmployeeCateTaker employeeCateTaker = new DefaultEmployeeCareTaker(dbContext);
            return employeeCateTaker.getThirdHighestSalary();
        }

    }
}
