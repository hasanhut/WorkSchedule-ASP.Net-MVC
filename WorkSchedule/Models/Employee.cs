using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WorkSchedule.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        [MaxLength(50),Required]
        public string EmployeeName { get; set; }
        [MaxLength(50),Required]
        public string EmployeeSurname { get; set; }
    }
}
