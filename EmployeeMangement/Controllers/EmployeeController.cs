using EmployeeMangement.Context;
using EmployeeMangement.Models;
using EmployeeMangement.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace EmployeeMangement.Controllers
{
    public class EmployeeController: ControllerBase
    {
        private readonly EmployeeDbContext dbContext;
        public EmployeeController(EmployeeDbContext dbContext) {
            this.dbContext = dbContext;
        }
        [HttpGet("api/third-highest-salary")]
        public String GetThirdHighestSalary()
        {
           EmployeeService employeeService = new DefaultEmployeeService(dbContext);
            return "The Employee's Third Highest Salary "+employeeService.getThirdHighestSalary();
        }

        [HttpGet("api/employees/nobsalabsent")]
        public IActionResult GetEmployeesWithNoAbsentRecords()
        {
            EmployeeService employeeService = new DefaultEmployeeService(dbContext);
            var employees = dbContext.Employees
                .Where(e => !dbContext.EmployeeAttendance.Any(a => a.employeeId == e.employeeId && a.isAbsent))
                .OrderByDescending(e => e.employeeSalary)
                .Select(e => e.employeeName) // Select only employee names
                .ToList();

            return Ok(employees);
        }


        [HttpGet("api/employee/hierarchy/{employeeId}")]

        public async Task<IActionResult> GetHierarchy(int employeeId)
        {
            var hierarchy = await GetEmployeeHierarchy(employeeId);
            if (hierarchy == null)
            {
                return NotFound();
            }

            return Ok(hierarchy);
        }

        private async Task<List<string>> GetEmployeeHierarchy(int employeeId)
        {
            var hierarchy = new List<string>();
            await GetEmployeeHierarchyRecursive(employeeId, hierarchy);
            hierarchy.Reverse(); // Reverse the list to get it in descending order
            return hierarchy;
        }

        private async Task GetEmployeeHierarchyRecursive(int employeeId, List<string> hierarchy)
        {
            var employee = await dbContext.Employees.FindAsync(employeeId);

            if (employee != null)
            {
                hierarchy.Add(employee.employeeName);

                if (employee.supervisorId != 0)
                {
                    await GetEmployeeHierarchyRecursive(employee.supervisorId, hierarchy);
                }
            }
        }




        [HttpPut("api/employee")]
        public String UpdateEmployee(Employee updateEmployee)
        {
            EmployeeService employeeService = new DefaultEmployeeService(dbContext);

            if (!ModelState.IsValid)
            {
                return "invalid data passing formation";
            }

            // Check if the updated code already exists for another employee
            return employeeService.addNewEmployeeRecord(updateEmployee);
        }

    }
}
