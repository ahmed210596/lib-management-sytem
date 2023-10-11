using System.ComponentModel.DataAnnotations;

namespace TestProject.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string EmployeeName { get; set; }
        [Required]
        public string EmloyeePhone { get; set; }
        public string EmployeeEmail { get; set; }
        public int? EmployeeAge { get; set; }
        public decimal? EmployeeSalary { get; set; }
    }
}
