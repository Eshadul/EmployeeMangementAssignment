using System.ComponentModel.DataAnnotations;

namespace EmployeeMangement.Models
{
    public class Employee
    {
        public int employeeId { get; set; }

        [Required(ErrorMessage = "Employee Name is required")]
        public string employeeName { get; set; }

        [Required(ErrorMessage = "Employee Code is required")]
        [RegularExpression(@"^EMP\d{3}$", ErrorMessage = "Employee Code must be in the format EMPxxx, where 'x' is a digit.")]
        public string employeeCode { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Employee Salary must be a positive value.")]
        public int employeeSalary { get; set; }
        public int supervisorId { get; set; }
    }
}
