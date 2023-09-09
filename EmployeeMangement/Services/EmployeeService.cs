using EmployeeMangement.Models;

namespace EmployeeMangement.Services
{
    public interface EmployeeService
    {
        public int getThirdHighestSalary();
        String addNewEmployeeRecord(Employee updateEmployee);

    }
}
