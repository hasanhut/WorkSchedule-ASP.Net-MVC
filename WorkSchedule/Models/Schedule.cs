using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WorkSchedule.Models
{
    public class Schedule
    {
        [Key]
        public int ScheduleId { get; set; }
        [Required]
        public int EmployeeId { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public int Week { get; set; }
        [Required]
        public int Year { get; set; }
        [Required,MaxLength(2)]
        public string SwType { get; set; }
    }
}
