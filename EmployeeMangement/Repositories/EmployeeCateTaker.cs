using EmployeeMangement.Models;

namespace EmployeeMangement.Repositories
{
    public interface EmployeeCateTaker
    {
       int getThirdHighestSalary();
       bool isEmployeeCodeExist(String employeeCode);

       Employee findEmployeeById(int employeeId);

        void updateEmployee(Employee employee);
    }
}
